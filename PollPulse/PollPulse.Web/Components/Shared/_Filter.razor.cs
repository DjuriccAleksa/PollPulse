using Microsoft.AspNetCore.Components;

namespace PollPulse.Web.Components.Shared
{
    public partial class _Filter
    {
        private DateTime? SelectedDate { get; set; }

        [Parameter]
        public EventCallback<DateTime?> OnFilterChanged { get; set; }

        private async Task ApplyFilter()
        {
            await OnFilterChanged.InvokeAsync(SelectedDate);
        }

        private async Task ResetFilter()
        {
            SelectedDate = null;
            await OnFilterChanged.InvokeAsync(null);
        }
    }
}
