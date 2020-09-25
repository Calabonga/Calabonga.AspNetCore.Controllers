using System;
using System.Collections.Generic;

using Calabonga.AspNetCore.Controllers.Demo.Data;
using Calabonga.AspNetCore.Controllers.Demo.Entities;
using Calabonga.UnitOfWork;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calabonga.AspNetCore.Controllers.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //using (var scope = host.Services.CreateScope())
            // {


            // var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
            // context.Database.Migrate();

            //var context = scope.ServiceProvider.GetService<IUnitOfWork>();
            //context.GetRepository<Person>().Insert(new List<Person>
            //{
            //    new Person
            //    {
            //        Id= Guid.Parse("1359c0ce-c941-0d9c-4af7-3dea70a8db7d"),
            //        LastName = "LastName1",
            //        FirstName = "FirstName1",
            //        Addresses = new List<Address>
            //        {
            //            new Address
            //            {
            //                Id = Guid.Parse("bb2945a3-4e78-e1bf-4716-8d5cd0a1165e"),
            //                Content = "Address Content1",
            //                Name = "Home1"
            //            },
            //            new Address
            //            {
            //                Id = Guid.Parse("7a79e449-4580-d49c-477f-02a37f140b9b"),
            //                Content = "Address Content1",
            //                Name = "Work1"
            //            }
            //        }
            //    },
            //    new Person
            //    {
            //        Id= Guid.Parse("f619eca2-8d99-e180-45a5-15c91f80b703"),
            //        LastName = "LastName2",
            //        FirstName = "FirstName2",
            //        Addresses = new List<Address>
            //        {
            //            new Address
            //            {
            //                Id = Guid.Parse("56bc32e3-a390-6d8b-4fcd-0a60baeedf0b"),
            //                Content = "Address Content2",
            //                Name = "Home2"
            //            },
            //            new Address
            //            {
            //                Id = Guid.Parse("b042f748-ab4a-2d87-46cf-0a6fd50ee06f"),
            //                Content = "Address Content2",
            //                Name = "Work2"
            //            }
            //        }
            //    }
            //});
            //context.SaveChanges();
            //}
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
