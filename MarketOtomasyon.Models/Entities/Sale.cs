using MarketOtomasyon.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Entities
{
    public class Sale:BaseEntity<Guid>
    {
        public Sale()
        {
            this.Id = Guid.NewGuid();
        }
        public DateTime SaleDate { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new HashSet<SaleDetail>();
    }
}
