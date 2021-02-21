using System;
using System.Data;
using Autofac;
using Autofac.Annotation;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using Shop.Product.Application.Services.Manager.Infrastructure;
using Shop.Product.Infrastructure;
using Steeltoe.Discovery.Client;
using Utility;
using Utility.AspNetCore;
using Utility.AspNetCore.Extensions;
using Utility.Domain.Uow;
using Utility.Ef;
using Utility.Ef.Uow;
using Utility.Infrastructure;

namespace Shop.Product.Api
{
    /// <summary>
    /// Internal Server Error /swagger/V1/swagger.json
    /// 不知道 啥 原因 需要用 源码 调试
    /// </summary>
    public class Startup: BaseHostStart
    {
        public Startup(IConfiguration configuration):base(configuration)
        {
                 SwaggerTitle = "Shop.Product.Api";
            Title = "Shop.Product.Api";
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            //框架分装死了 怎么 获取 IContainer  Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory
            //https://www.cnblogs.com/shengfan/p/13884978.html
            services.AddSingleton<Utility.Ioc.IIocManager>(Utility.Ioc.AutofacIocManager.Instance);
            services.AddSingleton<IObjectModelValidator, NullObjectModelValidator>();
            //// If using Kestrel:
            //services.Configure<KestrelServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});

            //// If using IIS:
            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});
            //services.AddMemoryCache(options => {
            //    options.ExpirationScanFrequency = TimeSpan.FromHours(2);
            //});
            services.AddSingleton<IMediator, NoMediator>();
            AutoMapperHelper.Load(services);
            services.AddSingleton<Utility.Cache.ICacheContent, Utility.Cache.NetCoreCache>();

            string mySqlConnectionString = Configuration.GetConnectionString($"{DbConfig.Flag}ConnectionString");
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
           
            services.UseEf<ProductDbContext>(mySqlConnectionString,"",DbConfig.Flag,false);
            services.AddScoped<IUnitWork, EfUnitWork>();
            //An exception was thrown while activating
            //Shop.Product.Api.Front.CatalogController -> Shop.Product.Application.Services.Front.Catalogs.CatalogDapperAppService
            //-> λ:System.Data.IDbConnection
            //services.AddScoped(it => it.GetRequiredService<EfUnitWork>().Connection);
            services.AddScoped<IDbConnection>(it => new MySql.Data.MySqlClient.MySqlConnection(mySqlConnectionString));
            //  services.UseHealthCheck(mySqlConnectionString, "ShopProduct",DbConfig.Flag);
            //base.CustomConfigureServices(services);
            //var builder = GetContainerBuilder();
            //builder.Populate(services);
            //return new AutofacServiceProvider(builder.Build());
        }
        //protected override ContainerBuilder GetContainerBuilder()
        //{
        //    ContainerBuilder builder = new ContainerBuilder();
        //    ConfigureContainer(builder);
        //    return base.GetContainerBuilder();
        //}
        public  override void ConfigureContainer(ContainerBuilder builder)
        {
            //Utility.Ioc.AutofacIocManager.Instance.Builder = builder;
            builder.RegisterModule(new Product.Infrastructure.AutofacModules.InfrastructureModule());
            builder.RegisterModule(new Product.Application.Services.Manager.AutofacModules.ApplicationModule(""));
            //base.ConfigureContainer(builder);
        }

        protected override void Use(IApplicationBuilder app)
        {
            //app.UseHealthChecks("/liveness", new HealthCheckOptions
            //{
            //    Predicate = r => r.Name.Contains("self")
            //});

            //app.UseHealthChecks("/hc", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            base.Use(app);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });
        //}
    }
}
