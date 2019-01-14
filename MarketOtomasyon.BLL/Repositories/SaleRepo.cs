using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketOtomasyon.Models.Enums;
using MarketOtomasyon.Models.ViewModels;

namespace MarketOtomasyon.BLL.Repositories
{
    public class SaleRepo: RepositoryBase<Sale, Guid>
    {
        public override List<Sale> GetAll()
        {
            return base.GetAll().OrderBy(x => x.SaleDate).ToList();
        }

        public void SalesBusiness(PaymentTypes pType, List<ProductViewModel> products, out int id, out decimal money)
        {
            id = int.MinValue;
            money = Decimal.MaxValue;
        }
    }
}
