using AutoMapper;
using Shop.Product.Application.Services.Manager.Dtos;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.CatalogAttributes.Dtos
{
    [AutoMap(typeof(CatalogAttribueEntity))]
    public class CatalogAttributeOutput : BasetOutput
	{
		/// <summary>
		/// 名称
		/// </summary>
		public virtual string Name { get; set; }
		/// <summary>
		/// 编码
		/// </summary>
		public virtual string CatalogId { get; set; }
		/// <summary>
		/// 排序  最好不要用 sql  关键词
		/// </summary>
		public virtual int Order1 { get; set; }
		/// <summary>
		/// 父 编号
		/// </summary>
		public virtual string Pid { get; set; }
	}
}
