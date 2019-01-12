using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class OrderDetailViewModel
    {
        public Guid id { get; set; }
        public Guid id2 { get; set; }
        public string ProductName { get; set; }
        public decimal PackageType { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal kdvRate { get; set; }
        public decimal productPrice { get; set; }

        public override string ToString() => $"{ProductName} {PackageType} {PackageQuantity}";
    }
}
