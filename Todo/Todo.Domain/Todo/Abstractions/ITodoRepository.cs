using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Entities;

namespace Todo.Domain.Todo.Abstractions
{
    public interface ITodoRepository
    {
        Task<IList<UserTodo>> GetAllAsync(Guid userId);

        Task<UserTodo> CreateAsync(UserTodo todo);

        Task<bool> UpdateAsync(UserTodo todo);

        Task<bool> DeleteAsync(Guid todoId, Guid userid);
    }
}
