using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Spyshop.Domain.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Course.Spyshop.Web
{
    public class Startup
    {
        private IConfigurationRoot configuration = null;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<SpyShopConfig>(configuration.GetSection("SpyShopConfig"));
            services.AddMvc();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "searchById",
                    template: "Search/{id:long}",
                    defaults: new {controller = "Home", action = "SearchById"}
                );
                routes.MapRoute(
                    name: "searchByName",
                    template: "SearchByName/{productName}",
                    defaults: new {controller = "Home", action = "SearchByName"}
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == "/spyshop")
            //        await context.Response.WriteAsync("Spy Shop!");
            //    else
            //        await next.Invoke();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
