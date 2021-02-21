using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
//using Utility.Domain.Entities;

namespace Shop.Product.Domain.Entities
{
    /// <summary>
    /// 商品参数
    /// </summary>
    [Table("t_product_attribute")]
    public  class ProductAttribueEntity : BaseEntity
    {       
        /// <summary>
        /// 表名 
        /// </summary>
        public const string TableName = "t_product_attribute";
        /// <summary>
        /// 参数id
        /// </summary>
        [Column("attribute_id")]
        [StringLength(36)]
        public string AttributeId { get; set; }
        /// <summary>
        /// 商品 id
        /// </summary>
        [Column("product_id")]
        [StringLength(36)]
        public string ProductId { get; set; }
        [Column("value")]
        [StringLength(500)]
        public string Value { get; set; }
    }
}
