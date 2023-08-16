using Microsoft.EntityFrameworkCore;
using PollPulse.Entities.Models;
using PollPulse.Repository.Base_repository;
using PollPulse.Repository.Context;
using PollPulse.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateSurvey(Survey survey) => Create(survey);
        public void DeleteSurvey(Survey survey) => Delete(survey);

        public async Task<IEnumerable<Survey>> GetAllSurveysForUser(Guid userGuid) => 
            await GetByCodition(s => s.User.Guid ==  userGuid)
            .ToListAsync();

        public async Task<Survey?> GetByGuid(Guid userGuid, Guid surveyGuid) => await
            GetByCodition(s => s.User.Guid == userGuid && s.Guid == surveyGuid)
            .Include(s => s.Questions)
                .ThenInclude(q => q.ClosedAnswers)
            .Include(s => s.Questions)
                .ThenInclude(q => q.GivenAnswers)
            .SingleOrDefaultAsync();
    }
}
