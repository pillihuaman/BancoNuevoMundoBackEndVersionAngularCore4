using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WU.Compras.Publicidad.PE.Wallet.Data;
using WU.Compras.Publicidad.PE.Wallet.Models;
using WU.Compras.Publicidad.PE.Wallet.Services;
using WU.Compras.Publicidad.PE.Wallet.Models.Repository;
using WU.Compras.Publicidad.PE.Wallet.Models.Abstract;
using WU.Compras.Publicidad.PE.Wallet.Config;
using WU.Compras.Publicidad.PE.Wallet.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;

namespace WU.Compras.Publicidad.PE.Wallet
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            
            if (env.IsDevelopment())
                                                       {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddOptions();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionStrings"));
            services.Configure<EmailConfig>(Configuration.GetSection("Email"));
            services.Configure<URLApiPath>(Configuration.GetSection("URLAPI"));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors(options => 
            { options.AddPolicy("Corspolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().DisallowCredentials()); });
            services.AddMvc
                (
                optionsca=>
                {
                    optionsca.CacheProfiles.Add("CacheDuration",
                        new CacheProfile() { Duration = 1700, Location = ResponseCacheLocation.Any });
               } );
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Agregamos autotizaciones para los objetos del sistema
            services.AddAuthorization(options => options.AddPolicy("AllowedCreated", policy => policy.RequireRole("ADMINISTRADOR")));
            services.AddAuthorization(options => options.AddPolicy("AllowedCreated", policy => policy.RequireRole("CLIENTE")));
            //services.AddAuthorization(options => options.AddPolicy("AlllowView", policy => policy.RequireRole("ADMINISTRADOR")));
            //services.AddAuthorization(options => options.AddPolicy("AlllowView", policy => policy.RequireRole("ANONYMUS")));
            //services.AddAuthorization(options => options.AddPolicy("AlllowView", policy => policy.RequireRole("CLIENTE")));
            services.AddTransient<IEmailService, EmailServiceRepositorio>();
            services.AddTransient<IAfilicion, AfiliaRepositorio>();
            services.AddTransient<ICuenta, CuentaRepositorio>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<IProducto, ProductoRepositorio>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IFotos, FotosRepositorio>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<UtilServices>();
            services.AddTransient<LoginViewComponent>();
              
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();
            app.UseSession();
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse=(contexnt)=>
                {
                    var head = contexnt.Context.Response.GetTypedHeaders();
                    head.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        MaxAge = TimeSpan.FromSeconds(120)

                    };

                }
            });


            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseCors("Corspolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            }
            );

            //app.Run(context => {
            //    var status = Configuration["status"];
            //    var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //    context.Response.WriteAsync("Default Connection: " + connectionString);
            //    context.Response.WriteAsync("<br/>");
            //    return context.Response.WriteAsync("Status: " + status);
            //});
        }
    }
}
