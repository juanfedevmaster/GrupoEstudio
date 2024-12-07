
using Biblioteca.AccesoDatos;
using Biblioteca.AccesoDatos.Interfaces;
using Biblioteca.Entidades.Infraestructura.Options;
using System.Configuration;

namespace Bibliotecta.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers().AddNewtonsoftJson();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Inyección de Dependencias
            builder.Services.AddScoped<IDatabaseService, BibliotecaRepo>();

            // Patron IOptions
            builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("DatabaseOptions"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
