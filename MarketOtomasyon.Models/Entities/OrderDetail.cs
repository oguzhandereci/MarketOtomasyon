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
        public decimal PackageType { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal kdvRate { get; set; }
        public decimal productPrice { get; set; }

        [ForeignKey("Id")]
        public virtual Order Order { get; set; }
        [ForeignKey("Id2")]
        public virtual Package Package { get; set; }


        public override string ToString() => $"{ProductName} {PackageType} {PackageQuantity}";
    }
}
