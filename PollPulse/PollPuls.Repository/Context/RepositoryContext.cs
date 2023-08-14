using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PollPulse.Entities.Models;
using PollPulse.Repository.Context.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Context
{
    public class RepositoryContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> AppUsers{ get; }
        public DbSet<Survey> Surveys { get;  }
        public DbSet<Question> Questions{ get; }
        public DbSet<GivenAnswer> GivenAnswers { get; }
        public DbSet<OpenedAnswer> OpenedAnswers{ get; set; }
        public DbSet<ClosedAnswer> ClosedAnswers{ get; set; }
        public DbSet<GivenClosedAnswer> GivenClosedAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new SurveyConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());
            builder.ApplyConfiguration(new GivenAnswerConfiguration());
            builder.ApplyConfiguration(new OpenedAnswerConfiguration());
            builder.ApplyConfiguration(new ClosedAnswerConfiguration());
            builder.ApplyConfiguration(new GivenClosedAnswerConfiguration());
        }

    }
}
