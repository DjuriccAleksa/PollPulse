using PollPulse.Application.Interfaces;
using PollPulse.Common.DTO.QuestionsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Application.Queries.QuestionQueries
{
    public record GetQuestionWithQuestionResponsesQuery(long SurveyId, long QuestionId) : IQuery<QuestionDTO>;
}
