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
    public class OpenResponseConfiguration : IEntityTypeConfiguration<OpenResponse>
    {
        public void Configure(EntityTypeBuilder<OpenResponse> builder)
        {
            builder.HasKey(or => or.Id);

            builder.Property(or => or.Text)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            builder.HasOne(or => or.QuestionResponse)
            .WithOne(ga => ga.OpenResponse)
            .HasForeignKey<OpenResponse>(oa => oa.QuestionResponseId)
            .IsRequired();
        }
    }
}
