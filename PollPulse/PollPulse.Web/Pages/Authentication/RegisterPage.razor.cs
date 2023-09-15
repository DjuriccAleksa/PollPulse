using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PollPulse.Web.Models.Authentication;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Authentication;

public partial class RegisterPage
{
    private UserRegisterModel _userForRegistration = new();
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }
    public bool ShowRegistrationErrors { get; set; }
    public IEnumerable<string> Errors { get; set; }
    private bool loadingSpinner = false;
    public async Task RegisterUser()
    {
        loadingSpinner = true;
        ShowRegistrationErrors = false;

        var result = await AuthenticationService.Register(_userForRegistration);

        loadingSpinner = false;

        StateHasChanged();

        if (result.IsSuccesfull)
        {
            await JSRuntime.InvokeVoidAsync("FireSweetAlert");
            NavigationManager.NavigateTo("/login");
        }
        else
        {
            Errors = result.Errors;
            ShowRegistrationErrors = true;
        }
        
    }
}
