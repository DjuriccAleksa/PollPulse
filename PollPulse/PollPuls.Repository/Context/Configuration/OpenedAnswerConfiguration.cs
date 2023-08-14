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
    public class OpenedAnswerConfiguration : IEntityTypeConfiguration<OpenedAnswer>
    {
        public void Configure(EntityTypeBuilder<OpenedAnswer> builder)
        {
            builder.HasKey(oa => oa.Id);

            builder.Property(oa => oa.Text)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.HasOne(oa => oa.GivenAnswer)
            .WithOne(ga => ga.OpenedAnswer)
            .HasForeignKey<OpenedAnswer>(oa => oa.GivenAnswerId)
            .IsRequired();
        }
    }
}
