using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Dtos
{
    public class CatalogDto
    {
        public string Label { get; set; }
        public string Value { get; set; }
        public IList<CatalogDto> Children { get; set; }
    }
}
