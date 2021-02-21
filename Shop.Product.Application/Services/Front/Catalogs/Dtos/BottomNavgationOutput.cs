using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Product.Application.Services.Front.Catalogs.Dtos
{
    public class BottomNavgationOutput
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
		/// 底部导航 链接
		/// </summary>
		public virtual string Link { get; set; }
        /// <summary>
        /// 底部导航 链接 跳转方式
        /// </summary>
        public virtual string Target { get; set; }
    }
}
