using MarketOtomasyon.BLL.Repositories;
using MarketOtomasyon.Helpers;
using MarketOtomasyon.Models.Entities;
using MarketOtomasyon.Models.ViewModels;
using MarketOtomasyon.Models.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MarketOtomasyon
{
    public partial class FrmUrunEkle : Form
    {
        public FrmUrunEkle()
        {
            InitializeComponent();
        }


        ClearHelper ch = new ClearHelper();
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            List<Category> categories = new CategoryRepo().GetAll();
            bool varMi = false;
            try
            {
                if (categories.Count == 0)
                {
                    new CategoryRepo().Insert(new Category()
                    {
                        CategoryName = txtCategory.Text,
                        KdvRate = nuKDV.Value
                    });
                    MessageBox.Show("Kategori ekleme islemi basarili");
                }
                else
                {

                    foreach (var cat in categories)
                    {
                        if (cat.CategoryName == txtCategory.Text)
                            varMi = true;
                    }

                    if (!varMi)
                    {
                        new CategoryRepo().Insert(new Category()
                        {
                            CategoryName = txtCategory.Text,
                            KdvRate = nuKDV.Value
                        });
                        MessageBox.Show("Kategori ekleme islemi basarili");
                        ch.FormClearHelper(this, gpAddCategory);
                    }
                    else
                        throw new Exception("Bu isimde bir kategori bulunmaktadir");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            GetCategories();
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == null || cmbCategory.SelectedItem == null || txtBarcode.Text == null || txtSellPrice.Text == null) return;

            List<Product> products = new ProductRepo().GetAll();
            try
            {
                Product product = new Product()
                {
                    CategoryId = (cmbCategory.SelectedItem as CategoryViewModel).Id,
                    ProductName = txtProduct.Text,
                    Barcode = txtBarcode.Text,
                    SellPrice = Convert.ToDecimal(txtSellPrice.Text)
                };

                using (var productRepo = new ProductRepo())
                {
                    foreach (var item in products)
                    {
                        if (product.Barcode == item.Barcode) throw new Exception("Aynı barkoda sahip ürününz var");
                        if (item.CategoryId == product.CategoryId && item.ProductName == product.ProductName) throw new Exception("Bu kategoride bu isimde bir ürün bulunmaktadir");
                    }
                    productRepo.Insert(product);
                    MessageBox.Show("Kayıt işlemi başarılı");
                    ch.FormClearHelper(this,gpAddProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GetCategories()
        {

            List<ProductViewModel> products = new List<ProductViewModel>();
            try
            {
                var categories = new CategoryRepo().GetAll()
                                                      .OrderBy(x => x.CategoryName)
                                                      .Select(x => new CategoryViewModel()
                                                      {
                                                          Id = x.Id,
                                                          Name = x.CategoryName,
                                                          KdvRate = x.KdvRate

                                                      }).ToList();
                products.AddRange(new ProductRepo().GetAll()
                       .OrderBy(x => x.ProductName)
                       .Select(x => new ProductViewModel()
                       {
                           Id = x.Id,
                           ProductName = x.ProductName,
                           SellPrice = x.SellPrice,
                           StockQuantity = x.StockQuantity,
                           Barcode = x.Barcode
                       }));

                lstCategories.DataSource = categories;
                lstProducts.DataSource = products;
                cmbCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmUrunEkle_Load_1(object sender, EventArgs e)
        {
            lstCategories.SelectedItem = null;
            GetCategories();
        }

        static object selected;
        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null) return;
            
            selected = lstCategories.SelectedItem;
            lstProducts.DataSource = new ProductRepo()
                .GetAll(x => x.CategoryId == (selected as CategoryViewModel).Id)
                .OrderBy(x => x.ProductName)
                .Select(x => new ProductViewModel()
                {
                     ProductName = x.ProductName,
                      Barcode = x.Barcode,
                       Id = x.Id,
                        SellPrice = x.SellPrice,
                         StockQuantity = x.StockQuantity
                })
                .ToList();                                                                                                                     
        }
        CategoryViewModel ct = new CategoryViewModel();
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected is CategoryViewModel)
            {
                var selectedCat = selected as CategoryViewModel;
                txtCategory.Text = selectedCat.Name;
                nuKDV.Value = selectedCat.KdvRate;
                btnAddCategory.Visible = false;
                btnGuncelle.Visible = true;
                btnGuncelle.Enabled = true;
                ct = selectedCat;
            }
            
            else if (selected is ProductViewModel)
            {

            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var catRepo = new CategoryRepo();
            var sonuc = catRepo.GetById(ct.Id);
            sonuc.KdvRate = nuKDV.Value;
            sonuc.CategoryName = txtCategory.Text;
            
            catRepo.Update();
            //try
            //{

            //    using (var CategoryRepo = new CategoryRepo())
            //    {
            //        var Sonuc = new ProductRepo()
            //            .GetAll()
            //            .FirstOrDefault();

            //        txtCategory.Text = Sonuc.Category.CategoryName;
            //        foreach (var item in products)
            //        {
            //            if (product.Barcode == item.Barcode) throw new Exception("Aynı barkoda sahip ürününz var");
            //            if (item.CategoryId == product.CategoryId && item.ProductName == product.ProductName) throw new Exception("Bu kategoride bu isimde bir ürün bulunmaktadir");
            //        }
            //        productRepo.Insert(product);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
