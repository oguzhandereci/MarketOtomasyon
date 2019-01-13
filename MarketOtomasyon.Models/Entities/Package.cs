using MarketOtomasyon.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketOtomasyon.Models.Entities
{
    [Table("Packages")]
    public class Package : BaseEntity<Guid>
    {
        public Package()
        {
            this.Id = Guid.NewGuid();
        }
        public decimal PackageType { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Barkod numarasi 20 karakterden fazla olamaz")]
        [Index("IX_PackageBarcode", IsUnique = true)]
        public string Barcode { get; set; }
        public Guid ProductId { get; set; }
        public decimal BuyPrice { get; set; }


        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();

        public override string ToString() => $"{PackageType} {BuyPrice:c2}";
    }

}
