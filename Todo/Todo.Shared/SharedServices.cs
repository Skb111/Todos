using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Shared.Exceptions.Handler;

namespace Todo.Shared
{
    public static class SharedServices
    {
        public static IServiceCollection AddSharedService(this IServiceCollection services)
        {
            services.AddExceptionHandler<TodoExceptionHandler>();

            services.AddProblemDetails();


            return services;

        }
    }
}
