using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyon.Helpers
{
    public class ClearHelper
    {
        public void FormClearHelper(Form form)
        {
            foreach (Control item in form.Controls)
            {
                if (item is TextBox)
                    item.Text = string.Empty;
                //if (item is NumericUpDown)
                //    item.Text = string.Empty;
                if (item is ComboBox)
                    item.Text = string.Empty;
                //if (item is ListBox)
                    
                    
            }
        }
        public void FormClearHelper(Form form, GroupBox gb)
        {
            foreach (Control item in form.Controls)
            {
                Control cntrl = gb;
                foreach (Control cn in cntrl.Controls)
                {
                    if (cn is TextBox)
                        cn.Text = string.Empty;
                    if (cn is ComboBox)
                        cn.Text = string.Empty;
                }
            }
        }
    }
}
