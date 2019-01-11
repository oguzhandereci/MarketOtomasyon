using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class SaleRepo: RepositoryBase<Sale, Guid>
    {
        public override List<Sale> GetAll()
        {
            return base.GetAll().OrderBy(x => x.SaleDate).ToList();
        }
    }
}
