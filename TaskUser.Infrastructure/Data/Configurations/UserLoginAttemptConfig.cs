using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUser.Domain.Base;
using TaskUser.Domain.Entities;

namespace TaskUser.Infrastructure.Data.Configurations
{
    public class UserLoginAttemptConfig : IEntityTypeConfiguration<UserLoginAttempt>
    {
        public void Configure(EntityTypeBuilder<UserLoginAttempt> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AttemptTime).IsRequired();
            builder.Property(x => x.IsSuccess).IsRequired();
            builder.HasOne(x => x.User).WithMany(x=>x.Attempts);
        }
    }
}
