using Microsoft.AspNetCore.Components;

namespace PollPulse.Web.Components.Shared
{
    public partial class _CustomTab
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        private List<string> TabTitles = new List<string>();
        private string ActiveTabTitle = string.Empty;
        public string GetActiveTabTitle() => ActiveTabTitle;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (TabTitles.Any())
                {
                    ActiveTabTitle = TabTitles.First();
                }
                StateHasChanged(); 
            }
        }

        public void AddTab(string title)
        {
            TabTitles.Add(title);
            StateHasChanged();
        }

        public void SetActiveTab(string title)
        {
            ActiveTabTitle = title;
        }
    }
}
