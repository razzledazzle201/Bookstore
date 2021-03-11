using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; } //set allows us to chage config

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]); //connect to MS SQL from the appsettings.json
            });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            services.AddRazorPages(); // bring razor pages into the project

            services.AddMemoryCache(); // add sessions to collect data fo a user session
            services.AddSession(); // session part 1 / 2

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp)); // specifies that the same object should be used to satisfy related requests for Cart instances
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession(); // session part 2 / 2

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/P{P:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "/P{P:int}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute("pagination",
                    "/P{P}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapDefaultControllerRoute(); // make the url route look better

                endpoints.MapRazorPages(); // handle razor page routing

                // previous old code
                //name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app); //static method

        }
    }
}