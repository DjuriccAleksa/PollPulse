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
    public class QuestionResponseRepository : Repository<QuestionResponse>, IQuestionResponseRepository
    {
        public QuestionResponseRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
