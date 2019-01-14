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
using MarketOtomasyon.Models.Enums;

namespace MarketOtomasyon
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }

        private bool _urunVarmi = false;
        private decimal _totalPrice = 0;
        private double _bagPrice = 0.25;
        private PaymentTypes pType;
        private int id;
        private decimal remainderOfMoney;
        private List<ProductViewModel> products;
        private void txtSellingBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSellingBarcode.Text == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                {
                    products = new List<ProductViewModel>();
                    try
                    {
                        var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text && x.StockQuantity > 0).FirstOrDefault();
                        if (sonuc != null)
                        {
                            _urunVarmi = true;
                            bool varMi = false;
                            ProductRepo prodb = new ProductRepo();
                            if (lvBuyList.Items.Count != 0)
                                foreach (ListViewItem item in lvBuyList.Items)
                                {
                                    if (item.Text == txtSellingBarcode.Text)
                                        varMi = true;
                                }
                            if (!varMi)
                            {
                                foreach (var product in prodb.GetAll())
                                {
                                    ListViewItem pItem = lvBuyList.Items.Add($"{product.Barcode}");
                                    pItem.SubItems.Add($"{product.ProductName}");
                                    pItem.SubItems.Add($"{nuSellQuantity.Value}");
                                    pItem.SubItems.Add($"{product.SellPrice}");
                                    pItem.SubItems.Add($"{(product.SellPrice) * (nuSellQuantity.Value)}");
                                    pItem.SubItems.Add($"{product.StockQuantity}");

                                    _totalPrice += ((product.SellPrice) * (nuSellQuantity.Value));
                                }
                            }
                            else
                            {
                                foreach (ListViewItem item in lvBuyList.Items)
                                {
                                    var products = new ProductRepo().GetAll();
                                    foreach (var product in products)
                                    {
                                        if (item.Text==product.Barcode)
                                        {
                                            if (item.Text == txtSellingBarcode.Text)
                                            {
                                                item.SubItems[1].Text = product.ProductName;
                                                item.SubItems[2].Text = (Convert.ToUInt32(item.SubItems[2].Text) + nuSellQuantity.Value).ToString();
                                                item.SubItems[3].Text = product.SellPrice.ToString();
                                                item.SubItems[4].Text = (product.SellPrice * nuSellQuantity.Value).ToString();
                                                item.SubItems[5].Text = product.StockQuantity.ToString();

                                                _totalPrice += ((product.SellPrice) * (nuSellQuantity.Value));
                                            }
                                        }
                                        
                                    }
                                }
                            }


                            _totalPrice += nuShopBag.Value * (decimal)_bagPrice;

                            lblTotalPrice.Text = $"{_totalPrice:c2}";
                            if (rbCash.Checked)
                                pType = PaymentTypes.Nakit;
                            else if (rbCreditCard.Checked)
                                pType = PaymentTypes.KrediKarti;
                        }
                        else
                            throw new Exception($"Sistemde {txtSellingBarcode.Text} numarali bir urun bulunmamaktadir ");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            new SaleRepo().SalesBusiness(pType, products, out this.id, out remainderOfMoney);
            var prods = new ProductRepo().GetAll();
            foreach (var prod in prods)
            {
                if(prod.Barcode==txtSellingBarcode.Text)
                {
                    foreach (ListViewItem item in lvBuyList.Items)
                    {
                        if(item.Text == txtSellingBarcode.Text)
                        {
                            prod.StockQuantity = prod.StockQuantity - Convert.ToDecimal(item.SubItems[2].Text);
                        }
                    }
                }
            }
            int a = new ProductRepo().Update();
            lblRemainderOfMoney.Text = remainderOfMoney.ToString();
            MessageBox.Show($"Fiş numarasi : {id}, Yine bekleriz..");
        }
    }
}


//foreach (var item in products)
//{
//    if (item.Barcode == txtSellingBarcode.Text)
//    {       
//        varMi = true;
//        break;
//    }
//}
//if (varMi == false)
//{
//    MessageBox.Show("Böyle bir ürün bulunamadı");   

//}
//Sale sale = new Sale()
//{
//    Id = Guid.NewGuid()
//};

//var sonuc2 = new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text).FirstOrDefault();
//var sonuc3 = new SaleRepo().GetAll().LastOrDefault();
//SaleDetail sd = new SaleDetail()
//{
//    Quantity = Convert.ToInt32(nuSellQuantity.Value),
//    ProductName = sonuc.ProductName,
//    Id = sonuc3.Id,
//    Id2 = sonuc2.Id,
//    TotalPrice = Convert.ToDecimal( sonuc2.SellPrice * nuSellQuantity.Value)
//};
//lstSaleDetails.Items.Add(sd);