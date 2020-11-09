using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestProject.Business.Abstract;
using TestProject.Business.Concreate;
using TestProject.Business.DependencyResolvers.Autofac;
using TestProject.Core.Extensions;
using TestProject.Core.Utilities.IoC;
using TestProject.Model;
using TestProject.Repository.Interface;
using TestProject.Repository.Repository;

namespace TestProject.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
                //.AddFluentValidation(option => option.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddDbContext<DatabaseContext>(options => options.UseOracle(Configuration.GetConnectionString("OracleConnStr")));
            //services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MSSQLConnStr")));

            //services.AddMemoryCache();
            //services.AddMvc();

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
