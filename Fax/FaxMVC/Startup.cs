using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core;
using Microsoft.EntityFrameworkCore;
using Unity;
using Application.UserServices;
using System.Web.Mvc;
using Unity.Mvc5;

namespace FaxMVC
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
            services.AddScoped<IUserAppService, UserAppService>();
            //services.AddDbContext<FaxDbContext>(cfg =>
            //{
            //    cfg.UseSqlServer(Configuration.GetConnectionString("CoreConfigurationString"));
            //}
            //    );
            services.AddDbContext<FaxDbContext>(cfg =>
            {
                cfg.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=Faksistent; Trusted_Connection=True;");
            }
                );
            //var container = new UnityContainer();
            //container.RegisterType<IUserAppService, UserAppService>();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
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
