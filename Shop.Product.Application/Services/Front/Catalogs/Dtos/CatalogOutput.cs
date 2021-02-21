using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Front.Catalogs.Dtos
{
    /// <summary>
    /// 用户界面 查询 菜单 
    /// </summary>
    //[AutoMap(typeof(CatalogEntity))]
    public class CatalogOutput: BottomOutput<CatalogOutput>
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        public virtual List<ProductOutput> Products { get; set; }


    }
}
