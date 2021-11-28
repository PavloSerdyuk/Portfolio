using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id); 

            builder.Property(user => user.FirstName).HasMaxLength(20);
            builder.Property(user => user.LastName).HasMaxLength(20);
            builder.Property(user => user.Username).IsRequired();
            builder.Property(user => user.Password).IsRequired();
        }
    }
}
