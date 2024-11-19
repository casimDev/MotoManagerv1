
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotoManager.Application.Extensions;
using MotoManager.Application.Services.DriverService;
using MotoManager.Dtos.Commom;
using MotoManager.Infraestructure.Data;

namespace MotoManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IMotorcycleManagerContext, MotorcycleManagerContext>();
            builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();

            builder.Services.AddDbContext<MotorcycleManagerContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Gerenciamento",
                    Version = "v1"
                });
            });
            builder.Services.AddAutoMapper(typeof(MotoMappingProfile));

            builder.Services.AddMediatRCustom(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
