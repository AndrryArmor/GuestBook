using GuestBook.Application.Repositories;
using GuestBook.Application.Services;
using GuestBook.Persistence.Contexts;
using GuestBook.Persistence.Repositories;

namespace GuestBook.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IGuestBookService, GuestBookService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserCommentRepository, UserCommentRepository>();
            builder.Services.AddSqlServer<GuestBookDbContext>(builder.Configuration.GetConnectionString("GuestBook"));

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:8080")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}