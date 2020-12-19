using Ecommerce.WebUI.Middlewares;
using EStore.Business.Abstract;
using EStore.Business.Concrete;
using EStore.DataAccess.Abstract;
using EStore.DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
            app.UseMvc(routes =>
            {
                    routes.MapRoute(
                    name: "default",
                     template: "{controller=EStore}/{action=Index}/{id?}"
                    );

                routes.MapRoute(
                    name: "urunler",
                    template:"urunler/{category?}",
                    defaults:new {controller="EStore",action="Urunler"}
                    );

                
            });

        }
    }

}
