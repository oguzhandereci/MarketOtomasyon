using MarketOtomasyon.Models.Abstracts;
using MarketOtomasyon.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Entities
{
    [Table("SaleDetails")]
    public class SaleDetail: BaseEntity2<int,Guid>
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


        [ForeignKey("Id")]
        public virtual Sale Sale { get; set; }
        [ForeignKey("Id2")]
        public virtual Product Product { get; set; }
        
        public override string ToString() => $" {Quantity}  *  {ProductName} = {TotalPrice}";
    }
}
