namespace SesliGazete
{
    partial class Dergiler
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDur = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sesli_OkumaDataSet = new SesliGazete.Sesli_OkumaDataSet();
            this.dergilerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dergilerTableAdapter = new SesliGazete.Sesli_OkumaDataSetTableAdapters.DergilerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sesli_OkumaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dergilerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.dergilerBindingSource;
            this.listBox1.DisplayMember = "DergiAD";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(10, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(412, 394);
            this.listBox1.TabIndex = 0;
            this.listBox1.ValueMember = "DergiAD";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 1;
            // 
            // btnDur
            // 
            this.btnDur.Location = new System.Drawing.Point(500, 203);
            this.btnDur.Name = "btnDur";
            this.btnDur.Size = new System.Drawing.Size(75, 23);
            this.btnDur.TabIndex = 2;
            this.btnDur.Text = "Dur";
            this.btnDur.UseVisualStyleBackColor = true;
            this.btnDur.Click += new System.EventHandler(this.btnDur_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sesli_OkumaDataSet
            // 
            this.sesli_OkumaDataSet.DataSetName = "Sesli_OkumaDataSet";
            this.sesli_OkumaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dergilerBindingSource
            // 
            this.dergilerBindingSource.DataMember = "Dergiler";
            this.dergilerBindingSource.DataSource = this.sesli_OkumaDataSet;
            // 
            // dergilerTableAdapter
            // 
            this.dergilerTableAdapter.ClearBeforeFill = true;
            // 
            // Dergiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(439, 422);
            this.Controls.Add(this.btnDur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Dergiler";
            this.Text = "Dergiler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dergiler_FormClosed);
            this.Load += new System.EventHandler(this.Dergiler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dergiler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sesli_OkumaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dergilerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
       // private Sesli_OkumaDataSetTableAdapters.DergilerTableAdapter dergilerTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDur;
        private System.Windows.Forms.Timer timer1;
        private Sesli_OkumaDataSet sesli_OkumaDataSet;
        private System.Windows.Forms.BindingSource dergilerBindingSource;
        private Sesli_OkumaDataSetTableAdapters.DergilerTableAdapter dergilerTableAdapter;
    }
}