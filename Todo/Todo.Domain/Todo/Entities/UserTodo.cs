using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.AppUser.Entities;

namespace Todo.Domain.Todo.Entities
{
    public class UserTodo
    {
        public UserTodo(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public Guid TodoId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public Guid UserId { get; set; }
        public TodoStatus Status { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
