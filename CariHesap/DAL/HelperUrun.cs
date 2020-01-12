using CariHesap.Entitiy;
using CariHesap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    class HelperUrun
    {
        public static (Urun, bool) Add(Urun u)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Urun.Add(u);
                if (s.SaveChanges() > 0)
                {
                    return (u, true);
                }
                else
                {
                    return (u, false);
                }
            }
        }

        public static (Urun, bool) Update(Urun u)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Entry(u).State = System.Data.Entity.EntityState.Modified;
                if (s.SaveChanges() > 0)
                {
                    return (u, true);
                }
                else
                {
                    return (u, false);
                }
            }
        }

        public static Urun GetUrunByID(int ID)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                return s.Urun.Find(ID);
            }
        }
        public static UrunModel GetUrunModelByID(int ID)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                Urun u = s.Urun.Find(ID);
                UrunModel urunModel = new UrunModel()
                {
                    urunID = u.urunID,
                    urunAdi = u.urunAdi,
                    gelisFıyati = u.gelisFıyati,
                    satisFiyati = u.satisFiyati,
                    aciklama = u.aciklama,
                    durum = u.durum,
                    eklenmeTarihi = u.eklenmeTarihi,
                    stok = u.stok,
                    kategoriID = u.kategoriID,
                    Kategori = HelperKategori.GetKategoriByID(u.kategoriID)
                };
                return urunModel;
            }
        }

        public static List<Urun> GetListUrun()
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                return s.Urun.ToList();
            }
        }

        public static List<Urun> GetListUrunByCategory(Kategori kategori)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<Urun> allUrun = s.Urun.ToList();
                List<Urun> UrunByCategory = new List<Urun>();
                foreach (var item in allUrun)
                {
                    if (item.Kategori== kategori)
                    {
                        UrunByCategory.Add(item);
                    }
                }
                return UrunByCategory;
            }
        }

        public static List<UrunModel> GetListUrunByCategoryID(int kategoriID)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<Urun> allUrun = s.Urun.ToList();
                List<UrunModel> allUrunModel = GetUrunModel(allUrun);
                List<UrunModel> UrunModelByCategory = new List<UrunModel>();
                foreach (var item in allUrunModel)
                {
                    if (item.Kategori.kategoriID == kategoriID)
                    {
                        UrunModelByCategory.Add(item);
                    }
                }
                return UrunModelByCategory;
            }
        }

        public static List<UrunModel> GetUrunModel(List<Urun> urunler)
        {
            List<UrunModel> urunModeller = new List<UrunModel>();
            foreach (var item in urunler)
            {
                UrunModel urunModel = new UrunModel()
                {
                    urunID = item.urunID,
                    urunAdi = item.urunAdi,
                    stok = item.stok,
                    gelisFıyati = item.gelisFıyati,
                    satisFiyati = item.satisFiyati,
                    eklenmeTarihi = item.eklenmeTarihi,
                    kategoriID = item.kategoriID,
                    durum = item.durum,
                    aciklama = item.aciklama,
                    Kategori = HelperKategori.GetKategoriByID(item.kategoriID)
                };
                urunModeller.Add(urunModel);
            }
            return urunModeller;
        }
    }
}
