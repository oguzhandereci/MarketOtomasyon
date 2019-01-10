using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class OrderRepo : RepositoryBase<Order, Guid>
    {
        public override List<Order> GetAll()
        {
            return base.GetAll().OrderBy(x => x.OrderDate).ToList();
        }
    }
}
