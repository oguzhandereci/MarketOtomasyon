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
    public class OrderDetail: BaseEntity2<Guid, Guid>
    {
        [StringLength(50)]
        public string ProductName { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        public int PackageQuantity { get; set; }

        [ForeignKey("Id")]
        public virtual Order Order { get; set; }
        [ForeignKey("Id2")]
        public virtual Product Product { get; set; }
    }
}
