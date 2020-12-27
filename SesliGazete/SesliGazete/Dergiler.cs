using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Data.SqlClient;

namespace SesliGazete
{
    public partial class Dergiler : Form
    {
        int i = 0;
        public Dergiler()
        {
            InitializeComponent();
        }
        private void Dergiler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sesli_OkumaDataSet.Dergiler' table. You can move, or remove it, as needed.
            this.dergilerTableAdapter.Fill(this.sesli_OkumaDataSet.Dergiler);
            timer1.Start();
            // TODO: This line of code loads data into the 'sesli_OkumaDataSet.Dergiler' table. You can move, or remove it, as needed.
            //this.dergilerTableAdapter.Fill(this.sesli_OkumaDataSet.Dergiler);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Sırayla listboxdaki dergileri okutma.
            if (i < listBox1.Items.Count)
            {
                SpVoice okut = new SpVoice();
                listBox1.SetSelected(i, true);
                label1.Text = listBox1.SelectedValue.ToString();
                okut.Speak(label1.Text);
            }
            else
            {
                //Dergiler okunduktan sonra seçilmemiş ise birşey tekrardan dinlemek için message box gösterir. 'T' tuşu ile yeniden okur.
                MessageBox.Show("Dergileri Tekrar Dinlemek İçin Klavyeden 'T' Tuşuna Basınız.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            i++;
        }

        private void btnDur_Click(object sender, EventArgs e)
        {
            //labeldeki değer başlık ve içerik formuna yollandı.
            timer1.Stop();
            DergiHaber dh = new DergiHaber();
            dh.Show();
            dh.dergiHbrLbl.Text = label1.Text;
            this.Hide();
        }

        private void Dergiler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main anasayfaDon = new Main();
            anasayfaDon.Show();
        }

        private void Dergiler_KeyDown(object sender, KeyEventArgs e)
        {
            //'Y' tuşuna basıldığında okunan dergi isminde durur.
            if (e.KeyCode == Keys.Y)
            {
                btnDur.PerformClick();
            }
            //'T' tuşuna basıldığında en baştan tekrar okumaya başlar.
            if (e.KeyCode == Keys.T)
            {
                i = 0;
                timer1.Start();
            }
            //'B' tuşuna basıldığında Gazete mi Dergi Mi Menüsüne Döner.
            if (e.KeyCode == Keys.B)
            {
                this.Close();
            }
        }
    }
}
