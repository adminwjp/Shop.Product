using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Products.Dtos
{
	/// <summary>
	/// 查询 产品  
	/// </summary>
	[AutoMap(typeof(ProductEntity))]
	public class ProductInput
	{
		/// <summary>
		/// 目录分类 id
		/// </summary>
		public virtual string CatalogID { get; set; }
		/// <summary>
		/// 出售数量
		/// </summary>
		public virtual int Sales { get; set; }
		/// <summary>
		/// 库存
		/// </summary>
		public virtual int Stock { get; set; }
		/// <summary>
		/// 关键字
		/// </summary>
		public virtual string Keywords { get; set; }
		/// <summary>
		/// 评分
		/// </summary>
		public virtual int Score { get; set; }
		/// <summary>
		/// 热销 数量
		/// </summary>
		public virtual int Hit { get; set; }
		/// <summary>
		/// 标题
		/// </summary>
		public virtual string Title { get; set; }
		/// <summary>
		/// 价格
		/// </summary>
		public virtual decimal? Price { get; set; }
		/// <summary>
		/// 活动 id
		/// </summary>
		public virtual string ActivityID { get; set; }
		/// <summary>
		/// 状态 
		/// </summary>
		public virtual int Status { get; set; }
		/// <summary>
		/// 产品 显示 html
		/// </summary>
		public virtual string ProductHTML { get; set; }
		/// <summary>
		/// 是否 显示 新闻
		/// </summary>
		public virtual string IsNew { get; set; }
		/// <summary>
		/// 介绍
		/// </summary>
		public virtual string Introduce { get; set; }
		/// <summary>
		/// 搜索关键词
		/// </summary>
		public virtual string SearchKey { get; set; }
		/// <summary>
		/// 素材
		/// </summary>
		public virtual string Images { get; set; }
		/// <summary>
		/// 当前价格
		/// </summary>
		public virtual decimal? MakePrice { get; set; }
		/// <summary>
		/// 最大价格
		/// </summary>
		public virtual string MaxPicture { get; set; }
		/// <summary>
		/// 单价 $ r
		/// </summary>
		public virtual string Unit { get; set; }
		/// <summary>
		/// 素材
		/// </summary>
		public virtual string Picture { get; set; }
		/// <summary>
		/// 名称
		/// </summary>
		public virtual string Name { get; set; }
		/// <summary>
		/// 是否出售
		/// </summary>
		public virtual string Sale { get; set; }
		/// <summary>
		/// 礼物 id
		/// </summary>
		public virtual string GiftID { get; set; }
	}
}
