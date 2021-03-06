using MhwLoadoutCreator.MhwDbApiAccess;
using MhwLoadoutCreator.MhwDbApiAccess.Abstract;
using MhwLoadoutCreator.Models.Armor;
using MhwLoadoutCreator.Models.Monster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace MhwLoadoutCreator
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<HttpClient>(new HttpClient() { BaseAddress = new Uri("http://mhw-db.com/") });
            services.AddSingleton<IMhwDbApiHandler<Monster, Monsters>, MhwDbApiMonsterHandler>();
            services.AddSingleton<IMhwDbApiHandler<Armor, Armors>, MhwDbApiArmorHandler>();
            services.AddSingleton<IMhwDbApiMapper, MhwDbApiMapper>();
            services.AddSingleton<IMhwDbApiClient, MhwDbApiClient>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id}",
                    defaults: new { controller = "Armor", action = "Index", id = UrlParameter.Optional }
                );
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });
        }
    }
}
