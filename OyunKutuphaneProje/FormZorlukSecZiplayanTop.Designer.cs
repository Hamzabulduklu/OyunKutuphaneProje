﻿namespace OyunKutuphaneProje
{
    partial class FormZorlukSecZiplayanTop
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnKolay = new System.Windows.Forms.Button();
            this.btnZor = new System.Windows.Forms.Button();
            this.btnOrta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(298, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEC";
            // 
            // btnKolay
            // 
            this.btnKolay.BackColor = System.Drawing.Color.White;
            this.btnKolay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKolay.Location = new System.Drawing.Point(32, 100);
            this.btnKolay.Name = "btnKolay";
            this.btnKolay.Size = new System.Drawing.Size(198, 74);
            this.btnKolay.TabIndex = 1;
            this.btnKolay.Text = "KOLAY";
            this.btnKolay.UseVisualStyleBackColor = false;
            this.btnKolay.Click += new System.EventHandler(this.btnKolay_Click);
            // 
            // btnZor
            // 
            this.btnZor.BackColor = System.Drawing.Color.White;
            this.btnZor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnZor.Location = new System.Drawing.Point(495, 100);
            this.btnZor.Name = "btnZor";
            this.btnZor.Size = new System.Drawing.Size(198, 74);
            this.btnZor.TabIndex = 2;
            this.btnZor.Text = "ZOR";
            this.btnZor.UseVisualStyleBackColor = false;
            this.btnZor.Click += new System.EventHandler(this.btnZor_Click);
            // 
            // btnOrta
            // 
            this.btnOrta.BackColor = System.Drawing.Color.White;
            this.btnOrta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOrta.Location = new System.Drawing.Point(264, 100);
            this.btnOrta.Name = "btnOrta";
            this.btnOrta.Size = new System.Drawing.Size(198, 74);
            this.btnOrta.TabIndex = 3;
            this.btnOrta.Text = "ORTA";
            this.btnOrta.UseVisualStyleBackColor = false;
            this.btnOrta.Click += new System.EventHandler(this.btnOrta_Click);
            // 
            // FormZorlukSecZiplayanTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(737, 233);
            this.Controls.Add(this.btnOrta);
            this.Controls.Add(this.btnZor);
            this.Controls.Add(this.btnKolay);
            this.Controls.Add(this.label1);
            this.Name = "FormZorlukSecZiplayanTop";
            this.Text = "FormZorlukSecZiplayanTop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKolay;
        private System.Windows.Forms.Button btnZor;
        private System.Windows.Forms.Button btnOrta;
    }
}