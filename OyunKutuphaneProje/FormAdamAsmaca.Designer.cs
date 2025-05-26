namespace OyunKutuphaneProje
{
    partial class FormAdamAsmaca
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
            this.lblKelime = new System.Windows.Forms.Label();
            this.lblKalanHak = new System.Windows.Forms.Label();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.btnTahmin = new System.Windows.Forms.Button();
            this.txtHarf = new System.Windows.Forms.TextBox();
            this.picAdam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAdam)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKelime
            // 
            this.lblKelime.AutoSize = true;
            this.lblKelime.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKelime.Location = new System.Drawing.Point(25, 264);
            this.lblKelime.Name = "lblKelime";
            this.lblKelime.Size = new System.Drawing.Size(217, 39);
            this.lblKelime.TabIndex = 0;
            this.lblKelime.Text = "_ _ _ _ _ _ _";
            // 
            // lblKalanHak
            // 
            this.lblKalanHak.AutoSize = true;
            this.lblKalanHak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKalanHak.Location = new System.Drawing.Point(28, 193);
            this.lblKalanHak.Name = "lblKalanHak";
            this.lblKalanHak.Size = new System.Drawing.Size(118, 20);
            this.lblKalanHak.TabIndex = 1;
            this.lblKalanHak.Text = "Kalan hak:.....";
            this.lblKalanHak.Click += new System.EventHandler(this.lblKalanHak_Click);
            // 
            // lblMesaj
            // 
            this.lblMesaj.AutoSize = true;
            this.lblMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMesaj.Location = new System.Drawing.Point(195, 411);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(209, 16);
            this.lblMesaj.TabIndex = 2;
            this.lblMesaj.Text = "Baslamak için BASLAT a bas";
            // 
            // btnBaslat
            // 
            this.btnBaslat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.Location = new System.Drawing.Point(198, 337);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(222, 48);
            this.btnBaslat.TabIndex = 3;
            this.btnBaslat.Text = "BASLAT";
            this.btnBaslat.UseVisualStyleBackColor = false;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // btnTahmin
            // 
            this.btnTahmin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTahmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTahmin.Location = new System.Drawing.Point(136, 101);
            this.btnTahmin.Name = "btnTahmin";
            this.btnTahmin.Size = new System.Drawing.Size(169, 65);
            this.btnTahmin.TabIndex = 4;
            this.btnTahmin.Text = "Tahmin ET";
            this.btnTahmin.UseVisualStyleBackColor = false;
            this.btnTahmin.Click += new System.EventHandler(this.btnTahmin_Click);
            // 
            // txtHarf
            // 
            this.txtHarf.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHarf.Location = new System.Drawing.Point(136, 38);
            this.txtHarf.Name = "txtHarf";
            this.txtHarf.Size = new System.Drawing.Size(169, 44);
            this.txtHarf.TabIndex = 5;
            // 
            // picAdam
            // 
            this.picAdam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picAdam.Location = new System.Drawing.Point(457, 12);
            this.picAdam.Name = "picAdam";
            this.picAdam.Size = new System.Drawing.Size(304, 415);
            this.picAdam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdam.TabIndex = 6;
            this.picAdam.TabStop = false;
            // 
            // FormAdamAsmaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picAdam);
            this.Controls.Add(this.txtHarf);
            this.Controls.Add(this.btnTahmin);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.lblKalanHak);
            this.Controls.Add(this.lblKelime);
            this.Name = "FormAdamAsmaca";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormAdamAsmaca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAdam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKelime;
        private System.Windows.Forms.Label lblKalanHak;
        private System.Windows.Forms.Label lblMesaj;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnTahmin;
        private System.Windows.Forms.TextBox txtHarf;
        private System.Windows.Forms.PictureBox picAdam;
    }
}