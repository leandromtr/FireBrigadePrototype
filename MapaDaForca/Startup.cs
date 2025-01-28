using MapaDaForca.Core.Store;
using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;

namespace MapaDaForca
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MapaDaForcaDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MapaDaForcaContextConnection")));

            services.AddIdentity<Bombeiro, IdentityRole>()
                .AddEntityFrameworkStores<MapaDaForcaDbContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddRazorPages();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
                options.LoginPath = new PathString("/Identity/Account/Login");
            });

            services.AddTransient<IBatalhaoStore, BatalhaoStore>();
            services.AddTransient<IBombeiroStore, BombeiroStore>();
            services.AddTransient<IBombeiroFuncaoStore, BombeiroFuncaoStore>();
            services.AddTransient<ICompanhiaStore, CompanhiaStore>();
            services.AddTransient<IEscalaStore, EscalaStore>();
            services.AddTransient<IEscalaTipoStore, EscalaTipoStore>();
            services.AddTransient<IEscalaTurnoStore, EscalaTurnoStore>();
            services.AddTransient<IFuncaoStore, FuncaoStore>();
            services.AddTransient<IPostoStore, PostoStore>();
            services.AddTransient<IQuartelStore, QuartelStore>();
            services.AddTransient<IQuartelStore, QuartelStore>();
            services.AddTransient<IQuartelViaturaStore, QuartelViaturaStore>();
            services.AddTransient<IViaturaStore, ViaturaStore>();
            services.AddTransient<IViaturaTipoStore, ViaturaTipoStore>();
            services.AddTransient<IViaturaTipoFuncaoStore, ViaturaTipoFuncaoStore>();

            services.AddTransient<IBatalhaoRepository, BatalhaoRepository>();
            services.AddTransient<IBombeiroFuncaoRepository, BombeiroFuncaoRepository>();
            services.AddTransient<IBombeiroRepository, BombeiroRepository>();
            services.AddTransient<ICompanhiaRepository, CompanhiaRepository>();
            services.AddTransient<IEscalaRepository, EscalaRepository>();
            services.AddTransient<IEscalaTipoRepository, EscalaTipoRepository>();
            services.AddTransient<IEscalaTurnoRepository, EscalaTurnoRepository>();
            services.AddTransient<IFuncaoRepository, FuncaoRepository>();
            services.AddTransient<IPostoRepository, PostoRepository>();
            services.AddTransient<IQuartelRepository, QuartelRepository>();
            services.AddTransient<IQuartelViaturaRepository, QuartelViaturaRepository>();
            services.AddTransient<IViaturaRepository, ViaturaRepository>();
            services.AddTransient<IViaturaTipoRepository, ViaturaTipoRepository>();
            services.AddTransient<IViaturaTipoFuncaoRepository, ViaturaTipoFuncaoRepository>();
        }

        public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        MapaDaForcaDbContext context,
        UserManager<Bombeiro> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            var cultureInfo = new CultureInfo("pt-PT");
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(cultureInfo),
                SupportedCultures = new List<CultureInfo> { cultureInfo },
                SupportedUICultures = new List<CultureInfo> { cultureInfo }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}