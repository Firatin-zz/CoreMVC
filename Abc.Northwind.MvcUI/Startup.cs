using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.Entitframework;
using Abc.Northwind.MvcUI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Abc.Northwind.MvcUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();//Dependency injection yapısı geregi yapılandırma yapıyoruz. Eğer senden IProductService istersek, sen ProductManager örnegi oluşturup newleyerek ver
            services.AddScoped<IProductDal, EfProductDal>();//eğer senden IProductDal istenirse, sen EfProductDal gönder çünkü EF Orm ile çalışacağız. Böylece gerektiğinde farklı bir framework kullanacksak burdan değiştirerek kolayca yapabilir başka yerlerde değişiklik yapmaya gerek kalmaz.




            //----Category için------
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {       
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//hata yönetimi
            }
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);
            app.UseMvcWithDefaultRoute();//default sayfası için routing
        }
    }
}
