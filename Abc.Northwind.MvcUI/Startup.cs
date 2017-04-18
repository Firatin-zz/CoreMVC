using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Abc.Northwind.Business.Concrete;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.DataAccess.Concrete.Entitframework;

namespace Abc.Northwind.MvcUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();//Dependency injection yapısı geregi yapılandırma yapıyoruz. Eğer senden IProductService istersek, sen ProductManagerörnegi oluşturup newleyerek ver
            services.AddScoped<IProductDal, EfProductDal>();//eğer senden IProductDal istenirse, sen EfProductDal gönder çünkü EF Orm ile çalışacağız. Böylece gerektiğinde farklı bir framework kullanacksak burdan değiştirerek kolayca yapabilir başka yerlerde değişiklik yapmaya grek kalmaz.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();//default sayfası için
        }
    }
}
