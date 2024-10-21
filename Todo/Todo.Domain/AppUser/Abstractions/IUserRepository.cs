using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;
using Todo.Domain.Todo.Entities;

namespace Todo.Domain.Todo.Abstractions
{
    public interface IUserRepository
    {
        Task<IList<ApplicationUser>> GetAllAsync();
         
        Task<ApplicationUser> CreateAsync(ApplicationUser user);

        Task<ApplicationUser?> FindByEmail(string email);

        Task<ApplicationUser?> FindById(Guid id);

        Task<ApplicationUser?> FindByUserName(string username);

        Task<bool> ComparePasswordAsync(string password);

        Task<bool> IsActive(Guid userId);

        Task<bool> UpdateAsync(ApplicationUser todo);

        Task<bool> DeleteAsync(Guid userid);
    }
}
