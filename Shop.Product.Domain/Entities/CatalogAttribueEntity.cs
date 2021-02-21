using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
//using Utility.Domain.Entities;

namespace Shop.Product.Domain.Entities
{
	/// <summary>
	/// 分类 属性
	/// </summary>
	[Table("t_catalog_attribue")]
	public class CatalogAttribueEntity : BaseEntity
    {
		/// <summary>
		/// 表名 
		/// </summary>
		public const string TableName = "t_catalog_attribue";
		/// <summary>
		/// 名称
		/// </summary>
		[Column("name")]
		[StringLength(20)]
		public virtual string Name { get; set; }
		/// <summary>
		/// 编码
		/// </summary>
		[Column("catalog_id")]
		[StringLength(36)]
		public virtual string CatalogId { get; set; }
		/// <summary>
		/// 排序  最好不要用 sql  关键词
		/// </summary>
		[Column("order1")]
		public virtual int Order1 { get; set; }
		/// <summary>
		/// 父 编号
		/// </summary>
		[Column("pid")]
		[StringLength(36)]
		public virtual string Pid { get; set; }

		/// <summary>
		/// 不使用外键
		/// </summary>
		[NotMapped]
		public virtual List<ProductAttribueEntity> ProductAttribues { get; set; }
	}
}
