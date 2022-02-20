using System;
using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsASP.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tools.Earn;

namespace DesignPatternsASP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));

            // Dependency Injection
            services.AddTransient((factory) =>
            {
                decimal percentage = Configuration.GetSection("MyConfig")
                    .GetValue<decimal>("LocalPercentage");
                return new LocalEarnFactory(percentage);
            });

            services.AddTransient((factory) =>
            {
                decimal percentage = Configuration.GetSection("MyConfig")
                    .GetValue<decimal>("ForeignPercentage");
                decimal extra = Configuration.GetSection("MyConfig")
                    .GetValue<decimal>("Extra");
                return new ForeignEarnFactory(percentage, extra);
            });

            // Design Pattern Repository
            services.AddDbContext<DesignPatternsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
