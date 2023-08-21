using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Interfaces.Unit_of_work
{
    public  interface IUnitOfWorkRepository
    {
        IUserRepository UserRepository { get; }
        ISurveyRepository SurveyRepository { get; }
        ISurveyResponseRepository SurveyResponseRepository { get; }
        IQuestionResponseRepository QuestionRepository { get; }
        IClosedQuestionOptionRepository ClosedQuestionOptionRepository { get; }
        IQuestionResponseRepository QuestionResponseRepository { get; }
        ISelectedOptionRepository SelectedOptionRepository{ get; }

        Task Save();
        Task<IDbContextTransaction> BeginTransaction();

    }
}
