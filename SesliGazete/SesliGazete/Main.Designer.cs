namespace SesliGazete
{
    partial class Main
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
            this.btnGazete = new System.Windows.Forms.Button();
            this.btnDergi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGazete
            // 
            this.btnGazete.Location = new System.Drawing.Point(12, 12);
            this.btnGazete.Name = "btnGazete";
            this.btnGazete.Size = new System.Drawing.Size(377, 347);
            this.btnGazete.TabIndex = 0;
            this.btnGazete.UseVisualStyleBackColor = true;
            this.btnGazete.Click += new System.EventHandler(this.btnGazete_Click);
            // 
            // btnDergi
            // 
            this.btnDergi.Location = new System.Drawing.Point(407, 12);
            this.btnDergi.Name = "btnDergi";
            this.btnDergi.Size = new System.Drawing.Size(384, 347);
            this.btnDergi.TabIndex = 0;
            this.btnDergi.UseVisualStyleBackColor = true;
            this.btnDergi.Click += new System.EventHandler(this.btnDergi_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(803, 371);
            this.Controls.Add(this.btnDergi);
            this.Controls.Add(this.btnGazete);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Sesli Gazete & Dergi Okuma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGazete;
        private System.Windows.Forms.Button btnDergi;
    }
}

