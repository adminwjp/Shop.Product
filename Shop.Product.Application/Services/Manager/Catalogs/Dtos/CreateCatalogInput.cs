using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Catalogs.Dtos
{
	[AutoMap(typeof(CatalogEntity))]
	public class CreateCatalogInput//: IValidatableObject
	{
		/// <summary>
		/// 名称
		/// </summary>
		[Range(2,20,ErrorMessageResourceName ="catalog.name")]
		public virtual string Name { get; set; }
		/// <summary>
		/// 编码
		/// </summary>
		[Range(2,50, ErrorMessageResourceName = "catalog.code")]
		public virtual string Code { get; set; }
		/// <summary>
		/// 排序 
		/// </summary>
		public virtual int Orders { get; set; }
		/// <summary>
		/// 父 编号
		/// </summary>
		public virtual string Pid { get; set; }
		/// <summary>
		///  1 菜单 (显示导航)  2 二级 菜单 3 底部导航
		/// </summary>
		public virtual CatalogFlag Flag { get; set; }


		/// <summary>
		/// 底部导航 链接
		/// </summary>
		public virtual string Link { get; set; }
		/// <summary>
		/// 底部导航 链接 跳转方式
		/// </summary>
		public virtual string Target { get; set; }

		/// <summary>
		/// 描述
		/// </summary>
		public virtual string Description { get; set; }

		//public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
		//{
		//    throw new NotImplementedException();
		//}
	}
}
