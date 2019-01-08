using MarketOtomasyon.BLL.Repositories;
using MarketOtomasyon.Models.Entities;
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

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var categories = new CategoryRepo().GetAll();
                bool varMi = false;
                foreach (var cat in categories)
                {
                    if (cat.CategoryName != txtCategory.Text)
                    {
                        //new CategoryRepo().Insert(new Category()
                        //{
                        //    CategoryName = txtCategory.Text,
                        //    KdvRate = nuKDV.Value
                        //});
                    }
                    else
                        throw new Exception("Bu isimde bir kategori bulunmaktadir");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
