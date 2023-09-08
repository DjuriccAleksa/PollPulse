using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Authentication;
using PollPulse.Web.Services.Contracts;
using System.Web;

namespace PollPulse.Web.Pages.Authentication
{
    public partial class ResetPasswordPage
    {
        [Inject]
        public IAuthenticationService AuthenticationService{ get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private string Token { get; set; }
        private string Guid { get; set; }

        private bool isAuthenticated = true;

        private UserResetPasswordModel _userResetPassword = new();
        private bool showErrorMessage = false;
        private IEnumerable<string> Errors { get; set; }

        protected override void OnInitialized()
        {
            var uri = new Uri(NavigationManager.Uri);
            Token = HttpUtility.ParseQueryString(uri.Query).Get("token")!;
            Guid = HttpUtility.ParseQueryString(uri.Query).Get("guid")!;

            if (string.IsNullOrWhiteSpace(Token) || string.IsNullOrWhiteSpace(Guid))
                isAuthenticated = false;
        }

        public async Task ResetPassword()
        {
            showErrorMessage = false;

            _userResetPassword.Token = Token;
            _userResetPassword.Guid = Guid;

            var result = await AuthenticationService.ResetPassword(_userResetPassword);

            if(result.IsSuccesfull == false)
            {
                Errors = result.Errors!;
                showErrorMessage = true;
            }

            else
            {
                // success message
                NavigationManager.NavigateTo("/login");
            }
        }


    }
}
