using Autofac.Annotation;
using Shop.Product.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Front.Specs
{
    [Component(typeof(SpecEfAppService), AutofacScope = AutofacScope.InstancePerLifetimeScope)]
    public class SpecEfAppService
    {
        [Autowired]
        private readonly ProductDbContext productDbContext;
        public void Products(string productId)
        {

        }
    }
}
