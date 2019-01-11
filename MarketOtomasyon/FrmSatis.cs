using MarketOtomasyon.BLL.Repositories;
using MarketOtomasyon.Models.Entities;
using MarketOtomasyon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyon
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }

        private void txtSellingBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSellingBarcode.Text == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                {
                    List<ProductViewModel> products = new List<ProductViewModel>();
                    try
                    {
                        var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text).FirstOrDefault();
                        bool varMi = false;
                        products.AddRange(new ProductRepo().GetAll()
                           .OrderBy(x => x.ProductName)
                           .Select(x => new ProductViewModel()
                           {
                               Id = x.Id,
                               Barcode = x.Barcode,
                               ProductName = x.ProductName,
                               SellPrice = x.SellPrice,
                               StockQuantity = x.StockQuantity

                           }));
                        foreach (var item in products)
                        {
                            if (item.Barcode == txtSellingBarcode.Text)
                            {       
                                varMi = true;
                                break;
                            }
                        }
                        if (varMi == false)
                        {
                            MessageBox.Show("Böyle bir ürün bulunamadı");   
                            
                        }
                        Sale sale = new Sale()
                        {
                            Id = Guid.NewGuid()
                        };

                        var sonuc2 = new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text).FirstOrDefault();
                        var sonuc3 = new SaleRepo().GetAll().LastOrDefault();
                        SaleDetail sd = new SaleDetail()
                        {
                            Quantity = Convert.ToInt32(nuSellQuantity.Value),
                            ProductName = sonuc.ProductName,
                            Id = sonuc3.Id,
                            Id2 = sonuc2.Id,
                            TotalPrice = Convert.ToDecimal( sonuc2.SellPrice * nuSellQuantity.Value)
                        };
                        lstSaleDetails.Items.Add(sd);



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {

        }
    }  
}
