using Microsoft.EntityFrameworkCore;

using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Entities;
using Todo.Persistence.Database.DbConfigurations;

namespace Todo.Persistence.Database
{
    public class TodoDbContext:DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserMap());
            modelBuilder.ApplyConfiguration(new TodoMap());
        }

        public DbSet<UserTodo> Todos => Set<UserTodo>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    }

 
}
