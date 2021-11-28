using Abc.Business.Abstract;
using Abc.Business.Concrete;
using Abc.DataAccess.Abstract;
using Abc.DataAccess.Concrete;
using Abc.UI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.UI
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
            services.AddRazorPages();
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddSingleton<ICategoryDal, CategoryDal>();
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSession();
            services.AddDistributedMemoryCache(); //sesonu aktif etmej için
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseSession(); 
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    defaults: "/Product/Index",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
