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
    internal class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly RepositoryContext _context;

        public QuestionRepository(RepositoryContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteQuestions(long surveyId)
        {
            _context.Questions.RemoveRange(_context.Questions.Where(q => q.SurveyId == surveyId));
        }
    }
}
