using CariHesap.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CariHesap.DAL
{
    static class HelperKullanici
    {
        public static (Kullanici,bool) SignIn(string userName, string password)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                Kullanici kullanici = new Kullanici();

                kullanici=s.Kullanici.FirstOrDefault(x => x.adi == userName && x.sifre == password);

                if (kullanici != null)
                {
                    return (kullanici, true);
                }
                else
                {
                    return (kullanici, false);
                }
            }
        }

        public static (Kullanici,bool) ChangePass(Kullanici kullanici, string newPass)
        {
            using (CariHesapEntities1 s = new CariHesapEntities1())
            {
                kullanici.sifre = newPass;
                var t = Update(kullanici);
                if (kullanici.sifre == newPass)
                {
                    return (kullanici, true);
                }
                else
                {
                    return (kullanici, false);
                }
            }
        }

        public static (Kullanici, bool) Update(Kullanici k)
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

    }
}
