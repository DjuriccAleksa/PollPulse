using Microsoft.AspNetCore.Components;

namespace PollPulse.Web.Components.Shared
{
    public partial class _CustomTabSection
    {
        [CascadingParameter(Name = "ParentTabComponent")] public _CustomTab Parent { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string TabTitle { get; set; }

        protected override void OnInitialized()
        {
            Parent.AddTab(TabTitle);
        }
    }
}
