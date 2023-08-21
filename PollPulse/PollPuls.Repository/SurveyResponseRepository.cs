using Microsoft.EntityFrameworkCore;
using PollPulse.Common.RequestFeatrues;
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
    public class SurveyResponseRepository : Repository<SurveyResponse>, ISurveyResponseRepository
    {
        public SurveyResponseRepository(RepositoryContext context) : base(context)
        {
        }


        public void SubmitNewResponse(SurveyResponse response) => Create(response);


        public async Task<PaginationList<SurveyResponse>> GetSurveyResponsesForSurvey(long surveyId, SurveyResponseSpecification surveyResponseSpecification)
        {
            var surveyResponses = await 
                GetByCodition(sr => sr.SurveyId == surveyId)
                .Include(sr => sr.QuestionResponses)
                    .ThenInclude(qr => qr.SelectedOptions)
                        .ThenInclude(so => so.ClosedQuestionOption)
                .ToListAsync();

            return PaginationList<SurveyResponse>.ToPaginationList(surveyResponses, surveyResponseSpecification.PageNumber, 1);
        }
    }
}
