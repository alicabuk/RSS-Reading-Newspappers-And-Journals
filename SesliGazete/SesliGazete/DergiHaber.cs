using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using SpeechLib;

namespace SesliGazete
{
    public partial class DergiHaber : Form
    {
        int i = 0; //dergi başlıklarını sırayla seçip okutma işlemi için oluşturuldu.
        int secilenbaslikindex, titleindex = 0, descriptionindex = 0, kalanyer = 0; //başlık,içerik indexi tutuluyor. kalanyer ise içerik okutulduktan sonra dönülen yer.
        string[,] dizi = new string[300, 2];//RSS de okutulan başlık ve içerikler dizi de tutuluyor.

        //veri tabanı sınıfımızdan nesne türeterek bağlanma sağlanıyor.
        SqlBaglanti bgl = new SqlBaglanti();

        public DergiHaber()
        {
            InitializeComponent();
        }

        private void DergiHaber_Load(object sender, EventArgs e)
        {
            //form yüklendiğinde timer1 ve timer2 eventleri başlatılıyor.Böylelikle haber başlıkları otomatik olarak okutulması sağlanıyor.
            timer1.Start();
            timer2.Start();
        }
        private void DergiHaber_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formun kapanma olayı ile bir önceki dergiler sekmesine dönüyor.
            Dergiler baslikDon = new Dergiler();
            baslikDon.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //form yüklendiğinde timer1 otomatik başlatılıyor.Bundan dolayı form yüklendiğinde Rss Dataları Çekilip title'lar direk geliyor.
            //veritabanından bir önceki formda seçili olan derginin rss datası alınıyor.
            SqlCommand komut = new SqlCommand("select DergiRSS from Dergiler where DergiAD='" + dergiHbrLbl.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //çekilen rss datasının içerisinde yazan dergi başlıkları okutuluyor.
                XmlTextReader xmloku = new XmlTextReader(dr["DergiRSS"].ToString());
                while (xmloku.Read())
                {
                    if (xmloku.Name == "title")
                    {
                        //okutulan dergi başlıkları listbox objesine sırayla ekleniyor.
                        listBox1.Items.Add(xmloku.ReadString());
                    }
                }
            }
            //Dergi Okunmadan işlem yapılırsa form açılması iptal.
            if (dergiHbrLbl.Text == "")
            {
                MessageBox.Show("Lütfen Dergi İsimlerinin Okumasını Bekleyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            bgl.baglanti().Close();

            //timer1 durduruluyor yoksa tekrar tekrar başlıkları çekecektir.
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1 başlatıldığında button tıklama yapılarak işlemleri yaptırılır. Form otomatik verilerle dolduruluyor.
            button1.PerformClick();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //son dergi yazısına gelene kadar dönecektir.
            if (i < listBox1.Items.Count)
            {
                //bir dergi seçildikten sonra tekrar seçildiğinde kalınan yerden devam etmesi sağlanıyor.
                kalanyer = i;

                //setSelected özelliği ile listboxdaki başlıkları seçtiriliyor.Seçtirilen başlık okutulma işlemi sağlanıyor.
                SpVoice okutma = new SpVoice();
                listBox1.SetSelected(i, true);
                /*Boş Değerleri Sildirme işlemi gerekirse kullanılacak.
                  if (listBox1.SelectedItem == "") 
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
                */
                lblOku.Text = listBox1.Items[i].ToString();
                okutma.Speak(lblOku.Text);
            }
            else
            {
                //tüm dergi yazıları bittiyse eğer bilgilendirme mesajı verilecektir.
                MessageBox.Show("Dergileri Tekrar Dinlemek İçin Klavyeden 'T' Tuşuna Basınız.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //timer2 çalıştığı sürece i değişkeni 1 arttırılarak sırayla dergi başlıkları okutulması sağlanıyor.
            i++;
        }

        private void DergiHaber_KeyDown(object sender, KeyEventArgs e)
        {
            //klavyeden 'Y' tuşuna basıldığında seçilen başlığın içeriği okutuluyor.
            if (e.KeyCode == Keys.Y)
            {
                //timer2 durdularak içerik okutuluyor böylece dergi başlıkları okuması duruyor.
                timer2.Stop();

                //veritabanından bir önceki formda seçilen derginin rss datası çekiliyor.
                SqlCommand komut1 = new SqlCommand("select DergiRSS from Dergiler where DergiAD='" + dergiHbrLbl.Text + "'", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    //çekilen rss datası okutuluyor.
                    XmlTextReader xmlicerikoku = new XmlTextReader(dr1["DergiRSS"].ToString());
                    while (xmlicerikoku.Read())
                    {

                        //çekilen rss datasındaki dergi başlıkları çekiliyor
                        if (xmlicerikoku.Name == "title")
                        {
                            //okunan başlık oluşturulan dizide 0.sütuna yazılıyor.
                            dizi[titleindex, 0] = xmlicerikoku.ReadString();

                            //kullanıcının seçtiği başlık kontrol işlemi
                            if (dizi[titleindex, 0] == lblOku.Text)
                            {
                                //seçilen başlık için tutma işlemi yapılıyor.
                                secilenbaslikindex = titleindex;
                                /* Test İşlemi.
                                  MessageBox.Show("secilen:" + secilenbaslikindex);
                                  MessageBox.Show("secilen:" + dizi[secilenbaslikindex, 0]);
                                */
                            }

                            //diziye sırayla ekleme yapması için 1 arttırılıyor.
                            titleindex++;
                        }

                        //çekilen rss datasındaki dergi içerikleri çekiliyor
                        if (xmlicerikoku.Name == "description")
                        {
                            //okunan içerikler oluşturulan dizide 1.sütuna yazılıyor.
                            dizi[descriptionindex, 1] = xmlicerikoku.ReadString();

                            //kullanıcının seçtiği başlık indexi bizim içerik indeximize eşit mi kontrol ediliyor.
                            if (secilenbaslikindex == descriptionindex)
                            {
                                //seçili olan başlığı doğruya richTextBox'ımızın içine içeriğimizi yazdırıyoruz.
                                richTextBox1.Text = dizi[descriptionindex, 1];
                               /*Test işlemi.
                                MessageBox.Show("secilen:" + dizi[descriptionindex, 1]);
                                MessageBox.Show("secilen:" + descriptionindex);
                               */
                            }

                            //diziye sırayla ekleme yapılıyor.
                            descriptionindex++;
                        }

                    }
                }
                //seçilen başlığın içeriği okutuluyor.
                SpVoice icerikokutma = new SpVoice();
                icerikokutma.Speak(richTextBox1.Text);

                //içerik okutulduktan sonra kalan başlıktan devam etmesi sağlanıyor.
                i = kalanyer + 1;

                //tekrardan dizi değerleri 0'lanıyor.
                titleindex = 0;
                descriptionindex = 0;

                //timer2 başlatılarak kaldığı yerden haber başlıkları okutulmaya devam ediyor.
                timer2.Start();

                //veri tabanı bağlantısı kapatılıyor.
                bgl.baglanti().Close();
            }

            //Eğer Tüm Dergi Okunmuşsa Klavyeden 'T' tuşuna basıldığında tekrardan tüm haber başlıklarını okur.
            if (e.KeyCode == Keys.T)
            {
                //timer2'de Dergiler listboxa ekleniyor.O yüzden i değişkeni sıfırlayıp timerımızı başlatıyoruz.
                i = 0;
                timer2.Start();
            }

            //Klavyeden 'B' tuşuna basıldığında form kapanıp bir önceki form açılmaktadır.
            if (e.KeyCode == Keys.B)
            {
                this.Close();
            }
        }
    }
}
