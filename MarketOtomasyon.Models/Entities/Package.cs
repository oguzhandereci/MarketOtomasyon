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
        public int Type { get; set; }
        public string Barcode { get; set; }
        public Guid ProductId { get; set; }


        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }

}
