using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.MVCCoreWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asp.MVCCoreWeb
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
              
            });

            //services.Configure<IdentityOptions>(options => {
            //    options.User.RequireUniqueEmail = true;
              
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>(
               
                ).AddEntityFrameworkStores<EmployeeContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
          //  services.AddDbContext<Models.TournamentsContext>();
            services.AddDbContext<Models.EmployeeContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("production")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
                app.UseDeveloperExceptionPage();
                // app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
