using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamburgerciOdevi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public static List<Menu> Menuler = new List<Menu>()
        {   new Menu() { MenuAd = "BigMac", MenuFiyat = 76 },
            new Menu() { MenuAd = "2li TavukBurger", MenuFiyat = 40 },
            new Menu() { MenuAd = "Cheese Burger", MenuFiyat = 50 },
            new Menu() { MenuAd = "Köfte Burger", MenuFiyat = 55 },
            new Menu() { MenuAd = "Steakhouse", MenuFiyat = 100 }
        };


        public static List<EkstraMalzeme> EkstraMalzemes = new List<EkstraMalzeme>()
        {
            new EkstraMalzeme() {EkstraAdi = "Ranch", Fiyati=2.5},
            new EkstraMalzeme() {EkstraAdi = "Ketçap", Fiyati=1.5},
            new EkstraMalzeme() {EkstraAdi = "Mayonez", Fiyati=1.5},
            new EkstraMalzeme() {EkstraAdi = "Barbekü", Fiyati=3.5},
            new EkstraMalzeme() {EkstraAdi = "Buffalo", Fiyati=3.5}
        };

        public static List<Siparis> mevcutSiparisleri = new List<Siparis>();
        public static List<Siparis> tumSiparisler = new List<Siparis>();

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (var item in Menuler)
            {
                cmbMenuler.Items.Add(item);
            }
            foreach (var item in EkstraMalzemes)
            {
                flpEkstraMalzemeler.Controls.Add(new CheckBox() { Text = item.EkstraAdi, Tag = item });
            }
            foreach (var item in mevcutSiparisleri)
            {
                lbxSiparisler.Items.Add(item);
            }
            TutarHesapla();

            rdbKucuk.Checked = true;
            cmbMenuler.SelectedIndex = 0;
            nmrAdet.Value = 1;
        }
        private double TutarHesapla()
        {
            double toplamTutar = 0;
            for (int i = 0; i < lbxSiparisler.Items.Count; i++)
            {
                Siparis gelenSiparis = (Siparis)lbxSiparisler.Items[i];
                toplamTutar += gelenSiparis.ToplamTutar;
            }

            lblToplamTutar.Text = toplamTutar.ToString();

            return toplamTutar;
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            Siparis yeniSiparis = new Siparis();
            yeniSiparis.SecilenMenu = (Menu)cmbMenuler.SelectedItem;

            if (rdbKucuk.Checked)
                yeniSiparis.Boyut = Boyut.Küçük;
            else if (rdbOrta.Checked)
                yeniSiparis.Boyut = Boyut.Orta;
            else
                yeniSiparis.Boyut = Boyut.Büyük;

            foreach (CheckBox item in flpEkstraMalzemeler.Controls)
            {
                if (item.Checked)
                {
                    yeniSiparis.EkstraMalzemes.Add((EkstraMalzeme)item.Tag);
                }
            }
            yeniSiparis.Adet = (int)nmrAdet.Value;
            yeniSiparis.Hesapla();

            mevcutSiparisleri.Add(yeniSiparis); 
            tumSiparisler.Add(yeniSiparis);
            lbxSiparisler.Items.Add(yeniSiparis);

            TutarHesapla();
            //Temizleme Metodunu araştır bul

        }

        private void btnSiparisTamamla_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Toplam Sipariş Tutarı " + TutarHesapla().ToString() + "\n Satın almayı tamamlamak ister misin?","Sipariş Bilgibisi",MessageBoxButtons.YesNo,MessageBoxIcon.Information );
            if(dr == DialogResult.Yes)
            {
                lbxSiparisler.Items.Clear();
                mevcutSiparisleri.Clear();
                TutarHesapla();
                MessageBox.Show("Sipariş Tamamlandı.");
            }
            else
                MessageBox.Show("Sipariş İptal Edildi.");
        }
    }


}