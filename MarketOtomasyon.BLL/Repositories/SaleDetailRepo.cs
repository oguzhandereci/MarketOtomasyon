using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class SaleDetailRepo:RepositoryBase<SaleDetail, Guid>
    {
        public override List<SaleDetail> GetAll()
        {
            return base.GetAll().OrderBy(x => x.ProductName).ToList();
        }
        public override int Insert(SaleDetail entity)
        {
            try
            {
                return base.Insert(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
