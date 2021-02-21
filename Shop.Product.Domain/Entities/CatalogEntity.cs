using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
//using Utility.Domain.Entities;

namespace Shop.Product.Domain.Entities
{
	/// <summary>
	/// 分类
	/// </summary>
    [Table("t_catalog")]
    public class CatalogEntity:BaseEntity
    {
		/// <summary>
		/// 表名 
		/// </summary>
		public const string TableName = "t_catalog";
		/// <summary>
		/// 名称
		/// </summary>
		[Column( "name")]
		[StringLength(20)]
		public virtual string Name { get; set; }
		/// <summary>
		/// 编码
		/// </summary>
		[Column("code")]
		[StringLength(50)]
		public virtual string Code { get; set; }
		/// <summary>
		/// 排序 
		/// </summary>
		[Column("orders")]
		public virtual int Orders { get; set; }
		/// <summary>
		/// 父 编号
		/// </summary>
		[Column("pid")]
		[StringLength(36)]
		public virtual string Pid { get; set; }
		/// <summary>
		/// 底部导航 链接
		/// </summary>
		[Column("link")]
		[StringLength(100)]
		public virtual string Link { get; set; }
		/// <summary>
		/// 底部导航 链接 跳转方式
		/// </summary>
		[Column("target")]
		[StringLength(10)]
		public virtual string Target { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		[Column("description")]
		[StringLength(500)]
		public virtual string Description { get; set; }


		/// <summary>
		///  1 菜单 (显示导航)  2 二级 菜单 3 底部导航
		/// </summary>
		[Column("flag")]
		public virtual CatalogFlag Flag { get; set; }
		/// <summary>
		/// 父 编号
		/// </summary>
		[Column("image_id")]
		[StringLength(36)]
		public virtual string ImageId { get; set; }

		/// <summary>
		/// 不使用外键
		/// </summary>
		[NotMapped]
		public virtual List<CatalogEntity> Catalogs { get; set; }
		/// <summary>
		/// 不使用外键
		/// </summary>
		[NotMapped]
		public virtual List<CatalogAttribueEntity> CatalogAttribues { get; set; }
		/// <summary>
		/// 不使用外键
		/// </summary>
		[NotMapped]
		public virtual List<ProductEntity> Products { get; set; }

		public virtual void Update(CatalogEntity catalogEntity)
		{
			base.Update(catalogEntity);
			this.Name = catalogEntity.Name;
			this.Code = catalogEntity.Code;
			this.Orders = catalogEntity.Orders;
			this.Pid = catalogEntity.Pid;
			this.Flag = catalogEntity.Flag;
		}
	}
}