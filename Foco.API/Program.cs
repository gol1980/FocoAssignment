using Foco.API.Entities;
using Foco.API.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foco.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                    if (!context.Sites.Any())
                    {
                        context.Sites.AddRange(
                            new List<Site>
                            {
                                new Site
                                {
                                     CreatedDate = DateTime.Now,
                                    Location = "Holon",
                                },
                                  new Site
                                {
                                    CreatedDate = DateTime.Now,
                                    Location = "Tel Aviv",
                                },
                            });
                        context.SaveChanges();
                    }
                    if (!context.Persons.Any())
                    {
                        context.Persons.AddRange(
                            new List<Person>
                            {
                                new Person
                                {
                                    SiteId = 1,
                                    Tz = "123456",
                                    PhoneNumber = "0555555555",
                                    DateOfBirth = new DateTime(1990 , 1, 1),
                                    FirstName = "Yosi",
                                    LastName = "Haim",
                                    QueueNumber = 1,
                                    CreatedDate = DateTime.Now
                                },
                                new Person
                                {
                                    SiteId = 1,
                                    Tz = "123457",
                                    PhoneNumber = "0555555557",
                                    DateOfBirth = new DateTime(1997 , 1, 1),
                                    FirstName = "Eli",
                                    LastName = "Moshe",
                                    QueueNumber = 2,
                                    CreatedDate = DateTime.Now.AddMinutes(20)
                                },
                                new Person
                                {
                                    SiteId = 1,
                                    Tz = "123459",
                                    PhoneNumber = "0555555559",
                                    DateOfBirth = new DateTime(1995 , 1, 1),
                                    FirstName = "Yaniv",
                                    LastName = "Lior",
                                    QueueNumber = 3,
                                    CreatedDate = DateTime.Now.AddMinutes(40)
                                }
                            });
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
