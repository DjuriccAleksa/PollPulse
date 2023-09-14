using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollPulse.Entities.Models;

namespace PollPulse.Repository.Context.Configuration;

public class QuestionResponseConfiguration : IEntityTypeConfiguration<QuestionResponse>
{
    public void Configure(EntityTypeBuilder<QuestionResponse> builder)
    {
        builder.HasKey(qr => new {qr.SurveyId, qr.QuestionId, qr.SurveyResponseId});

        builder.Property(qr => qr.Text)
            .IsRequired(false);

        builder.HasOne(qr => qr.Question)
            .WithMany(q => q.QuestionResponses)
            .HasForeignKey(qr => new {qr.SurveyId, qr.QuestionId})
            .IsRequired();

        builder.HasOne(qr => qr.SurveyResponse)
        .WithMany(sr => sr.QuestionResponses)
        .HasForeignKey(qr => qr.SurveyResponseId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
    }
}
