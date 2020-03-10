using System;
using datingapp.API.Data;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
 
using Microsoft.AspNetCore; 
using Microsoft.AspNetCore.Identity;   

namespace datingapp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateWebHostBuilder(args).Build();
           using(var scope = host.Services.CreateScope())
           {
               var services = scope.ServiceProvider;
               try 
               {
                   var context = services.GetRequiredService<datacontext>();
                   context.Database.Migrate();
                   Seed.SeedUsers(context);
               }
               catch(Exception ex)
               {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex,"An error ocurred during migration");
               }
           }
           host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
