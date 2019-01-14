    using MarketOtomasyon.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class SaleViewModel
    {
        public int id { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public PaymentTypes PaymentTypes { get; set; }
        public List<SaleDetailViewModel> SaleDetailList { get; set; }

        public override string ToString() => $"{SaleDetailList}";
    }
}
