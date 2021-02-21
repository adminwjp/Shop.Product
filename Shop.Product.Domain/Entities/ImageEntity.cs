using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Product.Domain.Entities
{
    [Table("t_image")]
    public class ImageEntity:BaseEntity
    {
        [Column("path")]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public virtual string Path { get; set; }
    }
}
