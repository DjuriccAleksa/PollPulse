using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PollPulse.Web.Models.Authentication;
using PollPulse.Web.Services.Contracts;
using System.Web;

namespace PollPulse.Web.Pages.Authentication;

public partial class LogInPage
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public  IJSRuntime JSRuntime { get; set; }


    private UserLoginModel _userForLogin = new();

    private bool showAuthError = false;
    private string ErrorText { get; set; } = "";
    private bool isEmailConfirmedRedirect = false;

    protected override async void OnInitialized()
    {
        var uri = new Uri(NavigationManager.Uri);
        var emailConfirmedParam = HttpUtility.ParseQueryString(uri.Query).Get("emailConfirmed");

        isEmailConfirmedRedirect = emailConfirmedParam == "true";

        if (isEmailConfirmedRedirect)
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", "You have successfully confirmed your email!", "Congrats");
    }
    

    public async Task Login()
    {
        showAuthError = false;

        var result = await AuthenticationService.Login(_userForLogin);

        if (result.IsSuccesfull == false)
        {
            ErrorText = result.Errors.First();
            showAuthError = true;
        }
        else
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
