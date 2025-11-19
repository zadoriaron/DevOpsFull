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
                options.UseSqlServer(builder.Configuration["db:conn"]);
            });

            builder.Services.AddCors();

            if(builder.Environment.IsProduction())
            {
                builder.WebHost.ConfigureKestrel(options =>
                {
                    options.ListenAnyIP(int.Parse(builder.Configuration["settings:port"] ?? "6600"));
                });
            }

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

            app.UseCors(t => t
            .WithOrigins(builder.Configuration["settings:frontend"] ?? "http://localhost:4200")
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod());


            app.MapControllers();

            app.Run();
        }
    }
}
