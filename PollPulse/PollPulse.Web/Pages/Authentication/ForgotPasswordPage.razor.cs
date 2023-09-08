using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Authentication;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Authentication
{
    public partial class ForgotPasswordPage
    {
        [Inject]
        public IAuthenticationService AuthenticationService{ get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private UserForgotPasswordModel _userForgotPassword = new();
        private bool showEmailError = false;
        private string errorText = "";

        public async Task SubmitForgotPassword()
        {
            showEmailError = false;

            var result = await AuthenticationService.SendResetLink(_userForgotPassword);

            if(result == false)
            {
                // something went wrong popup
            }

            else
            {
                // success popup message
                NavigationManager.NavigateTo("/login");
            }
        }


    }
}
