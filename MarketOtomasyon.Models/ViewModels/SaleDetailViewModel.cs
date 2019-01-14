using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class SaleDetailViewModel
    {
        public int id { get; set; }
        public Guid id2 { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public override string ToString() => $" {Quantity}  *  {ProductName} = {TotalPrice:c2}";
    }
}
