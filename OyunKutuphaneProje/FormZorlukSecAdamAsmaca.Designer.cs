namespace OyunKutuphaneProje
{
    partial class FormZorlukSecAdamAsmaca
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
            this.lblSec = new System.Windows.Forms.Label();
            this.btnKolay = new System.Windows.Forms.Button();
            this.btnZor = new System.Windows.Forms.Button();
            this.btnOrta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSec.Location = new System.Drawing.Point(315, 26);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(167, 73);
            this.lblSec.TabIndex = 0;
            this.lblSec.Text = "SEC";
            // 
            // btnKolay
            // 
            this.btnKolay.BackColor = System.Drawing.Color.GhostWhite;
            this.btnKolay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKolay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKolay.Location = new System.Drawing.Point(113, 102);
            this.btnKolay.Name = "btnKolay";
            this.btnKolay.Size = new System.Drawing.Size(176, 72);
            this.btnKolay.TabIndex = 1;
            this.btnKolay.Text = "Kolay";
            this.btnKolay.UseVisualStyleBackColor = false;
            this.btnKolay.Click += new System.EventHandler(this.btnKolay_Click);
            // 
            // btnZor
            // 
            this.btnZor.BackColor = System.Drawing.Color.GhostWhite;
            this.btnZor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnZor.Location = new System.Drawing.Point(497, 102);
            this.btnZor.Name = "btnZor";
            this.btnZor.Size = new System.Drawing.Size(176, 72);
            this.btnZor.TabIndex = 2;
            this.btnZor.Text = "Zor";
            this.btnZor.UseVisualStyleBackColor = false;
            this.btnZor.Click += new System.EventHandler(this.btnZor_Click);
            // 
            // btnOrta
            // 
            this.btnOrta.BackColor = System.Drawing.Color.GhostWhite;
            this.btnOrta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOrta.Location = new System.Drawing.Point(306, 102);
            this.btnOrta.Name = "btnOrta";
            this.btnOrta.Size = new System.Drawing.Size(176, 72);
            this.btnOrta.TabIndex = 3;
            this.btnOrta.Text = "Orta";
            this.btnOrta.UseVisualStyleBackColor = false;
            this.btnOrta.Click += new System.EventHandler(this.btnOrta_Click);
            // 
            // FormZorlukSecAdamAsmaca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(780, 225);
            this.Controls.Add(this.btnOrta);
            this.Controls.Add(this.btnZor);
            this.Controls.Add(this.btnKolay);
            this.Controls.Add(this.lblSec);
            this.Name = "FormZorlukSecAdamAsmaca";
            this.Text = "FormZorlukSecAdamAsmaca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Button btnKolay;
        private System.Windows.Forms.Button btnZor;
        private System.Windows.Forms.Button btnOrta;
    }
}