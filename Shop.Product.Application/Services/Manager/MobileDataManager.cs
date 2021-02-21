using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Api.Application.Manager
{
    public class MobileDataManager
    {
        public static void LoadData()
        {
            ImageEntity imageEntity = new ImageEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Path= "c3.png"
            };
            CatalogEntity catalogEntity = new CatalogEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Flag = CatalogFlag.MobileNav,
                Name= "环球美食",
                ImageId=imageEntity.Id
            };


            imageEntity = new ImageEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Path = "c5.png"
            };
            catalogEntity = new CatalogEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Flag = CatalogFlag.MobileNav,
                Name = "个护美妆",
                ImageId = imageEntity.Id
            };

            imageEntity = new ImageEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Path = "c6.png"
            };
            catalogEntity = new CatalogEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Flag = CatalogFlag.MobileNav,
                Name = "营养保健",
                ImageId = imageEntity.Id
            };

            imageEntity = new ImageEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Path = "c7.png"
            };
            catalogEntity = new CatalogEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Flag = CatalogFlag.MobileNav,
                Name = "家居厨卫",
                ImageId = imageEntity.Id
            };

            imageEntity = new ImageEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Path = "c8.png"
            };
            catalogEntity = new CatalogEntity()
            {
                Id = Guid.NewGuid().ToString("N"),
                CreationTime = DateTime.Now,
                Flag = CatalogFlag.MobileNav,
                Name = "速食生鲜",
                ImageId = imageEntity.Id
            };
        }
    }
}
