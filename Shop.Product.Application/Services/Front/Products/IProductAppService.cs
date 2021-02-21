using Shop.Product.Application.Services.Front.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Product.Application.Services.Front.Products
{
    public interface IProductAppService
    {
        IList<LeftHotProductOutput> LeftHotProducts(int size = 10);

        IList<LeftHotProductOutput> HotProducts(int size = 10);

        IList<LeftHotProductOutput> NewProducts(int size = 10);

        IList<LeftHotProductOutput> SpecialPriceProducts(int size = 10);
    }
}
