using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PollPulse.Entities.Models;
using PollPulse.Repository.Context.Configuration;

namespace PollPulse.Repository.Context;

public class RepositoryContext : IdentityDbContext<User, IdentityRole<long>, long>
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<User> AppUsers{ get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<SurveyResponse> SurveyResponses { get; set; }
    public DbSet<Question> Questions{ get; set; }
    public DbSet<QuestionResponse> QuestionResponses { get; set; }
    public DbSet<OpenResponse> OpenResponses{ get; set; }
    public DbSet<ClosedQuestionOption> ClosedQuestionOptions{ get; set; }
    public DbSet<SelectedOption> SelectedOptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new SurveyConfiguration());
        builder.ApplyConfiguration(new SurveyResponseConfiguration());
        builder.ApplyConfiguration(new QuestionConfiguration());
        builder.ApplyConfiguration(new QuestionResponseConfiguration());
        builder.ApplyConfiguration(new OpenResponseConfiguration());
        builder.ApplyConfiguration(new ClosedQuestionOptionConfiguration());
        builder.ApplyConfiguration(new SelectedOptionConfiguration());
    }

}
