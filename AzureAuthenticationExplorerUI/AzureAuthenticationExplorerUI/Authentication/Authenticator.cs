using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using AzureAuthenticationExplorerUI.Models;
using Microsoft.Identity.Client;
namespace AzureAuthenticationExplorerUI.Authentication
{
    /// <summary>
    /// This class provides the functionality to logon to Azure
    /// </summary>
    public class Authenticator
    {
        private readonly string _Tenant;
        private readonly string _Instance = "https://login.microsoftonline.com/";
        private readonly string[] _Scopes = new string[] { "https://graph.microsoft.com/.default" };
        private readonly string _RedirectUri;
        private readonly string _ClientID;

        public bool IsConnected { get; set; }
        public Authenticator(string tenantID, string clientID, string redirectUri)
        {
            _Tenant = tenantID;
            _ClientID = clientID;
            _RedirectUri = redirectUri;
        }
        public async Task<AuthenticationResult> AuthenticateInteractive()
        {
            var clientApp = Microsoft.Identity.Client.PublicClientApplicationBuilder
                .Create(_ClientID)
                .WithAuthority($"{_Instance}{_Tenant}")
                .WithRedirectUri(_RedirectUri)
                .Build();
            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);

            AuthenticationResult authResult = null;
            var accounts = await clientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await clientApp.AcquireTokenInteractive(_Scopes)
                    .WithAccount(firstAccount)
                    .WithPrompt(Prompt.SelectAccount)
                    .ExecuteAsync();
                IsConnected = true;
            }
            catch (MsalException msalex)
            {
                MessageBox.Show($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
            }

            return authResult;
        }

        public async Task<AuthenticationResult> AuthenticateSilent()
        {
            var clientApp = Microsoft.Identity.Client.PublicClientApplicationBuilder
                .Create(_ClientID)
                .WithAuthority($"{_Instance}{_Tenant}")
                .WithRedirectUri(_RedirectUri)
                .Build();
            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);

            AuthenticationResult authResult = null;
            var accounts = await clientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await clientApp.AcquireTokenSilent(_Scopes, firstAccount)
                    .WithAuthority($"{_Instance}{_Tenant}")
                    .ExecuteAsync();
                IsConnected = true;
            }
            catch (MsalException msalex)
            {
                MessageBox.Show($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
            }

            return authResult;
        }
    }
}
