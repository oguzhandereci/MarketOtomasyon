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
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }
        FrmMalKabul frmMalKabul;
        FrmUrunEkle frmUrunEkle;
        FrmSatis frmSatis;
        private void malKabulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMalKabul == null || frmMalKabul.IsDisposed)
            {
                frmMalKabul = new FrmMalKabul
                {
                    Text = "Mal Kabul",
                    MdiParent = this
                };
                frmMalKabul.Show();
                if (frmUrunEkle != null)
                {
                    frmUrunEkle.Dispose();
                }
                if (frmSatis != null)
                {
                    frmSatis.Dispose();
                }

            }
            
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUrunEkle == null || frmUrunEkle.IsDisposed)
            {
                frmUrunEkle = new FrmUrunEkle
                {
                    Text = "Urun Ekle",
                    MdiParent = this
                };
                frmUrunEkle.Show();
                if (frmMalKabul != null)
                {
                    frmMalKabul.Dispose();
                }
                if (frmSatis != null)
                {
                    frmSatis.Dispose();
                }
            }
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSatis == null || frmSatis.IsDisposed)
            {
                frmSatis = new FrmSatis
                {
                    Text = "Urun Ekle",
                    MdiParent = this
                };
                frmSatis.Show();
                if (frmMalKabul != null)
                {
                    frmMalKabul.Dispose();
                }
                if (frmUrunEkle != null)
                {
                    frmUrunEkle.Dispose();
                }
            }

        }
    }
}
