using MarketOtomasyon.BLL.Repositories;
using MarketOtomasyon.Helpers;
using MarketOtomasyon.Models.Entities;
using MarketOtomasyon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
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
            cmbOrder.DataSource = new OrderRepo().GetAll();
            cmbOrder.SelectedIndex = -1;
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
                    if (packages.Count == 0)
                    {
                        MessageBox.Show("Lütfen önce ürün barkodu girin");
                        return;
                    }

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

        private void btnMalKabul_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == null || nuPackageQuantity.Value == 0 || nuQuantity.Value == 0 || txtBuyPrice.Text == null) return;


            try
            {
                foreach (var item in ods)
                {
                    using (var orderDetailRepo = new OrderDetailRepo())
                    {
                        orderDetailRepo.Insert(item as OrderDetail);
                    }

                    var pack = new PackageRepo().GetAll(x=>x.Id==item.Id2).FirstOrDefault();
                    pack.Product.StockQuantity =Convert.ToDecimal(pack.Product.StockQuantity) +(item.PackageQuantity * item.PackageType);
                    int update = new PackageRepo().Update();
                }

                MessageBox.Show("Sipariş kayıt işlemi başarılı");
                ch.FormClearHelper(this);
                for (int i = 0; i < lstOrderDetails.Items.Count; i++)
                {
                    lstOrderDetails.Items.Remove(i);
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

            ch.FormClearHelper(this);
            lstOrderDetails.Items.Clear();
        }

        List<OrderDetail> ods = new List<OrderDetail>();
        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {

            List<Package> packages = new PackageRepo().GetAll();
            try
            {
                #region package save
                var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtBarcodeProduct.Text).FirstOrDefault();
                var FindPackage = new PackageRepo().GetAll(x => x.Barcode == txtBarcodePackage.Text).FirstOrDefault();
                if (FindPackage == null)
                {
                    ////// package save part
                    Package package = new Package()
                    {
                        ProductId=sonuc.Id,
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
                    var pack = new PackageRepo().GetAll(x=>x.Barcode==txtBarcodePackage.Text).FirstOrDefault();
                    var product = new ProductRepo().GetAll(x => x.Barcode == pack.Product.Barcode).FirstOrDefault();
                    var order = new OrderRepo().GetAll(x => x.CreatedDate == (cmbOrder.SelectedItem as Order).CreatedDate).FirstOrDefault();
                    ods.Add(new OrderDetail()
                    {
                        Id = order.Id,
                        Id2 = pack.Id,
                        PackageQuantity = nuQuantity.Value,
                        PackageType = pack.PackageType,
                        ProductName = product.ProductName
                    });
                }
                else
                {
                    var product = new ProductRepo().GetAll(x => x.Barcode == FindPackage.Product.Barcode).FirstOrDefault();
                    var order = new OrderRepo().GetAll(x => x.CreatedDate == (cmbOrder.SelectedItem as Order).CreatedDate).FirstOrDefault();
                    ods.Add(new OrderDetail()
                    {
                        Id = order.Id,
                        Id2 = FindPackage.Id,
                        PackageQuantity = nuQuantity.Value,
                        PackageType = FindPackage.PackageType,
                        ProductName = product.ProductName
                    });
                    FindPackage.BuyPrice = Convert.ToDecimal(txtBuyPrice.Text);
                    var pr = new PackageRepo().Update();

                }

                addList();

                #endregion

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



        private void addList()
        {
            //lstOrderDetails.Items.Clear();
            lstOrderDetails.Items.AddRange(new PackageRepo().GetAll(x => x.Barcode == txtBarcodePackage.Text).ToArray());
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            ///////order part
            Order order = new Order()
            {
            };
            using (var orderRepo = new OrderRepo())
            {
                orderRepo.Insert(order);
            }
            cmbOrder.DataSource = new OrderRepo().GetAll();
        }
    }
}
