//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kres_Basvuru_Form
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cocuk_Bilgisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cocuk_Bilgisi()
        {
            this.Anne_Bilgisi = new HashSet<Anne_Bilgisi>();
            this.Baba_Bilgisi = new HashSet<Baba_Bilgisi>();
            this.Bakanin_Bilgisi = new HashSet<Bakanin_Bilgisi>();
            this.Basvuranin_Bilgisi = new HashSet<Basvuranin_Bilgisi>();
            this.Cocuk_Harici_Bilgi = new HashSet<Cocuk_Harici_Bilgi>();
        }
    
        public int Cocuk_Id { get; set; }
        public string Cocuk_Adi_Soyadi { get; set; }
        public string Cocuk_TC_No { get; set; }
        public Nullable<System.DateTime> Dogum_Tarihi { get; set; }
        public string Cocuk_Cinsiyeti { get; set; }
        public string Ev_Adresi { get; set; }
        public Nullable<int> Basvuru_Yapilan_Kres_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Anne_Bilgisi> Anne_Bilgisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Baba_Bilgisi> Baba_Bilgisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bakanin_Bilgisi> Bakanin_Bilgisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basvuranin_Bilgisi> Basvuranin_Bilgisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cocuk_Harici_Bilgi> Cocuk_Harici_Bilgi { get; set; }
    }
}
