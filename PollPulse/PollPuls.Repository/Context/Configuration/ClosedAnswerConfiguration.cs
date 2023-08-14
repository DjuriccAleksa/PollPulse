using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollPulse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollPulse.Repository.Context.Configuration
{
    public class ClosedAnswerConfiguration : IEntityTypeConfiguration<ClosedAnswer>
    {
        public void Configure(EntityTypeBuilder<ClosedAnswer> builder)
        {
            builder.HasKey(ca => ca.Id);

            builder.Property(ca => ca.TextOption)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(ca => ca.Question)
                .WithMany(q => q.ClosedAnswers)
                .HasForeignKey(ca => ca.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
