using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Product.Application.Services.Front.Catalogs.Dtos
{
    public class NavgationOutput
    {
        /// <summary>
        /// 主键 
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public virtual string Id { get; set; }

    
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public virtual string Code { get; set; }
    }
}
