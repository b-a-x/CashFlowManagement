﻿using System;
using System.Collections.Generic;
using CashFlow.DataProvider.EFCore;
using CashFlow.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CashFlow.Server.Extensions
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                //Log errors or do anything you think it's needed
                throw;
            }

            return host;
        }
        public static IHost InitializeDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            try
            {
                appContext.Incomes.AddRange(new List<Income>
                {
                    new Income { Name = "Зарплата", Price = 100000, OrderNumber = 1 },
                    new Income { Name = "Дивиденты по акциям компании Apple", Price = 250, OrderNumber = 2 }
                });

                appContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //Log errors or do anything you think it's needed
                throw;
            }

            return host;
        }
    }
}