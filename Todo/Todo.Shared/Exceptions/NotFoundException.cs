using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Shared.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException(string message):base(message) {}


        public NotFoundException(string name, object key) : base($"Entity with {name} cannot be found") { }
    }
}
