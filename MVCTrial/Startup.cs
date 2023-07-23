using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCTrial.BookRepositary;
using MVCTrial.Data;
using MVCTrial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MVCTrial.Helper;

namespace MVCTrial
{
    public class Startup
    {
        private readonly IConfiguration conobj;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            conobj = configuration;
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

            services.AddAuthorization();

            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<Context>(options=>options.UseSqlServer("Server=.;Database=bookstore;Integrated Security=True;"));
            services.AddDbContext<Context>(options => options.UseSqlServer
            (conobj.GetConnectionString("DefaultConnection")
            ));

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>();

            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();



            // for congigure password customwise
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequiredLength=8

            //});


            //To restrict a user,without email confirm he will not login
            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;

            });




            services.AddScoped<IRepositaryDemo,RepositaryDemo>();

            services.AddScoped<ILanRepositary, LanRepositary>();

           
            services.AddScoped<IAccountRepositary, AccountRepositary>();

            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, MyCustomClaim>();
            services.AddScoped<IMyCustomSevices, MyCustomSevices>();
            services.AddScoped<IMyCustomEmailService, MyCustomEmailService>();
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
                app.UseExceptionHandler("/Home/Error");
            }

            //ConfigureAuth();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            // app.UseAuthorization();
            

            //app.UseRouting();
            //app.UseEndpoints();

            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/");
                // template: "{controller=Home}/{action=Index}/{id?}");
                //template: "{action=Index}/{controller=Home}/{id?}");

                routes.MapRoute(
                    name: "MyArea",
                    template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
                
            });


            
            //app.UseAuthorization();
        }

      
    }
}
