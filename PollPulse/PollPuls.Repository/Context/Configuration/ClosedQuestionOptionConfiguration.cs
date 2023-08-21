using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollPulse.Entities.Models;

namespace PollPulse.Repository.Context.Configuration;

public class ClosedQuestionOptionConfiguration : IEntityTypeConfiguration<ClosedQuestionOption>
{
    public void Configure(EntityTypeBuilder<ClosedQuestionOption> builder)
    {
        builder.HasKey(cqo => new {cqo.SurveyId, cqo.QuestionId, cqo.Id});

        builder.Property(cqo => cqo.Id)
            .ValueGeneratedOnAdd();

        builder.Property(cqo => cqo.TextOption)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasOne(cqo => cqo.Question)
            .WithMany(q => q.ClosedQuestionOptions)
            .HasForeignKey(cqo => new {cqo.SurveyId, cqo.QuestionId})
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
