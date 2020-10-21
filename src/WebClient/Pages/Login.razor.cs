﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WebClient.Model.Dto;
using WebClient.Services;

namespace WebClient.Pages
{
    public partial class Login
    {
        private UserForAuthenticationDto _userForAuthentication = new UserForAuthenticationDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }

        public async Task ExecuteLogin()
        {
            ShowAuthError = false;

            var result = await AuthenticationService.Login(_userForAuthentication);
            if (result.IsAuthSuccessful)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Error = result.ErrorMessage;
                ShowAuthError = true;
            }
        }
    }
}