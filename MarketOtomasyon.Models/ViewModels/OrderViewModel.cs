using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class OrderViewModel
    {
        public Guid id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        //public decimal totalPrice { get; set; }
        //public decimal totalKdvRate { get; set; }

        public override string ToString() => $"{OrderDate}";
    }
}
