using IS413_Amazon_A5_ZS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Amazon_A5_ZS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Add context and connect with database
            //refers to the appsettings.json file for instructions
            //Also creates a dynamic database file path by putting in the project's current file directory path into the connection string
            services.AddDbContext<BookDBContext>(options =>
               {
                   string path = Directory.GetCurrentDirectory();

                   //Outputs database to the project's path location by replacing [DirectoryHere] in the appsettings.json with the project's path location
                   options.UseSqlServer(Configuration["ConnectionStrings:BookInfoConnection"].Replace("[DirectoryHere]",path));
               });

            services.AddScoped<IBookRepository, EFBookRepository>();

            
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

            //Customize the displayed URL to be URL/P1, URL/P2, etc.
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    "pagination", 
                    "/P{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
            });

            //Makes sure that database is populated
            SeedData.EnsurePopulated(app);
        }
    }
}
