using CariHesap.Entitiy;
using CariHesap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    class HelperSatis
    {
        public static (Satis, bool) Add(Satis u)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Satis.Add(u);
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

        public static List<SatisModel> GetSatisModel()
        {
            List<Satis> satislar = GetSatis();
            List<SatisModel> satisModeller = new List<SatisModel>();
            foreach (var item in satislar)
            {
                SatisModel satisModel = new SatisModel()
                {
                    satisID = item.satisID,
                    urunID = item.urunID,
                    müsteriID = item.müsteriID,
                    satisTarihi = item.satisTarihi,
                    durum = item.durum,
                    satisAdedi = item.satisAdedi,
                    Musteri = HelperMusteri.GetMusteriByID(item.müsteriID),
                    Urun = HelperUrun.GetUrunModelByID(item.urunID),
                };
                satisModeller.Add(satisModel);
            }
            return satisModeller;
        }

        public static List<Satis> GetSatis()
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                return s.Satis.ToList();
            }
        }

        public static List<SatisModel> SearchSatisByMüsteri(string müsteri)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    if (item.Musteri.adi.ToLower().Contains(müsteri.ToLower()))
                    {
                        satisModels.Add(item);
                    }
                }
                return satisModels;
            }
        }
        public static List<SatisModel> SearchSatisByMüsteri(string müsteri,DateTime dateAltLimit, DateTime dateUstLimit)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    if (item.Musteri.adi.ToLower().Contains(müsteri.ToLower()))
                    {
                        if (item.satisTarihi <= dateUstLimit && item.satisTarihi >= dateUstLimit)
                        {
                            satisModels.Add(item);
                        }
                    }
                }
                return satisModels;
            }
        }
        public static List<SatisModel> SearchSatisByUrün(string urun)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    if (item.Urun.urunAdi.ToLower().Contains(urun.ToLower()))
                    {
                        satisModels.Add(item);
                    }
                }
                return satisModels;
            }
        }
        public static List<SatisModel> SearchSatisByUrün(string kategori, DateTime dateAltLimit, DateTime dateUstLimit)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    if (item.Urun.Kategori.adi.ToLower().Contains(kategori.ToLower()))
                    {
                        if (item.satisTarihi <= dateUstLimit && item.satisTarihi >= dateUstLimit)
                        {
                            satisModels.Add(item);
                        }
                    }
                }
                return satisModels;
            }
        }
        public static List<SatisModel> SearchSatisByKategori(string kategori)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    Urun urun = HelperUrun.GetUrunByID(item.urunID);
                    Kategori kategori1 = HelperKategori.GetKategoriByID(urun.kategoriID);
                    if (kategori1.adi.ToLower().Contains(kategori.ToLower()))
                    {
                        satisModels.Add(item);
                    }
                }
                return satisModels;
            }
        }
        public static List<SatisModel> SearchSatisByKategori(string kategori,DateTime dateAltLimit, DateTime dateUstLimit)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    if (item.Urun.Kategori.adi.ToLower().Contains(kategori.ToLower()))
                    {
                        if (item.satisTarihi <= dateUstLimit && item.satisTarihi >= dateUstLimit)
                        {
                            satisModels.Add(item);
                        }
                    }
                }
                return satisModels;
            }
        }
        public static List<SatisModel> SearchSatisByDate(DateTime dateAltLimit, DateTime dateUstLimit)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                List<SatisModel> allSatisModel = GetSatisModel();
                List<SatisModel> satisModels = new List<SatisModel>();
                foreach (var item in allSatisModel)
                {
                    if (item.satisTarihi<= dateUstLimit && item.satisTarihi >= dateUstLimit)
                    {
                        satisModels.Add(item);
                    }
                }
                return satisModels;
            }
        }
    }
}
