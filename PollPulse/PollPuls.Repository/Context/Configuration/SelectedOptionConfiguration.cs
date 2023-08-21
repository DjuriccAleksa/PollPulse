using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollPulse.Entities.Models;

namespace PollPulse.Repository.Context.Configuration;

public class SelectedOptionConfiguration : IEntityTypeConfiguration<SelectedOption>
{
    public void Configure(EntityTypeBuilder<SelectedOption> builder)
    {
        builder.HasKey(so => new { so.SurveyId, so.QuestionId, so.ClosedQuestionOptionId, so.SurveyResponseId});

        builder.HasOne(so => so.QuestionResponse)
            .WithMany(ga => ga.SelectedOptions)
            .HasForeignKey(so => new {so.SurveyId, so.QuestionId, so.SurveyResponseId});

        builder.HasOne(so => so.ClosedQuestionOption)
            .WithMany(ca => ca.SelectedOptions)
            .HasForeignKey(so => new {so.SurveyId, so.QuestionId, so.ClosedQuestionOptionId })
            .OnDelete(DeleteBehavior.NoAction);
    }
}
