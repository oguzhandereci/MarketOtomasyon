using MarketOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketOtomasyon.Models.Enums;
using MarketOtomasyon.Models.ViewModels;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using MarketOtomasyon.Helpers;

namespace MarketOtomasyon.BLL.Repositories
{
    public class SaleRepo: RepositoryBase<Sale, int>
    {
        public override List<Sale> GetAll()
        {
            return base.GetAll().OrderBy(x => x.SaleDate).ToList();
        }
        public override int Insert(Sale entity)
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

        public void SalesBusiness(PaymentTypes pType, List<ProductViewModel> products,decimal paidMoney, decimal totalPrice, out int id, out decimal money,decimal nu)
        {
            money = 0;
            id = 0;
                try
                {
                    var sale = new Sale();
                    if (pType == PaymentTypes.Nakit)
                    {
                        sale.PaymentTypes = pType;
                        sale.SaleDate = DateTime.Now;
                        if (paidMoney < totalPrice)
                            throw new Exception("Ödenen para yetersiz");
                        else
                        {
                            money = paidMoney - totalPrice;
                        }
                    }
                    else if (pType == PaymentTypes.KrediKarti)
                    {
                        sale.PaymentTypes = pType;
                        sale.SaleDate = DateTime.Now;
                    }
                    var sr = new SaleRepo().Insert(sale);
                    id= sale.Id;
                    var iid = new SaleRepo().GetAll(x=>x.Id== sale.Id).FirstOrDefault();
                    foreach (var item in products)
                    {
                        var prod = new ProductRepo().GetAll(x=>x.Id==item.Id).FirstOrDefault();

                        SaleDetail sd = new SaleDetail() {
                            ProductName = prod.ProductName,
                            Quantity = (int)nu,
                            TotalPrice =prod.SellPrice*nu,
                            Id2 = prod.Id,
                            CreatedDate = DateTime.Now,
                             Id=Convert.ToInt32(iid.Id)
                        };
                        var sdr = new SaleDetailRepo().Insert(sd);
                    }
                }

                catch (DbEntityValidationException ex)
                {
                    new EntityHelper().FindError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
    }
}
