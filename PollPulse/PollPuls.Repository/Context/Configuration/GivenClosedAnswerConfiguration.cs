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
    public class GivenClosedAnswerConfiguration : IEntityTypeConfiguration<GivenClosedAnswer>
    {
        public void Configure(EntityTypeBuilder<GivenClosedAnswer> builder)
        {
            builder.HasKey(gca => new { gca.GivenAnswerId, gca.ClosedAnswerId });

            builder.HasOne(gca => gca.GivenAnswer)
                .WithMany(ga => ga.GivenClosedAnswers)
                .HasForeignKey(gca => gca.GivenAnswerId);

            builder.HasOne(gca => gca.ClosedAnswer)
                .WithMany(ca => ca.GivenClosedAnswers)
                .HasForeignKey(gca => gca.ClosedAnswerId);
        }
    }
}
