using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Barcode { get; set; }
        public decimal SellPrice { get; set; }
        public decimal? StockQuantity { get; set; }
        public decimal SubTotalPrice { get; set; }
        public decimal SellQuantity { get; set; }

        public override string ToString() => $"{ProductName} - {SellPrice:c2} - {StockQuantity}";
    }
}
