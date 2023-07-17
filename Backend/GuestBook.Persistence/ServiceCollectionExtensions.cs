using GuestBook.Application.Interfaces.Repositories;
using GuestBook.Domain;
using GuestBook.Persistence.Contexts;
using GuestBook.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBook.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<GuestBookDbContext>(configuration.GetConnectionString("GuestBook"));
            services.AddScoped<IUserCommentRepository, UserCommentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
