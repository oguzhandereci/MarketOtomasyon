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
        public string ProductName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Barkod numarasi 20 karakterden fazla olamaz")]
        [Index("IX_ProductBarcode",IsUnique =true)]
        public string Barcode { get; set; }
        public decimal SellPrice { get; set; }
        public decimal? StockQuantity { get; set; }
        public Guid CategoryId { get; set; }



        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new HashSet<SaleDetail>();
        public virtual ICollection<Package> Packages { get; set; } = new HashSet<Package>();
    }
}
