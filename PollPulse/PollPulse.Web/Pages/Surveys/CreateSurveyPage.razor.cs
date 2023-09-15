using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using PollPulse.Web.Models.Questions;
using PollPulse.Web.Models.Surveys;
using PollPulse.Web.Services.Contracts;

namespace PollPulse.Web.Pages.Surveys;
[Authorize]
public partial class CreateSurveyPage
{
    [Inject]
    public ISurveysService SurveysService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public SurveyCreateModel Survey { get; set; } = new();
    public List<QuestionDisplayModel> QuestionsList { get; set; } = new();
    private bool showQuestionEditor = false;
    private QuestionDisplayModel currentlyEditedQuestion = new();
    private bool isQuestionEditing = false;

    private EventCallback<QuestionDisplayModel> _deleteQuestionCallback = EventCallback<QuestionDisplayModel>.Empty;
    EventCallback<QuestionDisplayModel> DeleteQuestionCallback
    {
        get
        {
            if (_deleteQuestionCallback.Equals(EventCallback<QuestionDisplayModel>.Empty))
                _deleteQuestionCallback = EventCallback.Factory.Create<QuestionDisplayModel>(this, DeleteQuestion);
            return _deleteQuestionCallback;
        }
    }

    private EventCallback<QuestionDisplayModel> editQuestionCallback = EventCallback<QuestionDisplayModel>.Empty;
    EventCallback<QuestionDisplayModel> EditQuestionCallback
    {
        get
        {
            if (editQuestionCallback.Equals(EventCallback<QuestionDisplayModel>.Empty))
                editQuestionCallback = EventCallback.Factory.Create<QuestionDisplayModel>(this, EditQuestion);
            return editQuestionCallback;
        }
    }

    public void AddNewQuestion(QuestionDisplayModel question)
    {
        if(isQuestionEditing == false)
        {
            QuestionsList.Add(question);
        }
        else
        {
            var index = QuestionsList.IndexOf(currentlyEditedQuestion);
            if (index != -1)
            {
                QuestionsList[index] = question;
            }
        }

        showQuestionEditor = false;
        isQuestionEditing = false;
        currentlyEditedQuestion = new();
    }

    private void DeleteQuestion(QuestionDisplayModel question)
    {
        QuestionsList.Remove(question);
    }

    private void EditQuestion(QuestionDisplayModel question)
    {
        currentlyEditedQuestion = question;
        showQuestionEditor = true;
        isQuestionEditing = true;
    }

    public void OpenQuestionEditor()
    {
        showQuestionEditor = true;
    }

    public async void CreateSurvey()
    {
        Survey.Questions = QuestionsList;

        var result = await SurveysService.CreateSurvey(Survey);

        if (result is null)
            throw new Exception("Error in creating survey..");

        NavigationManager.NavigateTo("/");
    }
}
