using MarketOtomasyon.Models.Abstracts;
using MarketOtomasyon.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Entities
{
    [Table("SaleDetails")]
    public class SaleDetail: BaseEntity<Guid>
    {
        public SaleDetail()
        {
            this.Id = Guid.NewGuid();
        }
        public int Stock { get; set; }
        public int Total { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public PaymentTypes PaymentTypes { get; set; }
        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual Category Category { get; set; }

    }
}
