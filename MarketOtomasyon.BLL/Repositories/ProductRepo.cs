using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class ProductRepo : RepositoryBase<Product, Guid>
    {
        public override int Insert(Product entity)
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
