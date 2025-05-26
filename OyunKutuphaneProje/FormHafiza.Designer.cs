namespace OyunKutuphaneProje
{
    partial class FormHafiza
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
            this.pnlKartlar = new System.Windows.Forms.Panel();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.lblDurum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlKartlar
            // 
            this.pnlKartlar.Location = new System.Drawing.Point(138, 55);
            this.pnlKartlar.Name = "pnlKartlar";
            this.pnlKartlar.Size = new System.Drawing.Size(540, 406);
            this.pnlKartlar.TabIndex = 0;
            // 
            // btnBaslat
            // 
            this.btnBaslat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBaslat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.Location = new System.Drawing.Point(12, 399);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(109, 48);
            this.btnBaslat.TabIndex = 1;
            this.btnBaslat.Text = "BASLAT";
            this.btnBaslat.UseVisualStyleBackColor = false;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(12, 21);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(121, 31);
            this.lblDurum.TabIndex = 2;
            this.lblDurum.Text = "DURUM";
            // 
            // FormHafiza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(715, 473);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.pnlKartlar);
            this.Name = "FormHafiza";
            this.Text = "FormHafiza";
            this.Load += new System.EventHandler(this.FormHafiza_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlKartlar;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Label lblDurum;
    }
}