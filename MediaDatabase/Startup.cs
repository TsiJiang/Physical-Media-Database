using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediaDatabase.Models;


namespace MediaDatabase
{
    public class Startup
    {
        private IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration
                                                    .GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository,
                      EfUserRepository>();

            services.AddScoped<IMediaEntryRepository,
                      EfMediaEntryRepository>();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{controller=MediaEntry}/{action=Index}/User={userId:int}");

                endpoints.MapControllerRoute(
                    name:null,
                    pattern:"{controller=MediaEntry}/{action=Index}/{userId}/{id:int?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{userId:int?}");
            });
        }
    }
}
