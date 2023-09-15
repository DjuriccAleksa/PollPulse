using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PollPulse.Web.Models.QuestionResponses;
using PollPulse.Web.Models.Questions;
using PollPulse.Web.Models.SurveyResponses;

namespace PollPulse.Web.Components.Questions
{
    public partial class _QuestionList
    {
        [Parameter] public List<QuestionDisplayModel> Questions { get; set; }
        [Parameter] public SurveyResponseCreateModel SurveyResponse { get; set; }
        [Parameter] public bool IsDraggable { get; set; } = false;
        [Parameter] public bool IsReadOnly { get; set; } = false;
        [Parameter] public bool IsEditable { get; set; } = false;

        protected virtual RenderFragment RenderQuestion(QuestionDisplayModel question)
        {
            QuestionGivenResponseModel? questionResponse = null;
            if (SurveyResponse is not null)
                questionResponse = SurveyResponse.QuestionResponses.FirstOrDefault(q => q.QuestionId == question.Id);

            return builder =>
            {
                if (IsDraggable)
                {
                    builder.OpenElement(0, "div");
                    builder.AddAttribute(1, "class", "draggable-container");
                    builder.AddAttribute(2, "draggable", "true");
                    builder.AddAttribute(3, "ondrag", EventCallback.Factory.Create<DragEventArgs>(this, e => DragStart(e, question)));
                    builder.AddAttribute(4, "ondragover", "event.preventDefault()");
                    builder.AddAttribute(5, "ondrop", EventCallback.Factory.Create<DragEventArgs>(this, e => Drop(e, question)));
                }

                builder.OpenComponent<_Question>(6);
                builder.AddAttribute(7, "Question", question);

                builder.AddAttribute(8, "QuestionNumber", Questions.IndexOf(question) + 1);
                builder.AddAttribute(9, "IsReadOnly", IsReadOnly);
                builder.AddAttribute(10, "IsEditable", IsEditable);

                if (questionResponse is not null)
                    builder.AddAttribute(11, "Response", questionResponse);

                builder.CloseComponent();

                if (IsDraggable)
                {
                    builder.CloseElement();
                }
            };
        }

        private QuestionDisplayModel currentDragQuestion;

        private void DragStart(DragEventArgs e, QuestionDisplayModel question)
        {
            currentDragQuestion = question;
        }


        private void Drop(DragEventArgs e, QuestionDisplayModel target)
        {
            if (currentDragQuestion is null || currentDragQuestion == target)
                return;

            var oldIndex = Questions.IndexOf(currentDragQuestion);
            var newIndex = Questions.IndexOf(target);

            Questions.RemoveAt(oldIndex);
            Questions.Insert(newIndex, currentDragQuestion);

            StateHasChanged();
        }

    }
}
