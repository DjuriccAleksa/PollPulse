using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PollPulse.Web.Models.Questions;

namespace PollPulse.Web.Components.Questions
{
    public partial class _DraggableQuestionList : _BaseQuestionList
    {
        protected override RenderFragment RenderQuestion(QuestionDisplayModel question)
        {
            return builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", "draggable-container");
                builder.AddAttribute(2, "draggable", "true");
                builder.AddAttribute(3, "ondrag", EventCallback.Factory.Create<DragEventArgs>(this, e => DragStart(e, question)));
                builder.AddAttribute(4, "ondragover", "event.preventDefault()");
                builder.AddAttribute(5, "ondrop", EventCallback.Factory.Create<DragEventArgs>(this, e => Drop(e, question)));

                builder.OpenComponent<_Question>(6);
                builder.AddAttribute(7, "Question", question);
                builder.AddAttribute(8, "QuestionNumber", Questions.IndexOf(question) + 1);
                builder.AddAttribute(9, "IsReadOnly", true);
                builder.AddAttribute(10, "IsEditable", true);

                builder.CloseComponent();
                builder.CloseElement();
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
