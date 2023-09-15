using Microsoft.AspNetCore.Components;

namespace PollPulse.Web.Pages.Authorized
{
    public partial class NotAuthorizedPage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(3000);

            NavigationManager.NavigateTo("/login");
        }
    }
}
