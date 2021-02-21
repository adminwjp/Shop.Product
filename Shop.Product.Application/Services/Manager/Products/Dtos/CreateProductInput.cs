using AutoMapper;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Products.Dtos
{
	/// <summary>
	/// 添加 产品 实体
	/// </summary>
	[AutoMap(typeof(ProductEntity))]
	public class CreateProductInput:BaseProductInput
    {
		/// <summary>
		/// 创建账户
		/// </summary>
		public virtual string CreateAccount { get; set; }
	}
}
