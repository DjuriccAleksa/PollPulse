using PollPulse.Entities.Models.Base;

namespace PollPulse.Entities.Models;

public class Question : IEntity
{
    public long Id { get; set; }
    public long SurveyId { get; set; }
    public string Text { get; set; }
    public QuestionType QuestionType{ get; set; }

    public Survey Survey { get; set; }

    public List<QuestionResponse> QuestionResponses { get; set; }
    public List<ClosedQuestionOption> ClosedQuestionOptions { get; set; }
}
