using MarketOtomasyon.BLL.Repositories;
using MarketOtomasyon.Helpers;
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
        FrmUrunEkle frmUrunEkle = new FrmUrunEkle();

        public FrmMalKabul()
        {
            InitializeComponent();
        }
        ClearHelper ch = new ClearHelper();
        private void FrmMalKabul_Load(object sender, EventArgs e)
        {

        }

        private void txtBarcodePackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtBarcodePackage.Text == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                bool varMi = false;
                List<PackageViewModel> packages = new List<PackageViewModel>();
                try
                {
                    packages.AddRange(new PackageRepo().GetAll()
                       .OrderBy(x => x.PackageType)
                       .Select(x => new PackageViewModel()
                       {
                           Id = x.Id,
                           PackageType = x.PackageType,
                           Barcode = x.Barcode,
                           BuyPrice = x.BuyPrice,
                           ProductId = x.ProductId
                       }));
                    if (packages.Count == 0) { MessageBox.Show("Lütfen önce ürün barkodu girin"); return;}
                    var sonuc = new PackageRepo().GetAll(x => x.Barcode == txtBarcodePackage.Text).FirstOrDefault();
                    foreach (var item in packages)
                    {

                        if (item.Barcode == txtBarcodePackage.Text)
                        {
                            txtBarcodeProduct.Text = sonuc.Product.Barcode;
                            txtCategory.Text = sonuc.Product.Category.CategoryName;
                            txtProduct.Text = sonuc.Product.ProductName;
                            nuPackageQuantity.Value = sonuc.PackageType;
                            varMi = true;
                            break;
                        }
                    }
                    if (varMi == false)
                    {
                        MessageBox.Show("Lütfen Ürün barkodunu giriniz");

                        ch.FormClearHelper(this);
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
                    if (products.Count == 0) { MessageBox.Show("Önce Ürün Ekleeyiniz"); frmUrunEkle.ShowDialog(); }
                    foreach (var item in products)
                    {
                        if (item.Barcode == txtBarcodeProduct.Text)
                        {
                            var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtBarcodeProduct.Text).FirstOrDefault();
                            txtCategory.Text = sonuc.Category.CategoryName;
                            txtProduct.Text = sonuc.ProductName;
                            nuPackageQuantity.Enabled = true;
                            varMi = true;
                            break;
                        }
                    }
                    if (varMi == false)
                    {
                        MessageBox.Show("Lütfen bir ürün kaydediniz");
                        frmUrunEkle.ShowDialog();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMalKabul_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == null || nuPackageQuantity.Value == 0 || nuQuantity.Value == 0 || txtBuyPrice.Text == null) return;

            List<Package> packages = new PackageRepo().GetAll();
            List<OrderDetail> ods = new OrderDetailRepo().GetAll();
            try
            {
                var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtBarcodeProduct.Text).FirstOrDefault();
                var FindPackage = new PackageRepo().GetAll(x=>x.Barcode==txtBarcodePackage.Text).FirstOrDefault();
                if (FindPackage == null)
                {
                    ////// package save part
                    Package package = new Package()
                    {
                        ProductId = sonuc.Id,
                        Barcode = txtBarcodePackage.Text,
                        PackageType = nuPackageQuantity.Value,
                        BuyPrice = Convert.ToDecimal(txtBuyPrice.Text),

                    };

                    using (var packageRepo = new PackageRepo())
                    {
                        foreach (var item in packages)
                        {
                            if (package.Barcode == item.Barcode) throw new Exception("Aynı barkoda sahip koliniz var");
                        }
                        packageRepo.Insert(package);
                    }
                }
                ///////order part
                Order order = new Order()
                {
                    Id=Guid.NewGuid()
                };
                using (var orderRepo = new OrderRepo())
                {
                    orderRepo.Insert(order);
                }
                ///// order details part
                var sonuc2 = new PackageRepo().GetAll(x => x.Barcode == txtBarcodePackage.Text).FirstOrDefault();
                var sonuc3 = new OrderRepo().GetAll().LastOrDefault();
                OrderDetail od = new OrderDetail()
                {
                    PackageQuantity = nuQuantity.Value,
                    PackageType = sonuc2.PackageType,
                    ProductName = sonuc.ProductName,
                    Id = sonuc3.Id,
                    Id2 = sonuc2.Id
                };
                using (var orderDetailRepo = new OrderDetailRepo())
                {
                    orderDetailRepo.Insert(od);
                    MessageBox.Show("Sipariş kayıt işlemi başarılı");
                }

                var sonuc4 = new ProductRepo().GetAll(x => x.ProductName == txtProduct.Text).FirstOrDefault();
                sonuc4.StockQuantity = Convert.ToDecimal(sonuc4.StockQuantity) + (nuQuantity.Value * nuPackageQuantity.Value);
              
                int a = new ProductRepo().Update();

                ch.FormClearHelper(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
