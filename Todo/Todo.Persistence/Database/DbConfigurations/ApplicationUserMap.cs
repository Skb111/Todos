using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;

namespace Todo.Persistence.Database.DbConfigurations
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
          builder.ToTable("ApplicationUser")
            .HasKey(x => x.ApplicationUserId);

            builder.Property(x => x.ApplicationUserId)
                  .HasDefaultValueSql("newid()");

            builder.Property(x => x.Email)
                .IsRequired().HasMaxLength(128);
            
            builder.Property(x => x.Username)
                .IsRequired().HasMaxLength(128);

            builder.Property(x=> x.Password)
                .HasMaxLength(1000).IsRequired();
            
            builder.Property(x=> x.PasswordSalt)
                .HasMaxLength(1000).IsRequired();

            builder.Property(x => x.Status)
                .IsRequired().HasDefaultValue(UserStatus.Active);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime");

        }
    }
}
