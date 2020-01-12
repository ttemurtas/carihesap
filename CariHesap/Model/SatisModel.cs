using CariHesap.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.Model
{
    public class SatisModel
    {
        public int satisID { get; set; }
        public int müsteriID { get; set; }
        public int urunID { get; set; }
        public bool durum { get; set; }
        public System.DateTime satisTarihi { get; set; }
        public int satisAdedi { get; set; }

        public Musteri Musteri = new Musteri();
        public UrunModel Urun = new UrunModel();

    }
}
