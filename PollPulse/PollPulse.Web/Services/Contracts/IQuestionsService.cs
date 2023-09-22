using PollPulse.Web.Models.Questions;

namespace PollPulse.Web.Services.Contracts
{
    public interface IQuestionsService
    {
        Task<QuestionsWithResponsesDisplayModel> GetQuestion(string surveyGuid, long questionId);
    }
}
