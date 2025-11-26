using Fragrance_Data;
using Microsoft.EntityFrameworkCore;

namespace DevOpsProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddTransient<FragranceRepository>();

            builder.Services.AddDbContext<DevOpsProjectDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\DevOPsProject;Database=FragranceDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True");
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                    builder.WithOrigins("http://localhost:4200")  // Frontend URL
                           .AllowAnyHeader()
                           .AllowAnyMethod());
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

            app.UseCors("AllowFrontend");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
