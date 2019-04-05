﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MapaDaForca.Data.Data;
using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace MapaDaForca
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

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<MapaDaForcaDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<MapaDaForcaDbContext>()
            //    .AddEntityFrameworkStores<MapaDaForcaDbContext>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);




            services.AddTransient<IBatalhaoStore, BatalhaoStore>();
            services.AddTransient<IBombeiroStore, BombeiroStore>();
            services.AddTransient<IBombeiroFuncaoStore, BombeiroFuncaoStore>();
            services.AddTransient<ICompanhiaStore, CompanhiaStore>();
            services.AddTransient<IQuartelStore, QuartelStore>();
            services.AddTransient<IQuartelViaturaStore, QuartelViaturaStore>();
            services.AddTransient<IEscalaTipoStore, EscalaTipoStore>();
            services.AddTransient<IFuncaoStore, FuncaoStore>();
            services.AddTransient<IPostoStore, PostoStore>();
            services.AddTransient<IQuartelStore, QuartelStore>();
            services.AddTransient<IViaturaStore, ViaturaStore>();
            services.AddTransient<IViaturaTipoStore, ViaturaTipoStore>();
            services.AddTransient<IViaturaTipoFuncaoStore, ViaturaTipoFuncaoStore>();

            services.AddTransient<IBatalhaoRepository, BatalhaoRepository>();
            services.AddTransient<IBombeiroFuncaoRepository, BombeiroFuncaoRepository>();
            services.AddTransient<IBombeiroRepository, BombeiroRepository>();
            services.AddTransient<ICompanhiaRepository, CompanhiaRepository>();
            //services.AddTransient<IQuartelRepository, QuartelRepository>();
            services.AddTransient<IEscalaTipoRepository, EscalaTipoRepository>();
            services.AddTransient<IFuncaoRepository, FuncaoRepository>();
            services.AddTransient<IPostoRepository, PostoRepository>();
            services.AddTransient<IQuartelRepository, QuartelRepository>();
            services.AddTransient<IQuartelViaturaRepository, QuartelViaturaRepository>();
            services.AddTransient<IViaturaRepository, ViaturaRepository>();
            services.AddTransient<IViaturaTipoRepository, ViaturaTipoRepository>();
            services.AddTransient<IViaturaTipoFuncaoRepository, ViaturaTipoFuncaoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseAuthentication();

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            var cultureInfo = new CultureInfo("pt-PT");

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(cultureInfo),
                SupportedCultures = new List<CultureInfo> { cultureInfo },
                SupportedUICultures = new List<CultureInfo> { cultureInfo }
            });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}