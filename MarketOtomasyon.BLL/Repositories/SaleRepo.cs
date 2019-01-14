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

        public void SalesBusiness(PaymentTypes pType, List<ProductViewModel> products,decimal paidMoney, decimal totalPrice, out int id, out decimal money)
        {
            money = 0;
            id = 0;
            using (var tran = db.Database.BeginTransaction())
            {
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
                    //db.Sales.Add(sale);
                    //db.SaveChanges();
                    id = sale.Id;

                    foreach (var item in products)
                    {
                        db.SaleDetails.Add(new SaleDetail()
                        {
                            ProductName = item.ProductName,
                            Quantity = (int)item.SellQuantity,
                            TotalPrice = item.SubTotalPrice,
                            Id2 = item.Id,
                            CreatedDate = DateTime.Now
                        });
                        db.SaveChanges();
                    }

                    tran.Commit();
                }

                catch (DbEntityValidationException ex)
                {
                    new EntityHelper().FindError(ex);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
