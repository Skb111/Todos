using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Todo.Entities
{
    public enum TodoStatus
    {
        New = 1,
        Ongoing = 2,
        Completed = 3,
        Canceled = 4,
    }
}
