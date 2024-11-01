using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Todo.Models
{
    public record UserTodoRequestModelId(Guid applicationUserId, Guid todoId);

}
