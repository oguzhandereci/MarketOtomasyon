using MarketOtomasyon.BLL.Repositories;
using MarketOtomasyon.Models.Entities;
using MarketOtomasyon.Models.Views;
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
    public partial class FrmUrunEkle : Form
    {
        public FrmUrunEkle()
        {
            InitializeComponent();
        }
        private void FrmUrunEkle_Load(object sender, EventArgs e)
        {
            //lstCategories.DataSource = new CategoryRepo().GetAll();
            GetCategories();
        }

        

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
            //lstCategories.DataSource = new CategoryRepo().GetAll();
        }
        private void GetCategories()
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

        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
