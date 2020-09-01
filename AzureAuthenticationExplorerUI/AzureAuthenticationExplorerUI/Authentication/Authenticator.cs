using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using AzureAuthenticationExplorerUI.Models;
using AzureAuthenticationExplorerUI.ViewModels;
using Microsoft.Identity.Client;
namespace AzureAuthenticationExplorerUI.Authentication
{
    /// <summary>
    /// This class provides the functionality to logon to Azure
    /// </summary>
    public class Authenticator
    {
        private readonly string _Instance = "https://login.microsoftonline.com/";
        private readonly string[] _Scopes = new string[] { "https://graph.microsoft.com/.default" };
        private IPublicClientApplication _ClientApp;
        private readonly ViewModel _ViewModel;

        public bool IsConnected { get; set; }
        public bool IsAccountAvailable { get; set; }
        public Authenticator(ViewModel viewModel)
        {
            _ViewModel = viewModel;
            IsConnected = false;
        }
        public async Task<string> AuthenticateInteractive()
        {
            _ClientApp = Microsoft.Identity.Client.PublicClientApplicationBuilder
                .Create(_ViewModel.AuthData.ClientID)
                .WithAuthority($"{_Instance}{_ViewModel.AuthData.TenantID}")
                .WithRedirectUri(_ViewModel.AuthData.RedirectURI)
                .Build();
            TokenCacheHelper.EnableSerialization(_ClientApp.UserTokenCache);

            string result;
            AuthenticationResult authResult;

            var accounts = await _ClientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();
            IsAccountAvailable = true;

            try
            {
                authResult = await _ClientApp.AcquireTokenInteractive(_Scopes)
                    .WithAccount(firstAccount)
                    .WithPrompt(Prompt.SelectAccount)
                    .ExecuteAsync();
                IsConnected = true;
                result = authResult.AccessToken;
            }
            catch (MsalException msalex)
            {
                result = $"Error Acquiring Token:{System.Environment.NewLine}{msalex.Message}";
            }

            return result;
        }

        public async Task<string> AuthenticateSilent()
        {
            _ClientApp = Microsoft.Identity.Client.PublicClientApplicationBuilder
                .Create(_ViewModel.AuthData.ClientID)
                .WithAuthority($"{_Instance}{_ViewModel.AuthData.TenantID}")
                .WithRedirectUri(_ViewModel.AuthData.RedirectURI)
                .Build();
            TokenCacheHelper.EnableSerialization(_ClientApp.UserTokenCache);

            AuthenticationResult authResult;
            string result = null;
            var accounts = await _ClientApp.GetAccountsAsync();
            if (accounts.ToList().Count > 0)
            {
                var firstAccount = accounts.FirstOrDefault();
                try
                {
                    authResult = await _ClientApp.AcquireTokenSilent(_Scopes, firstAccount)
                        .WithAuthority($"{_Instance}{_ViewModel.AuthData.TenantID}")
                        .ExecuteAsync();
                    IsConnected = true;
                    result = authResult?.AccessToken;
                }
                catch (MsalException msalex)
                {
                    result = $"Error Acquiring Token:{System.Environment.NewLine}{msalex.Message}";
                }    
            }

            return result;
        }

        public async Task LogoutAccount()
        {
            var accounts = await _ClientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();
            await _ClientApp.RemoveAsync(firstAccount);
            IsConnected = false;
        }
    }
}
