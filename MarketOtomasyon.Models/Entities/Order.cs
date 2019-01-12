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
    [Table("Order")]
    public class Order: BaseEntity<Guid>
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
        }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        //public decimal totalPrice { get; set; }
        //public decimal totalKdvRate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();

        public override string ToString() => $"{OrderDate}";
    }
}
