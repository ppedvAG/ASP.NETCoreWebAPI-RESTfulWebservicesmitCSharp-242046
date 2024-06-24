

using BusinessLogic.Contracts;
using BusinessLogic.Services;
using System.Text.Json.Serialization;

namespace M004_MovieDbApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AddServies(builder.Services);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                // Enums in Datenmodellen als Text statt Integers ausgeben indem wir diese Json Options verwenden
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void AddServies(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
