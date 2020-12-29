using Ecommerce.WebUI.Middlewares;
using EStore.Business.Abstract;
using EStore.Business.Concrete;
using EStore.DataAccess.Abstract;
using EStore.DataAccess.Concrete.EfCore;
using EStore.WebUI.IDentity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI
{
    public class Startup
    {
        public IConfiguration  Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IDentityDb>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IDentityDb>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LoginPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/Accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(90);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".EStore.Cookie"
                };
            });
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddMvc()
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            //app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            app.CustomStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                    routes.MapRoute(
                    name: "AdminProducts",
                    template: "Admin/Products",
                    defaults: new {controller="Admin",action= "ListProducts" }
                   );
                routes.MapRoute(
                 name: "AdminProducts",
                 template: "Admin/Index",
                 defaults: new { controller = "Admin", action = "ListProducts" }
                );

                routes.MapRoute(
                   name: "AdminProducts",
                   template: "Admin/Products/{id?}",
                   defaults: new { controller = "Admin", action = "EditProduct" }
                  );


                routes.MapRoute(
                    name: "default",
                     template: "{controller=EStore}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                    name: "urunler",
                    template:"urunler/{category?}",
                    defaults:new {controller="EStore",action="Urunler"}
                    );

                routes.MapRoute(
                name: "areas",
                template: "{controller=Home}/{action=Index}/{id?}"
                          );
            });

        }
    }

}
