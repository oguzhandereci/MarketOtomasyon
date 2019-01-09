using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class CategoryRepo:RepositoryBase<Category,Guid>
    {
        public override List<Category> GetAll()
        {
            return base.GetAll().OrderBy(x => x.CategoryName).ToList();
        }
        public override int Insert(Category entity)
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
