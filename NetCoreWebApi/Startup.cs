using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Autofac;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using log4net.Repository;
using log4net;
using log4net.Config;
using NetCoreWebApi.Models;
using NetCoreModel.Base;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApi
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

        public static ILoggerRepository logRepository { get; set; }

        private IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var builder = new ContainerBuilder();
            var manager = new ApplicationPartManager();

            manager.ApplicationParts.Add(new AssemblyPart(assembly));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());

            var feature = new ControllerFeature();

            manager.PopulateFeature(feature);

            builder.RegisterType<ApplicationPartManager>().AsSelf().SingleInstance();
            builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            builder.Populate(services);

            builder.RegisterAssemblyTypes(Assembly.Load("NetCoreBLL")).Where(t => t.Name.EndsWith("BLL")).AsImplementedInterfaces();

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                //builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();

            logRepository = LogManager.CreateRepository("NETCoreRepository");
            XmlConfigurator.ConfigureAndWatch(logRepository,new System.IO.FileInfo("Config/log4net.config"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region 跨域
            services.AddCors(options => options.AddPolicy("AllowSameDomain",
                p => p.WithOrigins("http://localhost:33716", "http://c.example.com").AllowAnyMethod().AllowAnyHeader()));
            //services.Configure<MvcOptions>(option=>option.Filters.Add(new CorsAuthorizationFilterFactory("AllowSameDomain")));
            #endregion

            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            //services.AddMvc();
            services.AddControllers();
            services.AddAutoMapper();

            services.Configure<AppSettingsModel>(Configuration.GetSection("AppSettings"));
            services.Configure<ConnectionsModel>(Configuration.GetSection("ConnectionString"));

            return RegisterAutofac(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowSameDomain");//允许跨域
            //app.UseMvc();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints=> {
                endpoints.MapControllers();
            });
            
        }
    }
}
