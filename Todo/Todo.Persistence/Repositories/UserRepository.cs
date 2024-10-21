using Microsoft.EntityFrameworkCore;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Abstractions;
using Todo.Persistence.Database;

namespace Todo.Persistence.Repositories
{
    public sealed class UserRepository(TodoDbContext context) : IUserRepository
    {
       
        public async Task<bool> ComparePasswordAsync(string password)
        {
            return await context.ApplicationUsers.FirstOrDefaultAsync(u => u.Password == password) != null;
        }

        public async Task<ApplicationUser> CreateAsync(ApplicationUser user)
        {
            await context.ApplicationUsers.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(Guid userid)
        {
            var user = await context.ApplicationUsers.FindAsync(userid);
            if(user == null)  return false;
            context.ApplicationUsers.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<ApplicationUser?> FindByEmail(string email)
        {
           return await context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser?> FindById(Guid id)
        {
            return await context.ApplicationUsers.FirstOrDefaultAsync(u => u.ApplicationUserId == id);
        }

        public async Task<ApplicationUser?> FindByUserName(string username)
        {
            return await context.ApplicationUsers.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IList<ApplicationUser>> GetAllAsync()
        {
            return await context.ApplicationUsers.ToListAsync();
            
        }

        public async Task<bool> IsActive(Guid userId)
        {
            return await context.ApplicationUsers.AllAsync(u => u.ApplicationUserId == userId);
        }

        public async Task<bool> UpdateAsync(ApplicationUser todo)
        {
           var user = await context.ApplicationUsers.FindAsync(todo.ApplicationUserId);
            if (user != null)
            {
                context.ApplicationUsers.Update(user);
                await context.SaveChangesAsync();             
            }
            return true;
        }
    }
}
