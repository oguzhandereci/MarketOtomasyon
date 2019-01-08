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
        public Category()
        {
            this.Id = Guid.NewGuid();
        }
        [Required]
        [StringLength(120)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal KdvRate { get; set; }



        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
