using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Product.Application.Services.Front.Products.Dtos
{
    public class LeftHotProductOutput
    {
		public virtual string Id { get; set; }
		/// <summary>
		/// 价格
		/// </summary>
		public virtual decimal? Price { get; set; }
		/// <summary>
		/// 当前价格
		/// </summary>
		public virtual decimal? NowPrice { get; set; }
		/// <summary>
		/// 素材
		/// </summary>
		public virtual string Picture { get; set; }
		/// <summary>
		/// 名称
		/// </summary>
		public virtual string Name { get; set; }
	}
}
