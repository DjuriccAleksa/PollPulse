using PollPulse.Common.RequestFeatrues;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Interfaces
{
    public interface ISurveyRepository
    {
        void CreateSurvey(Survey survey);
        void DeleteSurvey(Survey survey);
        Task<long> GetSurveyId(Guid guid);
        Task<Survey?> GetByGuid(Guid userGuid, Guid surveyGuid);
        Task<PaginationList<Survey>> GetAllSurveysForUser(Guid userGuid, SurveySpecification surveySpecification);
    }
}
