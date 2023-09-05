using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using PollPulse.Common.DTO.UsersDTOs;
using PollPulse.Web.Authentication;
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

        public async Task<string> Login(UserLoginDTO userLogin)
        {
            var content = JsonSerializer.Serialize(userLogin);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var authResult = await _httpClient.PostAsync("users/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (authResult.IsSuccessStatusCode == false)
                return "";

            var result = JsonSerializer.Deserialize<string>(
                authContent,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true} );

            await _localStorage.SetItemAsync(_configuration.LocalStorageAuthKey, result);
            ((AuthStateProvider)_authenticationStateProvider).NotifyUserAuthentication(userLogin.Username);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result);

            return result;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(_configuration.LocalStorageAuthKey);
            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
