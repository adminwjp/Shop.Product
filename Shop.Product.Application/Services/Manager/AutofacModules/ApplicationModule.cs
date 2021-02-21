using Autofac;
using Autofac.Annotation;
using Shop.Product.Application.Services.Manager.IntegrationEvents.EventHandling;
using System.Reflection;
using Utility.EventBus.Abstractions;

namespace Shop.Product.Application.Services.Manager.AutofacModules
{

    public class ApplicationModule
        : Utility.Infrastructure.AutofacModules.ApplicationModule
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {


            //builder.RegisterType<RequestManager>()
            //   .As<IRequestManager>()
            //   .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(BaseIntegrationEventHandler<,,>).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
            // 注册autofac打标签模式
            builder.RegisterTypes(GetType().Assembly.GetExportedTypes()).PropertiesAutowired();
            //如果需要开启支持循环注入
            builder.RegisterModule(new AutofacAnnotationModule(GetType().Assembly).SetAllowCircularDependencies(false));
            builder.RegisterBuildCallback(container =>
            {
                Utility.Ioc.AutofacIocManager.Instance.Container = (IContainer)container;
            });
        }
    }
}
