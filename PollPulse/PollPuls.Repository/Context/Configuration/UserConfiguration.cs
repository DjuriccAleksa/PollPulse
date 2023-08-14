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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u =>  u.Id);

            builder.Property(u => u.Guid)
            .IsRequired();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(18);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(24);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .IsRequired();
        }
    }
}
