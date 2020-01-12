using CariHesap.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    class HelperKategori
    {
        public static (Kategori, bool) Add(Kategori k)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Kategori.Add(k);
                if (s.SaveChanges() > 0)
                {
                    return (k, true);
                }
                else
                {
                    return (k, false);
                }
            }
        }

        public static (Kategori, bool) Update(Kategori k)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Entry(k).State = System.Data.Entity.EntityState.Modified;
                if (s.SaveChanges() > 0)
                {
                    return (k, true);
                }
                else
                {
                    return (k, false);
                }
            }
        }
        public static int GetKategoriIDByName(string name)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                Kategori kategori= s.Kategori.Where(x => x.adi.ToLower() == name).FirstOrDefault();
                return kategori.kategoriID;
            }
        }

        public static Kategori GetKategoriByID(int ID)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                return s.Kategori.Find(ID);
            }
        }

        public static List<Kategori> GetListKategori()
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                return s.Kategori.ToList();
            }
        }
        
    }
}
