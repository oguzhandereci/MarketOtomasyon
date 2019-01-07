using MarketOtomasyon.Models.Abstracts;
using System;
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
        public int PackageQuantity { get; set; }
        public int Barcode { get; set; }


    //     [ForeignKey("ProductId")]
    //    public virtual Product Product { get; set; }
    }

}
