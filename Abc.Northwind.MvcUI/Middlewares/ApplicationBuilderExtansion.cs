using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.MvcUI.Middlewares
{
    public static class ApplicationBuilderExtansion
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            //Kendi costum middleware'mizi oluşturduk. Node_modules isteği geldiğinde provider tanımını göndericez.

            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;

            app.UseStaticFiles(options);

            return app;
        }
    }
}
