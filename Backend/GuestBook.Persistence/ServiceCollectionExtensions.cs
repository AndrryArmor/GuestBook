using GuestBook.Application.Repositories;
using GuestBook.Persistence.Contexts;
using GuestBook.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
