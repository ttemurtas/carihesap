using CariHesap.DAL;
using CariHesap.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.Model
{
    public class UrunModel
    {
        public int urunID { get; set; }
        public string urunAdi { get; set; }
        public int stok { get; set; }
        public int gelisFıyati { get; set; }
        public int satisFiyati { get; set; }
        public System.DateTime eklenmeTarihi { get; set; }
        public int kategoriID { get; set; }
        public bool durum { get; set; }
        public string aciklama { get; set; }

        public string kategoriAdi { get; }
        public Kategori Kategori = new Kategori();
        
    }
}
