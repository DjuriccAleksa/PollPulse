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
        IQuestionRepository QuestionRepository { get; }
        IOpenedAnswerRepository OpenedAnswerRepository { get; }
        IClosedAnswerRepository ClosedAnswerRepository { get; }
        IGivenAnswerRepository GivenAnswerRepository { get; }
        IGivenClosedAnswerRepository GivenClosedAnswerRepository { get; }

        Task Save();
    }
}
