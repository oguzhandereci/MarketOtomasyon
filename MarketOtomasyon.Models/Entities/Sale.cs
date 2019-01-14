using MarketOtomasyon.Models.Abstracts;
using MarketOtomasyon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Entities
{
    public class Sale:BaseEntity<int>
    {
        public DateTime SaleDate { get; set; }

        public PaymentTypes PaymentTypes { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new HashSet<SaleDetail>();
    }
}
