using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.ViewModels
{
    public class CmbCategoryViewModel
    {
        
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal KdvRate { get; set; }

        public override string ToString() => $"{CategoryName}";
    }
}
