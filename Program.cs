using IzySickAPI.Data;
using IzySickAPI.Interfaces;
using IzySickAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Builder;

namespace IzySickAPI
{
    public class Program
    {
     
        public static  void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<Seed>();
            builder.Services.AddScoped<IDocteurRepository, DocteurRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            builder.Services.AddScoped<IMedicamentRepository, MedicamentRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultconnection")); 
            }
            );

            var app = builder.Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
                SeedData(app);

            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<Seed>();
                    service.SeedDataContext();
                }
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

           
            var host = new WebHostBuilder()
             .UseKestrel(options =>
             {
                 options.Listen(IPAddress.Parse("192.168.174.142"), 8080);//192.168.56.1//192.168.43.194(liantsoa)  //192.168.88.203(haingo) //192.168.174.142(toky)
             })
             .Configure(app =>
             {
                 // Configuration du middleware ici
                 app.UseSwagger();
                 app.UseSwaggerUI();

                 app.UseAuthorization();
                 app.UseHttpsRedirection();
                 app.UseAuthentication();
             })
             .Build();

            app.MapControllers();
            app.Run();
        }
    }
}