using PollPulse.Entities.Models;

namespace PollPulse.Repository.Interfaces;

public interface IQuestionRepository
{
    Task<Question> GetQuestionWithResponses(long surveyId, long questionId); 
    void DeleteQuestions(long surveyId);
}

