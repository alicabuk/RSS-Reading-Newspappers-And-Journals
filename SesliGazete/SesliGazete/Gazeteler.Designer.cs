namespace SesliGazete
{
    partial class Gazeteler
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.gazetelerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sesli_OkumaDataSet2 = new SesliGazete.Sesli_OkumaDataSet2();
            this.label1 = new System.Windows.Forms.Label();
            this.gazetelerTableAdapter1 = new SesliGazete.Sesli_OkumaDataSet2TableAdapters.GazetelerTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gazetelerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesli_OkumaDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.gazetelerBindingSource1;
            this.listBox1.DisplayMember = "GazeteAD";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(12, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 379);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "GazeteAD";
            // 
            // gazetelerBindingSource1
            // 
            this.gazetelerBindingSource1.DataMember = "Gazeteler";
            this.gazetelerBindingSource1.DataSource = this.sesli_OkumaDataSet2;
            // 
            // sesli_OkumaDataSet2
            // 
            this.sesli_OkumaDataSet2.DataSetName = "Sesli_OkumaDataSet2";
            this.sesli_OkumaDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            // 
            // gazetelerTableAdapter1
            // 
            this.gazetelerTableAdapter1.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDur
            // 
            this.btnDur.Location = new System.Drawing.Point(235, 195);
            this.btnDur.Name = "btnDur";
            this.btnDur.Size = new System.Drawing.Size(75, 24);
            this.btnDur.TabIndex = 3;
            this.btnDur.Text = "Dur";
            this.btnDur.UseVisualStyleBackColor = true;
            this.btnDur.Click += new System.EventHandler(this.btnDur_Click);
            // 
            // Gazeteler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(229, 404);
            this.Controls.Add(this.btnDur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Gazeteler";
            this.Text = "Gazeteler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Gazeteler_FormClosed);
            this.Load += new System.EventHandler(this.Gazeteler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gazeteler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gazetelerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sesli_OkumaDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private Sesli_OkumaDataSet2 sesli_OkumaDataSet2;
        private System.Windows.Forms.BindingSource gazetelerBindingSource1;
        private Sesli_OkumaDataSet2TableAdapters.GazetelerTableAdapter gazetelerTableAdapter1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDur;
        public System.Windows.Forms.Label label1;
    }
}