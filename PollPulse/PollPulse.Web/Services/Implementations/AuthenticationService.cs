using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using PollPulse.Common.DTOResults;
using PollPulse.Web.Authentication;
using PollPulse.Web.HttpClientUtility;
using PollPulse.Web.Models.Authentication;
using PollPulse.Web.OptionsSetup.ApplicationOptions;
using PollPulse.Web.Services.Contracts;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace PollPulse.Web.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly ApplicationConfiguration _configuration;

        public AuthenticationService(HttpClient httpClient, 
            AuthenticationStateProvider authenticationStateProvider, 
            ILocalStorageService localStorage,
            IOptions<ApplicationConfiguration> options)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _configuration = options.Value;
        }

        public async Task<UserLoginResultDTO> Login(UserLoginModel userLogin)
        {
            var result = await HttpClientAPIHelper.PostAsync<UserLoginModel, UserLoginResultDTO>(_httpClient, APIRoutes.LOGIN, userLogin);

            if(result.IsSuccesfull == false)
                return result;

            await _localStorage.SetItemAsync(_configuration.LocalStorageAuthKey, result.Token);
            ((AuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.Token);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

            return result;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(_configuration.LocalStorageAuthKey);
            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<UserRegisterResultDTO> Register(UserRegisterModel userRegister)
        {
            var result = await HttpClientAPIHelper.PostAsync<UserRegisterModel, UserRegisterResultDTO>(_httpClient, APIRoutes.REGISTER , userRegister);

            return result;
        }

        public async Task<UserResetPasswordResultDTO> ResetPassword(UserResetPasswordModel userResetPassword)
        {
            var result = await HttpClientAPIHelper.PostAsync<UserResetPasswordModel, UserResetPasswordResultDTO>(_httpClient, APIRoutes.RESET_PASSWORD, userResetPassword);

            return result; 
        }

        public async Task<bool> SendResetLink(UserForgotPasswordModel userForgotPasswordDTO)
        {
            var result = await HttpClientAPIHelper.PostAsync<UserForgotPasswordModel, string>(_httpClient, APIRoutes.FORGOT_PASSWORD, userForgotPasswordDTO);

            if(result is null || result == "")
                return true;

            return false;
        }
    }
}
