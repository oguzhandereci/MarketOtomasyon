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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace MarketOtomasyon
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }

        //private bool _urunVarmi = false;
        private decimal _totalPrice = 0;
        private double _bagPrice = 0.25;
        private PaymentTypes pType;
        private string pymnt="";
        private int id;
        private decimal remainderOfMoney,paidMoney;
        private List<ProductViewModel> products = new List<ProductViewModel>();
        private void txtSellingBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSellingBarcode.Text == null) return;
            if (e.KeyCode == Keys.Enter)
            {
                {
                    try
                    {
                        var sonuc = new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text ).FirstOrDefault();
                        if (sonuc != null)
                        {
                            bool varMi = false;
                            List<Product> list = new List<Product>();
                            products.AddRange(new ProductRepo().GetAll(x => x.Barcode == txtSellingBarcode.Text)
                                .OrderBy(x => x.ProductName)
                                .Select(x => new ProductViewModel()
                                {
                                    Id = x.Id,
                                    Barcode = x.Barcode,
                                    ProductName = x.ProductName,
                                    SellPrice = x.SellPrice,
                                    StockQuantity = x.StockQuantity,
                                    SubTotalPrice = (x.SellPrice) * (nuSellQuantity.Value),
                                    SellQuantity = nuSellQuantity.Value

                                }));
                            
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
                                    if (product.Barcode == txtSellingBarcode.Text)
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
                                                item.SubItems[4].Text = (Convert.ToDecimal(item.SubItems[4].Text) + (product.SellPrice * nuSellQuantity.Value)).ToString();
                                                item.SubItems[5].Text = product.StockQuantity.ToString();

                                                _totalPrice += ((product.SellPrice) * (nuSellQuantity.Value));
                                            }
                                        }
                                        
                                    }
                                }
                            }

                            //_totalPrice += nuShopBag.Value * (decimal)_bagPrice;
                            lblTotalPrice.Text = $"{_totalPrice:c2}";
                                
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

        private void rbChecked(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "rbCash")
            {
                pType = PaymentTypes.Nakit;
                label7.Visible = true;
                label8.Visible = true;
                txtOdenenPara.Visible = true;
                lblRemainderOfMoney.Visible = true;
            }
            else if(rb.Name == "rbCreditCard")
                pType = PaymentTypes.KrediKarti;
        }

        private void nuShopBag_ValueChanged(object sender, EventArgs e)
        {
            if (nuShopBag.Value < tut)
            {
                _totalPrice -= (tut-nuShopBag.Value) * (decimal)_bagPrice;
                lblTotalPrice.Text = $"{_totalPrice:c2}";
            }
            else if (nuShopBag.Value > tut)
            {
                _totalPrice += (nuShopBag.Value-tut) * (decimal)_bagPrice;
                lblTotalPrice.Text = $"{_totalPrice:c2}";
            }
            tut = nuShopBag.Value;
        }
        decimal tut=0;
        

        private void btnPayment_Click(object sender, EventArgs e)
        {

            if (rbCash.Checked == true)
            {
                paidMoney = decimal.Parse(txtOdenenPara.Text);
            }


            new SaleRepo().SalesBusiness(pType, products, paidMoney,_totalPrice, out this.id, out remainderOfMoney,nuSellQuantity.Value);
            #region stock düşümü
            var prods = new ProductRepo().GetAll();
            foreach (var prod in prods)
            {
                foreach (ListViewItem item in lvBuyList.Items)
                {
                    if (item.Text == prod.Barcode)
                    {
                        prod.StockQuantity = prod.StockQuantity - Convert.ToDecimal(item.SubItems[2].Text);
                    }
                }
            }
            int a = new ProductRepo().Update();
            #endregion
            lblRemainderOfMoney.Text = remainderOfMoney.ToString();
            MessageBox.Show($"Fiş numarasi : {id}, Yine bekleriz..");

            #region pdf
            /// --------------------pdf için düzenlenecek
            Sale sale = new Sale();
            SaleDetail sd = new SaleDetail();
            List<SaleDetailViewModel> saleDetailViewModels = new List<SaleDetailViewModel>();
            SaleViewModel saleViewModel = new SaleViewModel()
            {
                id = sale.Id,
                PaymentTypes = sale.PaymentTypes,
                SaleDetailList = saleDetailViewModels

            };
            SaleDetailViewModel saleDetailViewModel = new SaleDetailViewModel()
            {
                id = sd.Id,
                id2 = sd.Id2,
                ProductName = sd.ProductName,
                Quantity = sd.Quantity,
                TotalPrice = sd.TotalPrice
            };
            
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", ValidateNames = true })
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Document doc = new Document(PageSize.A5.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        var urunsatis = lvBuyList.Items;


                        doc.Add(new Paragraph("Wissen \nBesiktas/ISTANBUL \nKuloglu Mh., Barbaros Blv. Yildiz IS Hani No:9"));
                        doc.Add(new Paragraph($"\nFis No:{id}\nTarih:{sale.CreatedDate}\n"));
                        doc.Add(new Paragraph("\nÜrün Listesi\n------------------------------------------------------\n"));                    
                        foreach (var item in urunsatis)
                        {
                            //doc.Add(new Paragraph(Convert.ToString(ProductName.ToList())));
                            doc.Add(new Paragraph(item.ToString()));
                        }
                        if (rbCash.Checked == true)
                        {
                            pymnt = "Nakit ";
                           
                                doc.Add(new Paragraph($"------------------------------------------------------\nAlinan Para: {txtOdenenPara.Text}\nPara Üstü:{Convert.ToDecimal(lblRemainderOfMoney.Text):c2}"));
 
                        }
                        else if (rbCreditCard.Checked == true)
                        {
                            pymnt = "Kredi Kartı";
                            doc.Add(new Paragraph($"------------------------------------------------------\nAlinan Para: {lblTotalPrice.Text}"));
                        }

                        doc.Add(new Paragraph($"\nÖdeme Yöntemi : {pymnt}"));
                        doc.Add(new Paragraph($"\nTutar : {lblTotalPrice.Text:c2}"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    finally
                    {
                        doc.Close();
                    }
                }
            #endregion
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