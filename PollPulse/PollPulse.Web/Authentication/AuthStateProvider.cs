using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using PollPulse.Web.OptionsSetup.ApplicationOptions;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace PollPulse.Web.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly ApplicationConfiguration _applicationConfig;
        private readonly AuthenticationState _anonymous;
        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorage, IOptions<ApplicationConfiguration> options)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _applicationConfig = options.Value;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Kasnije napraviti delay na autentifikaciji
            //await Task.Delay(2000);

            var token = await _localStorage.GetItemAsync<string>(_applicationConfig.LocalStorageAuthKey);
            Console.WriteLine(token);
            if (string.IsNullOrWhiteSpace(token))
                return _anonymous;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new AuthenticationState(
                new ClaimsPrincipal(
                    new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }

        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(
                new ClaimsIdentity(
                   JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
