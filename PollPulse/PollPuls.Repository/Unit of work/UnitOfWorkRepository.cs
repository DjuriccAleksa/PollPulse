using Microsoft.AspNetCore.Identity;
using PollPulse.Entities.Models;
using PollPulse.Repository.Context;
using PollPulse.Repository.Interfaces;
using PollPulse.Repository.Interfaces.Unit_of_work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Unit_of_work
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ISurveyRepository> _surveyRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<IClosedAnswerRepository> _closedAnswerRepository;
        private readonly Lazy<IOpenedAnswerRepository> _openedAnswerRepository;
        private readonly Lazy<IGivenAnswerRepository> _givenAnswerRepository;
        private readonly Lazy<IGivenClosedAnswerRepository> _givenClosedAnswerRepository;
        

        public UnitOfWorkRepository(RepositoryContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;

            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(userManager, signInManager, context));
            _surveyRepository = new Lazy<ISurveyRepository>(() => new SurveyRepository(context));
        }
        public IUserRepository UserRepository => _userRepository.Value;

        public ISurveyRepository SurveyRepository => _surveyRepository.Value;

        public IQuestionRepository QuestionRepository => throw new NotImplementedException();

        public IOpenedAnswerRepository OpenedAnswerRepository => throw new NotImplementedException();

        public IClosedAnswerRepository ClosedAnswerRepository => throw new NotImplementedException();

        public IGivenAnswerRepository GivenAnswerRepository => throw new NotImplementedException();

        public IGivenClosedAnswerRepository GivenClosedAnswerRepository => throw new NotImplementedException();

        public async Task Save() => await _context.SaveChangesAsync();
    }
}
