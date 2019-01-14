namespace MarketOtomasyon
{
    partial class FrmSatis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSellingBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nuSellQuantity = new System.Windows.Forms.NumericUpDown();
            this.lstSaleDetails = new System.Windows.Forms.ListBox();
            this.lvBuyList = new System.Windows.Forms.ListView();
            this.prBarcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prUnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prSubTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prUnitInStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbCreditCard = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nuShopBag = new System.Windows.Forms.NumericUpDown();
            this.btnPayment = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPaidMoney = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRemainderOfMoney = new System.Windows.Forms.Label();
            this.txtOdenenPara = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuSellQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuShopBag)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSellingBarcode
            // 
            this.txtSellingBarcode.Location = new System.Drawing.Point(125, 56);
            this.txtSellingBarcode.Name = "txtSellingBarcode";
            this.txtSellingBarcode.Size = new System.Drawing.Size(120, 20);
            this.txtSellingBarcode.TabIndex = 0;
            this.txtSellingBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingBarcode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Barcode  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity :";
            // 
            // nuSellQuantity
            // 
            this.nuSellQuantity.Location = new System.Drawing.Point(125, 82);
            this.nuSellQuantity.Name = "nuSellQuantity";
            this.nuSellQuantity.Size = new System.Drawing.Size(120, 20);
            this.nuSellQuantity.TabIndex = 5;
            // 
            // lstSaleDetails
            // 
            this.lstSaleDetails.FormattingEnabled = true;
            this.lstSaleDetails.Location = new System.Drawing.Point(12, 148);
            this.lstSaleDetails.Name = "lstSaleDetails";
            this.lstSaleDetails.Size = new System.Drawing.Size(216, 290);
            this.lstSaleDetails.TabIndex = 9;
            // 
            // lvBuyList
            // 
            this.lvBuyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.prBarcode,
            this.prName,
            this.prQuantity,
            this.prUnitPrice,
            this.prSubTotal,
            this.prUnitInStock});
            this.lvBuyList.FullRowSelect = true;
            this.lvBuyList.Location = new System.Drawing.Point(296, 56);
            this.lvBuyList.Name = "lvBuyList";
            this.lvBuyList.Size = new System.Drawing.Size(492, 203);
            this.lvBuyList.TabIndex = 10;
            this.lvBuyList.UseCompatibleStateImageBehavior = false;
            this.lvBuyList.View = System.Windows.Forms.View.Details;
            // 
            // prBarcode
            // 
            this.prBarcode.Text = "Product Barcode";
            this.prBarcode.Width = 143;
            // 
            // prName
            // 
            this.prName.Text = "Product Name";
            this.prName.Width = 94;
            // 
            // prQuantity
            // 
            this.prQuantity.Text = "Quantity";
            this.prQuantity.Width = 55;
            // 
            // prUnitPrice
            // 
            this.prUnitPrice.Text = "Unit Price";
            // 
            // prSubTotal
            // 
            this.prSubTotal.Text = "Sub Total";
            // 
            // prUnitInStock
            // 
            this.prUnitInStock.Text = "Unit in Stock";
            this.prUnitInStock.Width = 74;
            // 
            // rbCreditCard
            // 
            this.rbCreditCard.AutoSize = true;
            this.rbCreditCard.Location = new System.Drawing.Point(571, 321);
            this.rbCreditCard.Name = "rbCreditCard";
            this.rbCreditCard.Size = new System.Drawing.Size(121, 17);
            this.rbCreditCard.TabIndex = 11;
            this.rbCreditCard.TabStop = true;
            this.rbCreditCard.Text = "Credit Card Payment";
            this.rbCreditCard.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(293, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Shopping Bag :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(293, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Shopping List :";
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(432, 321);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(93, 17);
            this.rbCash.TabIndex = 11;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash Payment";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(569, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Price :";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPrice.Location = new System.Drawing.Point(672, 282);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 17);
            this.lblTotalPrice.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(293, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Payment Type :";
            // 
            // nuShopBag
            // 
            this.nuShopBag.Location = new System.Drawing.Point(432, 279);
            this.nuShopBag.Name = "nuShopBag";
            this.nuShopBag.Size = new System.Drawing.Size(52, 20);
            this.nuShopBag.TabIndex = 12;
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(571, 367);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(217, 71);
            this.btnPayment.TabIndex = 13;
            this.btnPayment.Text = "PAYMENT";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(293, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Paid Money :";
            this.label7.Visible = false;
            // 
            // lblPaidMoney
            // 
            this.lblPaidMoney.AutoSize = true;
            this.lblPaidMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPaidMoney.Location = new System.Drawing.Point(412, 367);
            this.lblPaidMoney.Name = "lblPaidMoney";
            this.lblPaidMoney.Size = new System.Drawing.Size(0, 17);
            this.lblPaidMoney.TabIndex = 1;
            this.lblPaidMoney.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(293, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Remainder of Money :";
            this.label8.Visible = false;
            // 
            // lblRemainderOfMoney
            // 
            this.lblRemainderOfMoney.AutoSize = true;
            this.lblRemainderOfMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRemainderOfMoney.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblRemainderOfMoney.Location = new System.Drawing.Point(484, 410);
            this.lblRemainderOfMoney.Name = "lblRemainderOfMoney";
            this.lblRemainderOfMoney.Size = new System.Drawing.Size(0, 17);
            this.lblRemainderOfMoney.TabIndex = 1;
            this.lblRemainderOfMoney.Visible = false;
            // 
            // txtOdenenPara
            // 
            this.txtOdenenPara.Location = new System.Drawing.Point(405, 366);
            this.txtOdenenPara.Name = "txtOdenenPara";
            this.txtOdenenPara.Size = new System.Drawing.Size(120, 20);
            this.txtOdenenPara.TabIndex = 0;
            this.txtOdenenPara.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingBarcode_KeyDown);
            // 
            // FrmSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 502);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.nuShopBag);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.rbCreditCard);
            this.Controls.Add(this.lvBuyList);
            this.Controls.Add(this.lstSaleDetails);
            this.Controls.Add(this.nuSellQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRemainderOfMoney);
            this.Controls.Add(this.lblPaidMoney);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOdenenPara);
            this.Controls.Add(this.txtSellingBarcode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSatis";
            this.Text = "FrmSatis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.nuSellQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuShopBag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSellingBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuSellQuantity;
        private System.Windows.Forms.ListBox lstSaleDetails;
        private System.Windows.Forms.ListView lvBuyList;
        private System.Windows.Forms.ColumnHeader prBarcode;
        private System.Windows.Forms.ColumnHeader prName;
        private System.Windows.Forms.ColumnHeader prQuantity;
        private System.Windows.Forms.RadioButton rbCreditCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.ColumnHeader prUnitPrice;
        private System.Windows.Forms.ColumnHeader prSubTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuShopBag;
        private System.Windows.Forms.ColumnHeader prUnitInStock;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPaidMoney;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRemainderOfMoney;
        private System.Windows.Forms.TextBox txtOdenenPara;
    }
}