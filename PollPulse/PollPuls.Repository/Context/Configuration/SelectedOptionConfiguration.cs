using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollPulse.Entities.Models;

namespace PollPulse.Repository.Context.Configuration;

public class SelectedOptionConfiguration : IEntityTypeConfiguration<SelectedOption>
{
    public void Configure(EntityTypeBuilder<SelectedOption> builder)
    {
        builder.HasKey(so => new { so.QuestionResponseId, so.ClosedQuestionOptionId});

        builder.HasOne(so => so.QuestionResponse)
            .WithMany(ga => ga.SelectedOptions)
            .HasForeignKey(so => so.QuestionResponseId);

        builder.HasOne(so => so.ClosedQuestionOption)
            .WithMany(ca => ca.SelectedOptions)
            .HasForeignKey(so => so.ClosedQuestionOptionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
