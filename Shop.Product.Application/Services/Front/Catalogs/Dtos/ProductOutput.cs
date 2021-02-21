using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Front.Catalogs.Dtos
{
    /// <summary>
    /// 用户界面 查询 菜单  热销 前 3 商品
    /// </summary>
    //[AutoMap(typeof(ProductEntity))]
    public class ProductOutput
    {
        /// <summary>
        /// 主键 
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
    }
}
