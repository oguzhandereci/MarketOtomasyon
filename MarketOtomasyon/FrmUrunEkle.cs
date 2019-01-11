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
                    SellPrice = Convert.ToDecimal(txtSellPrice.Text)+(Convert.ToDecimal(txtSellPrice.Text)*(cmbCategory.SelectedItem as CategoryViewModel).KdvRate)
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
                    ch.FormClearHelper(this, gpAddProduct);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void GetCategories()
        {
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

                lstCategories.DataSource = categories;
                cmbCategory.DataSource = categories;

                lstCategories.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmUrunEkle_Load_1(object sender, EventArgs e)
        {
            GetCategories();
        }

        private object _selectedCat = null;
        private object _selectedProduct = null;
        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null) return;

            _selectedCat = lstCategories.SelectedItem;
            lstProducts.SelectionMode = SelectionMode.None;
            lstProducts.DataSource = new ProductRepo()
                .GetAll(x => x.CategoryId == ((CategoryViewModel)_selectedCat).Id)
                .OrderBy(x => x.ProductName)
                .Select(x => new ProductViewModel()
                {
                    ProductName = x.ProductName,
                    Barcode = x.Barcode,
                    Id = x.Id,
                    CategoryName = x.Category.CategoryName,
                    SellPrice = x.SellPrice,
                    StockQuantity = x.StockQuantity
                })
                .ToList();
            lstProducts.ClearSelected();
            lstProducts.SelectionMode = SelectionMode.One;
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCat = null;
            if (lstProducts.SelectedItem == null) return;
            _selectedProduct = lstProducts.SelectedItem;
        }

        private CategoryViewModel _ct = null;
        private ProductViewModel _pd = null;
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedCat != null)
            {
                if (_selectedCat is CategoryViewModel selected)
                {
                    txtCategory.Text = selected.Name;
                    nuKDV.Value = selected.KdvRate;
                    btnAddCategory.Visible = false;
                    btnUpdateCategory.Visible = true;
                    btnUpdateCategory.Enabled = true;
                    _ct = selected;
                }
            }

            if (_selectedProduct != null)
            {
                _selectedCat = null;
                if (_selectedProduct is ProductViewModel selected)
                {
                    txtProduct.Text = selected.ProductName;
                    txtBarcode.Text = selected.Barcode;
                    cmbCategory.Text = selected.CategoryName;
                    txtSellPrice.Text = selected.SellPrice.ToString();
                    btnAddProduct.Visible = false;
                    btnUpdateProduct.Visible = true;
                    btnUpdateProduct.Enabled = true;
                    _pd = selected;
                }
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ct != null)
                {
                    using (var categoryRepo = new CategoryRepo())
                    {
                        var sonuc = categoryRepo.GetById(_ct.Id);
                        sonuc.KdvRate = nuKDV.Value;
                        sonuc.CategoryName = txtCategory.Text;

                        categoryRepo.Update();
                        MessageBox.Show($"Secilen {_ct.Name} isimli kategori basariyla guncellendi");
                        _selectedCat = null;
                    }
                }
                else if (_pd != null)
                {
                    using (var productRepo = new ProductRepo())
                    {
                        var sonuc = productRepo.GetById(_pd.Id);
                        sonuc.ProductName = txtProduct.Text;
                        sonuc.Barcode = txtBarcode.Text;
                        sonuc.SellPrice = decimal.Parse(txtSellPrice.Text)+(decimal.Parse(txtSellPrice.Text) * (sonuc.Category.KdvRate));
                        productRepo.Update();
                        MessageBox.Show($"Secilen {_pd.ProductName} isimli ürün basariyla guncellendi");
                        _selectedProduct = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCat != null)
                {
                    if (_selectedCat is CategoryViewModel selected)
                    {
                        using (var categoryRepo = new CategoryRepo())
                        {
                            var cat = categoryRepo.GetById(selected.Id);
                            if (cat.Products.Count == 0)
                            {
                                categoryRepo.Delete(cat);
                                MessageBox.Show($"Secilen {cat.CategoryName} isimli kategori basariyla silindi");
                            }
                            else
                                throw new Exception($"{cat.CategoryName} kategorisi, urun bulundurduğundan dolayı silinemez");

                        }
                    }
                }

                if (_selectedProduct != null)
                {
                    _selectedCat = null;
                    if (_selectedProduct is ProductViewModel selected)
                    {
                        using (var productRepo = new ProductRepo())
                        {
                            var product = productRepo.GetById(selected.Id);
                            productRepo.Delete(product);
                            MessageBox.Show($"Secilen {product.ProductName} isimli ürün basariyla silindi");
                        }
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
