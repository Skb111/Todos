using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Entities;

namespace Todo.Persistence.Database.DbConfigurations
{
    public class TodoMap : IEntityTypeConfiguration<UserTodo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserTodo> builder)
        {
            builder.ToTable("Todo")
                .HasKey(x => x.TodoId);

            builder.Property(x => x.TodoId)
                .HasDefaultValueSql("newid()");

            builder.Property(x=>x.Title)
                .IsRequired().HasMaxLength(200);

            builder.Property(x=>x.Description)
                .IsRequired().HasMaxLength(1000);

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime");

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.Status)
                .IsRequired().HasDefaultValue(TodoStatus.New);
        }
    }
}
