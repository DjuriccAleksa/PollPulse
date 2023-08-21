using PollPulse.Common.RequestFeatrues;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Interfaces
{
    public interface ISurveyResponseRepository
    {
        void SubmitNewResponse(SurveyResponse response);
        Task<PaginationList<SurveyResponse>> GetSurveyResponsesForSurvey(long surveyId, SurveyResponseSpecification surveyResponseSpecification);


    }
}
