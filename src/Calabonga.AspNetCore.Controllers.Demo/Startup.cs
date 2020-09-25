using AutoMapper;
using Calabonga.AspNetCore.Controllers.Demo.Data;
using Calabonga.AspNetCore.Controllers.Extensions;
using Calabonga.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calabonga.AspNetCore.Controllers.Demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(nameof(ApplicationDbContext)));
            });
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddCommandAndQueries(typeof(Startup).Assembly);
            services.AddUnitOfWork<ApplicationDbContext>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
