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
            this.lstSaleDetail = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nuSellQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSellingBarcode
            // 
            this.txtSellingBarcode.Location = new System.Drawing.Point(122, 19);
            this.txtSellingBarcode.Name = "txtSellingBarcode";
            this.txtSellingBarcode.Size = new System.Drawing.Size(120, 20);
            this.txtSellingBarcode.TabIndex = 0;
            this.txtSellingBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingBarcode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Barcode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Adet";
            // 
            // nuSellQuantity
            // 
            this.nuSellQuantity.Location = new System.Drawing.Point(122, 45);
            this.nuSellQuantity.Name = "nuSellQuantity";
            this.nuSellQuantity.Size = new System.Drawing.Size(120, 20);
            this.nuSellQuantity.TabIndex = 5;
            // 
            // lstSaleDetail
            // 
            this.lstSaleDetail.FormattingEnabled = true;
            this.lstSaleDetail.Location = new System.Drawing.Point(352, 19);
            this.lstSaleDetail.Name = "lstSaleDetail";
            this.lstSaleDetail.Size = new System.Drawing.Size(216, 290);
            this.lstSaleDetail.TabIndex = 9;
            // 
            // FrmSatis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstSaleDetail);
            this.Controls.Add(this.nuSellQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSellingBarcode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSatis";
            this.Text = "FrmSatis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSatis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuSellQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSellingBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuSellQuantity;
        private System.Windows.Forms.ListBox lstSaleDetail;
    }
}