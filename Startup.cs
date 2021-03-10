using IS413_Amazon_A5_ZS.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                   //string path = Directory.GetCurrentDirectory();

                   //Outputs database to the project's path location by replacing [DirectoryHere] in the appsettings.json with the project's path location
                   //options.UseSqlServer(Configuration["ConnectionStrings:BookInfoConnection"].Replace("[DirectoryHere]",path));
                   options.UseSqlite(Configuration["ConnectionStrings:BookInfoConnection"]);

               });

            services.AddScoped<IBookRepository, EFBookRepository>();

            //Add Razor Page funcitonality
            services.AddRazorPages();

            //Add functionality for a saved cart session
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

            //Build for session
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //Customize the displayed URL to be URL/P1, URL/P2, etc.
            app.UseEndpoints(endpoints =>
            {
                //Allow people to navigate to different pages of books that are filtered based on categories
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" }
                    );

                //Allow quick navigation to different pages by only entering the page number as a parameter in the URL
                endpoints.MapControllerRoute("pageNum",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" }
                    );

                //Allow user to type in the desired category in the URL and filter the results
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 }
                    );

                //Allow user to type in the desired page as P1 for page 1, P2 for page 2, etc.
                endpoints.MapControllerRoute(
                    "pagination", 
                    "/P{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            //Makes sure that database is populated
            SeedData.EnsurePopulated(app);
        }
    }
}
