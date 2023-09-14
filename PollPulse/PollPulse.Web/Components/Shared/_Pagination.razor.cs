using Microsoft.AspNetCore.Components;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Web.HttpClientUtility;

namespace PollPulse.Web.Components.Shared
{
    public partial class _Pagination
    {
        [Parameter]
        public PaginationData PaginationData { get; set; }
        [Parameter]
        public int Spread { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        private List<PaginationLink> _links;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PaginationLink>
            {
                new PaginationLink(PaginationData.CurretPage - 1, PaginationData.HasPrevious, "Previous")
            };

            for (int i = 1; i <= PaginationData.TotalPages; i++)
            {
                if (i >= PaginationData.CurretPage - Spread && i <= PaginationData.CurretPage + Spread)
                {
                    _links.Add(new PaginationLink(i, true, i.ToString()) { Active = PaginationData.CurretPage == i });
                }
            }

            _links.Add(new PaginationLink(PaginationData.CurretPage + 1, PaginationData.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PaginationLink link)
        {
            if (link.Page == PaginationData.CurretPage || !link.Enabled)
                return;

            PaginationData.CurretPage  = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
