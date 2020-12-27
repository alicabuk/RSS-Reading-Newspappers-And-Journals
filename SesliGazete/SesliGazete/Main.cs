using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SesliGazete
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
        }

        private void btnGazete_Click(object sender, EventArgs e)
        {
            Gazeteler gazetelerSayfa = new Gazeteler();
            gazetelerSayfa.Show();
            this.Hide();
        }

        private void btnDergi_Click(object sender, EventArgs e)
        {
            Dergiler dergilerSayfa = new Dergiler();
            dergilerSayfa.Show();
            this.Hide();
        }

        private void Main_KeyDown_1(object sender, KeyEventArgs e)
        {
            //Main içinde Gazeteler modülü açılması için kısayol ataması klavyeden 'G' tuşu olarak belirlendi.
            if (e.KeyCode == Keys.G)
            {
                btnGazete.PerformClick();
            }
            //Main içinde Dergiler modülü açılması için kısayol ataması klavyeden 'D' tuşu olarak belirlendi.
            if (e.KeyCode == Keys.D)
            {
                btnDergi.PerformClick();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
