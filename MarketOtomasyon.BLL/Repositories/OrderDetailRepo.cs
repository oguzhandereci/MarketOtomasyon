using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class OrderDetailRepo : RepositoryBase<OrderDetail, Guid>
    {
        public override List<OrderDetail> GetAll()
        {
            return base.GetAll().OrderBy(x => x.PackageType).ToList();
        }
        public override int Insert(OrderDetail entity)
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
