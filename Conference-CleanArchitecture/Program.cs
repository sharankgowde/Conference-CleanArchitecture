using CustomerApp.Core.Interfaces;
using CustomerApp.Infrastructure.Configuration;
using CustomerApp.Infrastructure.CosmosData;
using CustomerApp.Infrastructure.Logging;
using CustomerApp.Infrastructure.Logging.Onpremise;
using CustomerApp.Infrastructure.SQLData;

namespace Conference_CleanArchitecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IConfigDetails, AppConfiguration>();

            //====================================================== Azure ================================


            builder.Services.AddScoped<ICustomerRepository, CustomerCosmosRepository>();
            builder.Services.AddScoped<ICustomLogger, SerilogLoggerAppInsight>();

            //===================================================== OnPremise ===============================


            //builder.Services.AddScoped<ICustomerRepository, CustomerSQLRepository>();
            //builder.Services.AddScoped<ICustomLogger, SerilogLoggerOnPremise>();

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