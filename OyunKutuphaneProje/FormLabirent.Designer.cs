namespace OyunKutuphaneProje
{
    partial class FormLabirent
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
            this.lblDurum = new System.Windows.Forms.Label();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.pnlLabirent = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDurum.Location = new System.Drawing.Point(39, 18);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(121, 31);
            this.lblDurum.TabIndex = 0;
            this.lblDurum.Text = "DURUM";
            // 
            // btnBaslat
            // 
            this.btnBaslat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.Location = new System.Drawing.Point(26, 365);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(143, 63);
            this.btnBaslat.TabIndex = 1;
            this.btnBaslat.Text = "Baslat";
            this.btnBaslat.UseVisualStyleBackColor = false;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // pnlLabirent
            // 
            this.pnlLabirent.Location = new System.Drawing.Point(234, 57);
            this.pnlLabirent.Name = "pnlLabirent";
            this.pnlLabirent.Size = new System.Drawing.Size(424, 391);
            this.pnlLabirent.TabIndex = 2;
            // 
            // FormLabirent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(719, 478);
            this.Controls.Add(this.pnlLabirent);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.lblDurum);
            this.KeyPreview = true;
            this.Name = "FormLabirent";
            this.Text = "FormLabirent";
            this.Load += new System.EventHandler(this.FormLabirent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Panel pnlLabirent;
        private System.Windows.Forms.Timer timer1;
    }
}