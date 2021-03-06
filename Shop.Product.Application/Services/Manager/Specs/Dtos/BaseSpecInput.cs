﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Specs.Dtos
{
    /// <summary>
    /// 产品 规格 
    /// </summary>
    public class BaseSpecInput
    {
		/// <summary>
		/// 产品 规格  库存
		/// </summary>
		public virtual string Stock { get; set; }
		/// <summary>
		/// 产品 ID
		/// </summary>
		public virtual string ProductID { get; set; }
		/// <summary>
		/// 该 产品 规格 价格
		/// </summary>
		public virtual decimal? Price { get; set; }
		/// <summary>
		/// 产品 规格 尺寸
		/// </summary>
		public virtual string Size { get; set; }
		/// <summary>
		/// 产品 规格 状态
		/// </summary>
		public virtual string Status { get; set; }
		/// <summary>
		/// 产品 规格 颜色
		/// </summary>
		public virtual string Color { get; set; }
	}
}
