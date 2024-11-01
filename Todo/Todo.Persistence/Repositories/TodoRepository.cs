using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Abstractions;
using Todo.Domain.Todo.Entities;
using Todo.Persistence.Database;

namespace Todo.Persistence.Repositories
{
    public sealed class TodoRepository(TodoDbContext context) : ITodoRepository
    {
        public async Task<UserTodo> CreateAsync(UserTodo todo)
        {
            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool?> DeleteAsync(Guid todoId, Guid userid)
        {
            var todo = await context.Todos.FindAsync(userid);
            if (todo == null) return false;
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<UserTodo?> FindById(Guid id)
        {
            return await context.Todos.FirstOrDefaultAsync(u => u.TodoId == id);
        }

        public async Task<IList<UserTodo>> GetAllAsync()
        {
            return await context.Todos.ToListAsync();
        }

        public async Task<bool> UpdateAsync(UserTodo todo)
        {
            var todos = await context.Todos.FindAsync(todo.TodoId);
            if (todos != null)
            {
                context.Todos.Update(todos);
                await context.SaveChangesAsync();
            }
            return true;
        }
    }
}
