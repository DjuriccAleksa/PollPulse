using Microsoft.AspNetCore.Components;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Authentication;

public partial class LogOutPage
{
    [Inject]
    public IAuthenticationService AuthenticationService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await AuthenticationService.Logout();
        NavigationManager.NavigateTo("/");
    }
}
