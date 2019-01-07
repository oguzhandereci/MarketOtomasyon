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
    [Table("Products")]
    public class Product:BaseEntity<Guid>
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public Guid CategoryId { get; set; }
        public decimal StockQuantity { get; set; }


        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }
    }
}
