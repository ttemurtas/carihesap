//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CariHesap.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class Satis
    {
        public int satisID { get; set; }
        public int müsteriID { get; set; }
        public int urunID { get; set; }
        public bool durum { get; set; }
        public System.DateTime satisTarihi { get; set; }
        public int satisAdedi { get; set; }
    
        public virtual Musteri Musteri { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
