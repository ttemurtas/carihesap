using CariHesap.DAL;
using CariHesap.Entitiy;
using CariHesap.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariHesap
{
    public partial class Form2 : Form
    {
        static Kullanici user = new Kullanici();
        public Form2(Kullanici kullanici)
        {
            InitializeComponent();
            label1.Visible = false;
            MusteriListesiDoldur();
            KategoriListesiDoldur();
            UrunListesiDoldur();
            KategorileriDoldur();
            SatisListesiDoldur();
            KarZararHesapla();
            user = kullanici;
        }

        private void KarZararHesapla()
        {
            List<SatisModel> satisModeller = HelperSatis.GetSatisModel();
            double kar = 0;
            foreach (var item in satisModeller)
            {
                kar += item.Urun.satisFiyati - item.Urun.gelisFıyati;
            }
            label43.Text = kar.ToString();
        }

        private void KarZararHesapla(List<SatisModel> satisModels)
        {
            double kar = 0;
            foreach (var item in satisModels)
            {
                kar += item.Urun.satisFiyati - item.Urun.gelisFıyati;
            }
            label43.Text = kar.ToString();
        }

        private void KategoriListesiDoldur()
        {
            List<Kategori> kategoriler = HelperKategori.GetListKategori();

            dataGridView3.Rows.Clear();
            foreach (var item in kategoriler)
            {
                if (item.durum)
                {
                    dataGridView3.Rows.Add($"{item.kategoriID}", $"{item.adi}", $"{item.aciklama}");
                }
            }
        }

        public void KategorileriDoldur()
        {
            List<Kategori> kategoriler = HelperKategori.GetListKategori();

            cmbUrunEkleKategori.Items.Clear();
            txtUrunDuzenleCtgr.Items.Clear();
            cmbCtgList.Items.Clear();
            foreach (var item in kategoriler)
            {
                if (item.durum)
                {
                    cmbUrunEkleKategori.Items.Add($"{item.adi}");
                    txtUrunDuzenleCtgr.Items.Add($"{item.adi}");
                    cmbCtgList.Items.Add($"{item.adi}");
                }
            }
        }

        private void BtnMusteriEkle_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri()
            {
                adi = txtMusEkleAdi.Text,
                soyadi = txtMusEkleSoyadi.Text,
                adres = txtMusEkleAdres.Text,
                telefon = txtMusEkleTel.Text,
                durum = true
            };
            var t = HelperMusteri.Add(m);
            if (t.Item2)
            {
                MessageBox.Show("Ekleme Başarılı!");
            }
            else
            {
                MessageBox.Show("Ekleme Başarısız!");
            }
            MusteriListesiDoldur();
        }

        private void BtnMusteriDznl_Click(object sender, EventArgs e)
        {
            Musteri m = HelperMusteri.GetMusteriByID(Convert.ToInt32(dataMusteriList.Rows[dataMusteriList.CurrentRow.Index].Cells[0].Value));

            m.adi = txtDznMusAdi.Text;
            m.soyadi = txtMusDznSoyad.Text;
            m.telefon = txtMusDznTel.Text;
            m.adres = txtMusDznAdres.Text;

            var t = HelperMusteri.Update(m);

            if (t.Item2)
            {
                label1.Visible = true;
                label1.ForeColor = Color.Green;
                label1.Text = "Müsteri bilgileri düzenlendi.";
            }
            else
            {
                label1.Visible = true;
                label1.ForeColor = Color.Red;
                label1.Text = "Müsteri düzenlenemedi";
            }
            MusteriListesiDoldur();
            txtDznMusAdi.Clear();
            txtMusDznSoyad.Clear();
            txtMusDznTel.Clear();
            txtMusDznAdres.Clear();
            btnMusteriDznl.Enabled = false;
        }

        private void BtnMusSatir_Click(object sender, EventArgs e)
        {
            Musteri m = HelperMusteri.GetMusteriByID(Convert.ToInt32(dataMusteriList.Rows[dataMusteriList.CurrentRow.Index].Cells[0].Value));
            txtDznMusAdi.Text = m.adi;
            txtMusDznSoyad.Text = m.soyadi;
            txtMusDznTel.Text = m.telefon;
            txtMusDznAdres.Text = m.adres;
            btnMusteriDznl.Enabled = true;
        }

        private void BtnMusteriSil_Click(object sender, EventArgs e)
        {
            var f = MessageBox.Show("Bu kaydı silmek istediginize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (f == DialogResult.Yes)
            {
                Musteri m = HelperMusteri.GetMusteriByID(Convert.ToInt32(dataMusteriList.Rows[dataMusteriList.CurrentRow.Index].Cells[0].Value));
                m.durum = false;
                var t = HelperMusteri.Update(m);
                if (t.Item2)
                {
                    label1.Visible = true;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Silindi!";
                }
                else
                {
                    label1.Visible = true;
                    label1.ForeColor = Color.Red;
                    label1.Text = "Silinemedi! Bir sorunla Karşılaşıldı!";
                }
            }
            else
            {
                label1.Visible = true;
                label1.ForeColor = Color.Red;
                label1.Text = "Silme işlemi iptal edildi.";
            }
            MusteriListesiDoldur();
        }

        public void MusteriListesiDoldur()
        {
            List<Musteri> musteriler = HelperMusteri.GetListMusteri();

            dataMusteriList.Rows.Clear();
            cmbMusteri.Items.Clear();
            foreach (var item in musteriler)
            {
                if (item.durum)
                {
                    dataMusteriList.Rows.Add($"{item.müsteriID}", $"{item.adi}", $"{item.soyadi}", $"{item.telefon}", $"{item.adres}");
                    cmbMusteri.Items.Add($"{item.adi}");
                }
            }
        }

        //public void KategoriListesiDoldur()
        //{
        //    List<Kategori> kategoriler = HelperKategori.GetListKategori();

        //    dataGridView3.Rows.Clear();
        //    foreach (var item in kategoriler)
        //    {
        //        if (item.durum)
        //        {
        //            dataMusteriList.Rows.Add($"{item.kategoriID}", $"{item.adi}", $"{item.}", $"{item.telefon}", $"{item.adres}");
        //        }
        //    }
        //}

        private void BtnCtgrSave_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori()
            {
                adi = txtCtgEkleAdi.Text,
                aciklama = txtCtgEkleAciklama.Text,
                durum = true
            };
            var t = HelperKategori.Add(k);
            if (t.Item2)
            {
                MessageBox.Show("Ekleme Başarılı!");
            }
            else
            {
                MessageBox.Show("Ekleme Başarısız!");
            }
            KategorileriDoldur();
            KategoriListesiDoldur();
            txtCtgEkleAdi.Clear();
            txtCtgEkleAciklama.Clear();
        }

        private void BtnUrunEkle_Click(object sender, EventArgs e)
        {
            Urun u = new Urun()
            {
                urunAdi = txtUrunEkleAdi.Text,
                kategoriID = HelperKategori.GetKategoriIDByName(cmbUrunEkleKategori.Text),
                gelisFıyati = Convert.ToInt32(txtGelisUcreti.Text),
                satisFiyati = Convert.ToInt32(txtSatisUcreti.Text),
                stok = Convert.ToInt32(txtStok.Text),
                aciklama = txtAciklama.Text,
                eklenmeTarihi = DateTime.Now,
                durum = true,
            };
            var t = HelperUrun.Add(u);
            if (t.Item2)
            {
                MessageBox.Show("Ekleme Başarılı!");
            }
            else
            {
                MessageBox.Show("Ekleme Başarısız!");
            }
            UrunListesiDoldur();
        }

        private void UrunListesiDoldur()
        {
            List<Urun> urunler = HelperUrun.GetListUrun();
            List<UrunModel> urunModels = HelperUrun.GetUrunModel(urunler);

            dataGridUrunList.Rows.Clear();
            foreach (var item in urunModels)
            {
                if (item.durum)
                {
                    dataGridUrunList.Rows.Add($"{item.urunID}", $"{item.urunAdi}", $"{item.Kategori.adi}", $"{item.gelisFıyati}", $"{item.satisFiyati}", $"{item.stok}", $"{item.aciklama}");
                }
            }
        }

        private void btnCategoryGet_Click(object sender, EventArgs e)
        {
            Kategori k = HelperKategori.GetKategoriByID(Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value));
            txtCtgDuzenleAdi.Text = k.adi;
            txtCtgDuzenleAciklama.Text = k.aciklama;
            btnCtgDuzenleSave.Enabled = true;
        }

        private void btnCtgDuzenleSave_Click(object sender, EventArgs e)
        {
            Kategori k = HelperKategori.GetKategoriByID(Convert.ToInt32(dataMusteriList.Rows[dataMusteriList.CurrentRow.Index].Cells[0].Value));

            k.adi = txtCtgDuzenleAdi.Text;
            k.aciklama = txtCtgDuzenleAciklama.Text;

            var t = HelperKategori.Update(k);

            if (t.Item2)
            {
                MessageBox.Show("Müsteri bilgileri düzenlendi.");
            }
            else
            {                
                MessageBox.Show("Müsteri düzenlenemedi!");
            }
            KategoriListesiDoldur();
            KategorileriDoldur();
            txtCtgDuzenleAdi.Clear();
            txtCtgDuzenleAciklama.Clear();
            btnCtgDuzenleSave.Enabled = false;
        }

        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {
            var f = MessageBox.Show("Bu kategoriyi silmek istediginize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (f == DialogResult.Yes)
            {
                Kategori k = HelperKategori.GetKategoriByID(Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value));
                k.durum = false;
                var t = HelperKategori.Update(k);
                if (t.Item2)
                {
                    lblKategoriKaydi.Visible = true;
                    lblKategoriKaydi.ForeColor = Color.Red;
                    lblKategoriKaydi.Text = "Silindi!";
                }
                else
                {
                    lblKategoriKaydi.Visible = true;
                    lblKategoriKaydi.ForeColor = Color.Red;
                    lblKategoriKaydi.Text = "Silinemedi! Bir sorunla Karşılaşıldı!";
                }
            }
            else
            {
                lblKategoriKaydi.Visible = true;
                lblKategoriKaydi.ForeColor = Color.Red;
                lblKategoriKaydi.Text = "Silme işlemi iptal edildi.";
            }
            KategoriListesiDoldur();
        }

        private void btnUrunGetir_Click(object sender, EventArgs e)
        {
            Urun u = HelperUrun.GetUrunByID(Convert.ToInt32(dataGridUrunList.Rows[dataGridUrunList.CurrentRow.Index].Cells[0].Value));
            txtUrunDuzenleAdi.Text = u.urunAdi;
            txtUrunDuzenleCtgr.SelectedItem = u.kategoriID;
            txtUrunDuzenleGelisF.Text = u.gelisFıyati.ToString();
            txtUrunDuzenleSatisF.Text = u.satisFiyati.ToString();
            txtUrunDuzenleStok.Text = u.stok.ToString();
            txtUrunDuzenleAciklama.Text = u.aciklama;
            btnCtgDuzenleSave.Enabled = true;
            btnUrunDuzenle.Enabled = true;
        }

        private void btnUrunDuzenle_Click(object sender, EventArgs e)
        {
            Urun u = HelperUrun.GetUrunByID(Convert.ToInt32(dataGridUrunList.Rows[dataGridUrunList.CurrentRow.Index].Cells[0].Value));

            u.urunAdi = txtUrunDuzenleAdi.Text;
            u.kategoriID= HelperKategori.GetKategoriIDByName(txtUrunDuzenleCtgr.Text);
            u.gelisFıyati= Convert.ToInt32(txtUrunDuzenleGelisF.Text);
            u.satisFiyati = Convert.ToInt32(txtUrunDuzenleSatisF.Text);
            u.stok = Convert.ToInt32(txtUrunDuzenleStok.Text);
            u.aciklama=txtUrunDuzenleAciklama.Text;

            var t = HelperUrun.Update(u);

            if (t.Item2)
            {
                MessageBox.Show("Urün bilgileri düzenlendi.");
            }
            else
            {
                MessageBox.Show("Urün bilgileri düzenlenemedi!");
            }
            UrunListesiDoldur();
            txtUrunDuzenleAdi.Clear();
            txtUrunDuzenleGelisF.Clear();
            txtUrunDuzenleSatisF.Clear();
            txtUrunDuzenleStok.Clear();
            txtUrunDuzenleAciklama.Clear();
            btnCtgDuzenleSave.Enabled = false;
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            var f = MessageBox.Show("Bu ürünü silmek istediginize emin misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (f == DialogResult.Yes)
            {
                Urun u = HelperUrun.GetUrunByID(Convert.ToInt32(dataMusteriList.Rows[dataMusteriList.CurrentRow.Index].Cells[0].Value));
                u.durum = false;
                var t = HelperUrun.Update(u);
                if (t.Item2)
                {
                    MessageBox.Show("Silindi!");
                }
                else
                {
                    MessageBox.Show("Silinemedi! Bir sorunla Karşılaşıldı!");
                }
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi.");
            }
            UrunListesiDoldur();
        }

        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            if (txtEskiSifre.Text==user.sifre)
            {
                if (txtSifreTekrar.Text==txtYeniSifre.Text)
                {
                    var newPassword = txtYeniSifre.Text;
                    var t = HelperKullanici.ChangePass(user, newPassword);

                    if (t.Item2)
                    {
                        MessageBox.Show("Sifre basari ile degistirildi.");
                    }
                    else
                    {
                        MessageBox.Show("Sifre degistirilirken bir sorunla karşılaşıldı!");
                    }
                }
                else
                {
                    MessageBox.Show("Yeni olusturulan sifreler ayni degil!!!");
                }
            }
            else
            {
                MessageBox.Show("Girilen sifre dogru degil!!!");
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            List<UrunModel> urunler = HelperUrun.GetListUrunByCategoryID(HelperKategori.GetKategoriIDByName(cmbCtgList.Text));

            dataGridView4.Rows.Clear();
            foreach (var item in urunler)
            {
                if (item.durum)
                {
                    dataGridView4.Rows.Add($"{item.urunID}", $"{item.urunAdi}",$"{item.satisFiyati}", $"{item.aciklama}");
                }
            }
        }

        private void DataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Urun u = HelperUrun.GetUrunByID(Convert.ToInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value));
            txtSecilenUrun.Text = u.urunAdi;
        }

        private void BtnSatisTamamla_Click(object sender, EventArgs e)
        {
            Urun u = HelperUrun.GetUrunByID(Convert.ToInt32(dataGridView4.Rows[dataGridView4.CurrentRow.Index].Cells[0].Value));
            if (u.stok >= Convert.ToInt32(txtAdet.Text))
            {
                var newStok = u.stok - Convert.ToInt32(txtAdet.Text);
                u.stok = newStok;
                var t = HelperUrun.Update(u);

                Satis satis = new Satis()
                {
                    müsteriID = HelperMusteri.GetMusteriIDByName(cmbMusteri.Text),
                    urunID = u.urunID,
                    satisTarihi = DateTime.Now,
                    durum =true,
                    satisAdedi = Convert.ToInt32(txtAdet.Text)
                };
                var t1 = HelperSatis.Add(satis);
                if (t1.Item2)
                {
                    MessageBox.Show("Satis basari ile gerceklesti.");
                }
                else
                {
                    MessageBox.Show("Satis gerceklesemedi!!!");
                }
            }
            else
            {
                MessageBox.Show("Secili üründe yeterli stock yok!!!");
            }
            SatisListesiDoldur();
        }

        public void SatisListesiDoldur()
        {
            List<SatisModel> satisModeller = HelperSatis.GetSatisModel();

            dataGridView1.Rows.Clear();
            foreach (var item in satisModeller)
            {
                if (item.durum)
                {
                    dataGridView1.Rows.Add($"{item.satisID}", $"{item.Musteri.adi}", $"{item.Musteri.soyadi}", $"{item.Urun.urunAdi}", $"{item.satisAdedi}", $"{item.satisAdedi * item.Urun.satisFiyati}", $"{item.satisTarihi.Day}.{item.satisTarihi.Month}.{item.satisTarihi.Year}");
                }
            }
        }
        public void SatisListesiDoldur(List<SatisModel> satisModels)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in satisModels)
            {
                if (item.durum)
                {
                    dataGridView1.Rows.Add($"{item.satisID}", $"{item.Musteri.adi}", $"{item.Musteri.soyadi}", $"{item.Urun.urunAdi}", $"{item.satisAdedi}", $"{item.satisAdedi * item.Urun.satisFiyati}", $"{item.satisTarihi.Day}.{item.satisTarihi.Month}.{item.satisTarihi.Year}");
                }
            }
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            SatisModelArama();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SatisModelArama();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SatisModelArama();
        }

        public void SatisModelArama()
        {
            if (dateTimePicker1.Checked || dateTimePicker2.Checked)
            {
                if (radioButton1.Checked)
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByMüsteri(textBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                    SatisListesiDoldur(satisModels);
                }
                else if (radioButton2.Checked)
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByUrün(textBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                    SatisListesiDoldur(satisModels);
                }
                else if (radioButton3.Checked)
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByKategori(textBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                    SatisListesiDoldur(satisModels);
                }
                else
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByDate(dateTimePicker1.Value, dateTimePicker2.Value);
                    SatisListesiDoldur(satisModels);
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByMüsteri(textBox1.Text);
                    SatisListesiDoldur(satisModels);
                }
                else if (radioButton2.Checked)
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByUrün(textBox1.Text);
                    SatisListesiDoldur(satisModels);
                }
                else if (radioButton3.Checked)
                {
                    List<SatisModel> satisModels = HelperSatis.SearchSatisByKategori(textBox1.Text);
                    SatisListesiDoldur(satisModels);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SatisModelArama();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SatisModelArama();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SatisModelArama();
        }

    }
}
