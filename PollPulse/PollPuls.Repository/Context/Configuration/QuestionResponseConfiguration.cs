using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollPulse.Entities.Models;

namespace PollPulse.Repository.Context.Configuration;

public class QuestionResponseConfiguration : IEntityTypeConfiguration<QuestionResponse>
{
    public void Configure(EntityTypeBuilder<QuestionResponse> builder)
    {
        builder.HasKey(qr => qr.Id);

        builder.HasOne(qr => qr.Question)
            .WithMany(q => q.QuestionResponses) 
            .HasForeignKey(qr => qr.QuestionId) 
            .IsRequired() 
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(qr => qr.OpenResponse)
        .WithOne(oa => oa.QuestionResponse)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
