using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class PackageViewModel
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string Barcode { get; set; }
        public Guid ProductId { get; set; }
        public decimal BuyPrice { get; set; }

        public override string ToString() => $"{Type}";
    }
}
