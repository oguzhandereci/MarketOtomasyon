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
    public partial class FrmMalKabul : Form
    {
       FrmMalKabul frmMalKabul;
        FrmUrunEkle frmUrunEkle;

        public FrmMalKabul()
        {
            InitializeComponent();
        }

        private void FrmMalKabul_Load(object sender, EventArgs e)
        {

        }

        private void txtBarcodePackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBarcodePackage.Text == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                List<PackageViewModel> packages = new List<PackageViewModel>();
                try
                {
                    packages.AddRange(new PackageRepo().GetAll()
                       .OrderBy(x => x.Type)
                       .Select(x => new PackageViewModel()
                       {
                           Id = x.Id,
                           Type = x.Type,
                           Barcode = x.Barcode,
                           BuyPrice = x.BuyPrice,
                           ProductId = x.ProductId
                       }));
                    foreach (var item in packages)
                    {
                        if (item.Barcode == txtBarcodePackage.Text)
                        {
                            var sonuc = new PackageRepo().GetAll(x => x.Barcode == txtBarcodePackage.Text).FirstOrDefault();
                            txtCategory.Text = sonuc.Product.Category.CategoryName;
                            txtProduct.Text = sonuc.Product.ProductName;
                            nuPackageQuantity.Value = sonuc.Type;
                        }
                        else { MessageBox.Show("Lütfen Ürün barkodunu giriniz"); }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtBarcodeProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBarcodeProduct.Text == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                List<ProductViewModel> products = new List<ProductViewModel>();
                try
                {
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
                        if (item.Barcode == txtBarcodeProduct.Text)
                        {
                            var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtBarcodeProduct.Text).FirstOrDefault();
                            txtCategory.Text = sonuc.Category.CategoryName;
                            txtProduct.Text = sonuc.ProductName;
                            nuPackageQuantity.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Yeni Ürün ekleyiniz");
                            /// urun ekleme formu acılacak
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
