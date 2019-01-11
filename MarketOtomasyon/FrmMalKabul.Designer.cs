namespace MarketOtomasyon
{
    partial class FrmMalKabul
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
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.nuPackageQuantity = new System.Windows.Forms.NumericUpDown();
            this.nuQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtBarcodePackage = new System.Windows.Forms.TextBox();
            this.txtBarcodeProduct = new System.Windows.Forms.TextBox();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.btnMalKabul = new System.Windows.Forms.Button();
            this.tvProduct = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSepeteEkle = new System.Windows.Forms.Button();
            this.lstOrderDetails = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuPackageQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCategory
            // 
            this.txtCategory.Enabled = false;
            this.txtCategory.Location = new System.Drawing.Point(76, 92);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(120, 20);
            this.txtCategory.TabIndex = 0;
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(75, 118);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(120, 20);
            this.txtProduct.TabIndex = 1;
            // 
            // nuPackageQuantity
            // 
            this.nuPackageQuantity.Enabled = false;
            this.nuPackageQuantity.Location = new System.Drawing.Point(75, 145);
            this.nuPackageQuantity.Name = "nuPackageQuantity";
            this.nuPackageQuantity.Size = new System.Drawing.Size(120, 20);
            this.nuPackageQuantity.TabIndex = 2;
            // 
            // nuQuantity
            // 
            this.nuQuantity.Location = new System.Drawing.Point(75, 171);
            this.nuQuantity.Name = "nuQuantity";
            this.nuQuantity.Size = new System.Drawing.Size(120, 20);
            this.nuQuantity.TabIndex = 3;
            // 
            // txtBarcodePackage
            // 
            this.txtBarcodePackage.Location = new System.Drawing.Point(76, 23);
            this.txtBarcodePackage.Name = "txtBarcodePackage";
            this.txtBarcodePackage.Size = new System.Drawing.Size(120, 20);
            this.txtBarcodePackage.TabIndex = 4;
            this.txtBarcodePackage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodePackage_KeyDown);
            // 
            // txtBarcodeProduct
            // 
            this.txtBarcodeProduct.Location = new System.Drawing.Point(289, 23);
            this.txtBarcodeProduct.Name = "txtBarcodeProduct";
            this.txtBarcodeProduct.Size = new System.Drawing.Size(120, 20);
            this.txtBarcodeProduct.TabIndex = 5;
            this.txtBarcodeProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcodeProduct_KeyDown);
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Location = new System.Drawing.Point(75, 197);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(120, 20);
            this.txtBuyPrice.TabIndex = 6;
            // 
            // btnMalKabul
            // 
            this.btnMalKabul.Location = new System.Drawing.Point(316, 171);
            this.btnMalKabul.Name = "btnMalKabul";
            this.btnMalKabul.Size = new System.Drawing.Size(93, 46);
            this.btnMalKabul.TabIndex = 7;
            this.btnMalKabul.Text = "Mal Kabul";
            this.btnMalKabul.UseVisualStyleBackColor = true;
            this.btnMalKabul.Click += new System.EventHandler(this.btnMalKabul_Click);
            // 
            // tvProduct
            // 
            this.tvProduct.Location = new System.Drawing.Point(445, 20);
            this.tvProduct.Name = "tvProduct";
            this.tvProduct.Size = new System.Drawing.Size(121, 194);
            this.tvProduct.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Koli Barkod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ürün Barkod";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kategori";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ürün Adı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Koli İçi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Adet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Alış Fiyatı";
            // 
            // btnSepeteEkle
            // 
            this.btnSepeteEkle.Location = new System.Drawing.Point(217, 171);
            this.btnSepeteEkle.Name = "btnSepeteEkle";
            this.btnSepeteEkle.Size = new System.Drawing.Size(93, 46);
            this.btnSepeteEkle.TabIndex = 16;
            this.btnSepeteEkle.Text = "Sipariş Ekle";
            this.btnSepeteEkle.UseVisualStyleBackColor = true;
            this.btnSepeteEkle.Click += new System.EventHandler(this.btnSepeteEkle_Click);
            // 
            // lstOrderDetails
            // 
            this.lstOrderDetails.FormattingEnabled = true;
            this.lstOrderDetails.Location = new System.Drawing.Point(217, 53);
            this.lstOrderDetails.Name = "lstOrderDetails";
            this.lstOrderDetails.Size = new System.Drawing.Size(192, 108);
            this.lstOrderDetails.TabIndex = 17;
            // 
            // FrmMalKabul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 241);
            this.Controls.Add(this.lstOrderDetails);
            this.Controls.Add(this.btnSepeteEkle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvProduct);
            this.Controls.Add(this.btnMalKabul);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.txtBarcodeProduct);
            this.Controls.Add(this.txtBarcodePackage);
            this.Controls.Add(this.nuQuantity);
            this.Controls.Add(this.nuPackageQuantity);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtCategory);
            this.Name = "FrmMalKabul";
            this.Text = "MalKabul";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMalKabul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuPackageQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.NumericUpDown nuPackageQuantity;
        private System.Windows.Forms.NumericUpDown nuQuantity;
        private System.Windows.Forms.TextBox txtBarcodePackage;
        private System.Windows.Forms.TextBox txtBarcodeProduct;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Button btnMalKabul;
        private System.Windows.Forms.TreeView tvProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSepeteEkle;
        private System.Windows.Forms.ListBox lstOrderDetails;
    }
}