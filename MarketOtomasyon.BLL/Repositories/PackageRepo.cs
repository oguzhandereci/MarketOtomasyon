using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyon.BLL.Repositories
{
    public class PackageRepo : RepositoryBase<Package, Guid>
    {
        public override List<Package> GetAll()
        {
            return base.GetAll().OrderBy(x => x.Type).ToList();
        }
        public override int Insert(Package entity)
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
