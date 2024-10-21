using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.AppUser.Models
{
    public record UserRequestModelUpdate(Guid ApplicationUserId, string Email, string Username, string Password);

}
