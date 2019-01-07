using MarketOtomasyon.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Entities
{
    [Table("Categories")]
    public class Category:BaseEntity<Guid>
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SupCategoryId { get; set; }
        public decimal KdvOrani { get; set; }


        //[ForeignKey("SupCategoryId")]
        //public virtual Category SupCategory { get; set; }
        //public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
