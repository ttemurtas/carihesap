using System;
using CariHesap.Entitiy;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    class HelperMusteri
    {
        public static (Musteri, bool) Add(Musteri m)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Musteri.Add(m);
                if (s.SaveChanges() > 0)
                {
                    return (m, true);
                }
                else
                {
                    return (m, false);
                }
            }
        }

        public static (Musteri, bool) Update(Musteri m)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                s.Entry(m).State = System.Data.Entity.EntityState.Modified;
                if (s.SaveChanges()>0)
                {
                    return (m,true);
                }
                else
                {
                    return (m,false);
                }
            }
        }

        public static Musteri GetMusteriByID(int ID)
        {
            using (CariHesapEntities1 s=new CariHesapEntities1())
            {
                return s.Musteri.Find(ID);
            }
        }

        public static List<Musteri> GetListMusteri()
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                return s.Musteri.ToList();
            }
        }

        public static int GetMusteriIDByName(string name)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                Musteri musteri= s.Musteri.Where(x => x.adi == name).FirstOrDefault();
                return musteri.müsteriID;
            }
        }
    }
}
