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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(int.MaxValue); 

            builder.Property(q => q.QuestionType)
                .IsRequired()
                .HasConversion<string>() 
                .HasColumnType("nvarchar(80)"); 
            
            var questionTypes = Enum.GetValues(typeof(QuestionType))
                                    .Cast<QuestionType>()
                                    .Select(e => e.ToString())
                                    .ToArray();

            builder.ToTable(t => t.HasCheckConstraint("CK_Question_QuestionTypeValue", $"QuestionType IN ({string.Join(",", questionTypes.Select(e => $"'{e}'"))})"));

            builder.HasOne(q => q.Survey)
              .WithMany(s => s.Questions)
              .HasForeignKey(q => q.SurveyId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade); 

        }
    }
}
