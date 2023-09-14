using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models;
using PollPulse.Web.Models.Options;

namespace PollPulse.Web.Components.QuestionOptions
{
    public partial class _QuestionOptionsEditor
    {
        [Parameter]
        public string QuestionType{ get; set; }
        [Parameter]
        public List<QuestionOptionDisplayModel> ExistingOptions{ get; set; }

        private List<QuestionOptionDisplayModel> options = new();

        public List<QuestionOptionDisplayModel> Options => options;

        protected override void OnParametersSet()
        {
            if (ExistingOptions is not null && ExistingOptions.Count > 0)
                options = new List<QuestionOptionDisplayModel>(ExistingOptions);
        }

        private void AddOption()
        {
            options.Add(new QuestionOptionDisplayModel());
        }
    }
}
