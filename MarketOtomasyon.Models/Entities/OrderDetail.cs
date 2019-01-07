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
    [Table("OrderDetails")]
    public class OrderDetail: BaseEntity<Guid>
    {
        public OrderDetail()
        {
            this.Id = Guid.NewGuid();
        }
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public int PackageQuantity { get; set; }
    }
}
