using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Utility.ObjectMapping;
using Utility.Utils;

namespace Shop.Product.Application.Services.Manager.Infrastructure
{
    public  class AutoMapperHelper
    {
        public static void Load(IServiceCollection services)
        {
            AutoMapperObjectMapper autoMapperObjectMapper = new AutoMapperObjectMapper();
            autoMapperObjectMapper.Init(it => {
                foreach (var module in typeof(AutoMapperHelper).Assembly.Modules)
                {
                    foreach (var type in module.GetTypes())
                    {
                        AutoMapper.AutoMapAttribute autofacMap = AttributeUtils.Get<AutoMapper.AutoMapAttribute>(type.GetCustomAttributes(false));
                        if (autofacMap != null)
                        {
                            it.CreateMap(autofacMap.SourceType, type);
                            it.CreateMap(type, autofacMap.SourceType);
                        }
                    }
                }
            });
            services.AddSingleton<IObjectMapper>(autoMapperObjectMapper);
        }
    }
}
