using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Todo.Abstractions;
using Todo.Persistence.Database;
using Todo.Persistence.Repositories;

namespace Todo.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration config) {

            var connection = config.GetConnectionString("TodoConnection");

            services.AddDbContext<TodoDbContext>(option => option.UseSqlServer(connection));


            services.AddValidatorsFromAssembly(Shared.AssemblyReference.Assembly);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITodoRepository, TodoRepository>();
            //services.AddScoped<ITodoRepository, TodoRepository>();

            return services;
        }
    }
}
