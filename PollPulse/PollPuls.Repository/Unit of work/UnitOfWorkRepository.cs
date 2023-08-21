using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
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
        private readonly Lazy<ISurveyResponseRepository> _surveyResponseRepository;
        private readonly Lazy<IQuestionResponseRepository> _questionRepository;
        private readonly Lazy<IClosedQuestionOptionRepository> _closedQuestionOptionRepository;
        private readonly Lazy<IQuestionResponseRepository> _questionResponseRepository;
        private readonly Lazy<ISelectedOptionRepository> _selectedOptionRepository;
        

        public UnitOfWorkRepository(RepositoryContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;

            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(userManager, signInManager, context));
            _surveyRepository = new Lazy<ISurveyRepository>(() => new SurveyRepository(context));
            _surveyResponseRepository = new Lazy<ISurveyResponseRepository>(() => new SurveyResponseRepository(context));
            _questionResponseRepository = new Lazy<IQuestionResponseRepository>(() => new QuestionResponseRepository(context));
        }
        public IUserRepository UserRepository => _userRepository.Value;

        public ISurveyRepository SurveyRepository => _surveyRepository.Value;
        public ISurveyResponseRepository SurveyResponseRepository => _surveyResponseRepository.Value;

        public IQuestionResponseRepository QuestionRepository => throw new NotImplementedException();


        public IClosedQuestionOptionRepository ClosedQuestionOptionRepository => throw new NotImplementedException();

        public IQuestionResponseRepository QuestionResponseRepository=> _questionResponseRepository.Value;

        public ISelectedOptionRepository SelectedOptionRepository => throw new NotImplementedException();

        public async Task Save() => await _context.SaveChangesAsync();
        public async Task<IDbContextTransaction> BeginTransaction() => await _context.Database.BeginTransactionAsync();

    }
}
