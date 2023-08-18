using Microsoft.EntityFrameworkCore;
using PollPulse.Common.RequestFeatrues;
using PollPulse.Entities.Models;
using PollPulse.Repository.Base_repository;
using PollPulse.Repository.Context;
using PollPulse.Repository.Extensions;
using PollPulse.Repository.Interfaces;

namespace PollPulse.Repository;

public class SurveyRepository : Repository<Survey>, ISurveyRepository
{
    public SurveyRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateSurvey(Survey survey) => Create(survey);
    public void DeleteSurvey(Survey survey) => Delete(survey);


    public async Task<PaginationList<Survey>> GetAllSurveysForUser(Guid userGuid, SurveySpecification surveySpecification)
    {
        var surveys = await GetByCodition(s => (s.User.Guid == userGuid))
            .Filter(surveySpecification.DateCreatedAfter)
            .Search(surveySpecification.SearchTerm!)
            .Sort(surveySpecification.OrderBy!)
            .ToListAsync();

        return PaginationList<Survey>.ToPaginationList(surveys, surveySpecification.PageNumber, surveySpecification.PageSize);
    }

    public async Task<Survey?> GetByGuid(Guid userGuid, Guid surveyGuid) => await
        GetByCodition(s => s.User.Guid == userGuid && s.Guid == surveyGuid)
        .Include(s => s.Questions)
            .ThenInclude(q => q.ClosedQuestionOptions)
        .Include(s => s.Questions)
            .ThenInclude(q => q.QuestionResponses)
        .SingleOrDefaultAsync();
}
