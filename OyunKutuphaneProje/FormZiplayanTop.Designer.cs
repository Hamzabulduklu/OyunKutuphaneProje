namespace OyunKutuphaneProje
{
    partial class FormZiplayanTop
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
            this.components = new System.ComponentModel.Container();
            this.pnlOyunAlani = new System.Windows.Forms.Panel();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pnlOyunAlani
            // 
            this.pnlOyunAlani.Location = new System.Drawing.Point(12, 74);
            this.pnlOyunAlani.Name = "pnlOyunAlani";
            this.pnlOyunAlani.Size = new System.Drawing.Size(466, 334);
            this.pnlOyunAlani.TabIndex = 0;
            // 
            // btnBaslat
            // 
            this.btnBaslat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.Location = new System.Drawing.Point(494, 364);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(108, 44);
            this.btnBaslat.TabIndex = 1;
            this.btnBaslat.Text = "BASLAT";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(15, 26);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(121, 31);
            this.lblDurum.TabIndex = 2;
            this.lblDurum.Text = "DURUM";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            // 
            // FormZiplayanTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(614, 417);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.pnlOyunAlani);
            this.KeyPreview = true;
            this.Name = "FormZiplayanTop";
            this.Text = "FormZiplayanTop";
            this.Load += new System.EventHandler(this.FormZiplayanTop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlOyunAlani;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Timer timer1;
    }
}