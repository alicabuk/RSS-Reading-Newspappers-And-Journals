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
    public partial class GazeteHaber : Form
    {
        int i = 0; //haber başlıklarını sırayla seçip okutma işlemi için oluşturuldu.
        int secilenbaslikindex,titleindex=0,descriptionindex=1,kalanyer=0; //başlık,içerik indexi tutuluyor. kalanyer ise içerik okutulduktan sonra dönülen yer.
        string[,] dizi = new string[300,2];//RSS de okutulan başlık ve içerikler dizi de tutuluyor.
        public GazeteHaber()
        {
            InitializeComponent();
        }

        //veri tabanı sınıfımızdan nesne türeterek bağlanma sağlanıyor.
        SqlBaglanti bgl = new SqlBaglanti();
        private void GazeteHaber_FormClosed(object sender, FormClosedEventArgs e)
        {
            //formun kapanma olayı ile bir önceki gazeteler sekmesine dönüyor.
            Gazeteler baslikDon = new Gazeteler();
            baslikDon.Show();
        }

        private void GazeteHaber_Load(object sender, EventArgs e)
        {
            //form yüklendiğinde timer1 ve timer2 eventleri başlatılıyor.Böylelikle haber başlıkları otomatik olarak okutulması sağlanıyor.
            timer1.Start();
            timer2.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //form yüklendiğinde timer1 otomatik başlatılıyor.Bundan dolayı form yüklendiğinde Rss Dataları Çekilip title'lar direk geliyor.
            //veritabanından bir önceki formda seçili olan gazetenin rss datası alınıyor.
            SqlCommand komut = new SqlCommand("select GazeteRSS from Gazeteler where GazeteAD='" + gztHaberLbl.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                //çekilen rss datasının içerisinde yazan haber başlıkları okutuluyor.
                XmlTextReader xmloku = new XmlTextReader(dr["GazeteRSS"].ToString());
                while (xmloku.Read())
                {
                    if (xmloku.Name == "title")
                    {
                        //okutulan haber başlıkları listbox objesine sırayla ekleniyor.
                        listBox1.Items.Add(xmloku.ReadString());                       
                    }
                }
            }
            //Gazete Okunmadan işlem yapılırsa form açılması iptal.
            if (gztHaberLbl.Text=="") {
                MessageBox.Show("Lütfen Gazete İsimlerinin Okumasını Bekleyiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else {
                //ilk index boş olduğu için silme işlemi yapıldı.
                listBox1.Items.RemoveAt(0);
            }
            bgl.baglanti().Close();

            //timer1 durduruluyor yoksa tekrar tekrar başlıkları çekecektir.
            timer1.Stop();
        }

        private void GazeteHaber_KeyDown(object sender, KeyEventArgs e)
        {
            //klavyeden 'Y' tuşuna basıldığında seçilen başlığın içeriği okutuluyor.
            if(e.KeyCode==Keys.Y)
            {
                //timer2 durdularak içerik okutuluyor böylece haber başlıkları okuması duruyor.
                timer2.Stop();

                //veritabanından bir önceki formda seçilen gazetenin rss datası çekiliyor.
                SqlCommand komut1 = new SqlCommand("select GazeteRSS from Gazeteler where GazeteAD='" + gztHaberLbl.Text + "'", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    //çekilen rss datası okutuluyor.
                    XmlTextReader xmlicerikoku = new XmlTextReader(dr1["GazeteRSS"].ToString());
                    while (xmlicerikoku.Read())
                    {
                       
                        //çekilen rss datasındaki haber başlıkları çekiliyor
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

                        //çekilen rss datasındaki haber içerikleri çekiliyor
                        if (xmlicerikoku.Name == "description") 
                        {
                                //okunan içerikler oluşturulan dizide 1.sütuna yazılıyor.
                                dizi[descriptionindex, 1] = xmlicerikoku.ReadString();                                
                                
                                //kullanıcının seçtiği başlık indexi bizim içerik indeximize eşit mi kontrol ediliyor.
                                if (secilenbaslikindex == descriptionindex)
                                {   
                                    //seçili olan başlığı doğruya richTextBox'ımızın içine içeriğimizi yazdırıyoruz.
                                    richTextBox1.Text = dizi[descriptionindex, 1];
                                    /*Test İşlemi.
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
                i = kalanyer+1;

                //tekrardan dizi değerleri 0'lanıyor.
                titleindex = 0;
                descriptionindex = 1;

                //timer2 başlatılarak kaldığı yerden haber başlıkları okutulmaya devam ediyor.
                timer2.Start();

                //veri tabanı bağlantısı kapatılıyor.
                bgl.baglanti().Close();
            }

            //Eğer Tüm Haberler Okunmuşsa Klavyeden 'T' tuşuna basıldığında tekrardan tüm haber başlıklarını okur.
            if (e.KeyCode == Keys.T)
            {
                //timer2'de haberler listboxa ekleniyor.O yüzden i değişkeni sıfırlayıp timerımızı başlatıyoruz.
                i = 0;
                timer2.Start();
            }

            //Klavyeden 'B' tuşuna basıldığında form kapanıp bir önceki form açılmaktadır.
            if(e.KeyCode==Keys.B)
            {               
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1 başlatıldığında button tıklama yapılarak işlemleri yaptırılır. Form otomatik verilerle dolduruluyor.
            button1.PerformClick();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //son habere gelene kadar dönecektir.
            if (i < listBox1.Items.Count)
            {
                //bir haber seçildikten sonra tekrar seçildiğinde kalınan yerden devam etmesi sağlanıyor.
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
                //tüm haberler bittiyse eğer bilgilendirme mesajı verilecektir.
                MessageBox.Show("Haberleri Tekrar Dinlemek İçin Klavyeden 'T' Tuşuna Basınız.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //timer2 çalıştığı sürece i değişkeni 1 arttırılarak sırayla haber başlıkları okutulması sağlanıyor.
            i++;
        }
    }
}
