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
    public class GivenAnswerConfiguration : IEntityTypeConfiguration<GivenAnswer>
    {
        public void Configure(EntityTypeBuilder<GivenAnswer> builder)
        {
            builder.HasKey(ga => ga.Id);

            builder.Property(ga => ga.DateAnswered)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); 

            builder.HasOne(ga => ga.Question)
                .WithMany(q => q.GivenAnswers) 
                .HasForeignKey(ga => ga.QuestionId) 
                .IsRequired() 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ga => ga.OpenedAnswer)
            .WithOne(oa => oa.GivenAnswer)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
