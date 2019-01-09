using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.Models.Views
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal KdvRate { get; set; }
        //public int TotalSubCategory { get; set; }

        public override string ToString() => $"{Name} ({KdvRate})";
    }
}
