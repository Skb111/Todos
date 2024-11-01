using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Todo.Models
{
    public record UserTodoRequestModelUpdate(Guid ApplicationUserId, Guid todoId, string Title, string Description);

}
