using Shop.Product.Application.Services.Front.Catalogs.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Front.Catalogs
{
    public interface ICatalogAppService
    {
        IList<CatalogOutput> Catalogs();
        List<NavgationOutput> NavgationCatalogs();
        IList<BottomOutput> Bottom();
        IList<BottomNavgationOutput> BottomLink();
    }
}
