using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.ProductAttributes.Dtos
{
   public class BaseProductAttributeInput
    {
        /// <summary>
      /// 参数id
      /// </summary>
        public string AttributeId { get; set; }
        /// <summary>
        /// 商品 id
        /// </summary>
        public string ProductId { get; set; }

        public string Value { get; set; }
    }
}
