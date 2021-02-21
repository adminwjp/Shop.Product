using Autofac;
using Autofac.Annotation;
using System.Reflection;
using Utility.EventBus.Abstractions;

namespace Shop.Product.Infrastructure.AutofacModules
{

    public class InfrastructureModule
        : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // 注册autofac打标签模式
            builder.RegisterTypes(GetType().Assembly.GetExportedTypes()).PropertiesAutowired();
            //如果需要开启支持循环注入
            builder.RegisterModule(new AutofacAnnotationModule(GetType().Assembly).SetAllowCircularDependencies(false));

        }
    }
}
