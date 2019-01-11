using MarketOtomasyon.BLL.Repositories;
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
                                var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text).FirstOrDefault();          
                                varMi = true;
                                break;
                            }
                        }
                        if (varMi == false)
                        {
                            MessageBox.Show("Böyle bir ürün bulunamadı");
                            
                        }


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
