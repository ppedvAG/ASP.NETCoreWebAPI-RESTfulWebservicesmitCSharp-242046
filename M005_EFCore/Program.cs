
using BusinessLogic;
using BusinessLogic.Contracts;
using BusinessLogic.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace M005_EFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                // Enums in Datenmodellen als Text statt Integers ausgeben indem wir diese Json Options verwenden
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            }); ;

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<WebApiDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            builder.Services.AddTransient<IVehicleService, VehicleService>();

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
