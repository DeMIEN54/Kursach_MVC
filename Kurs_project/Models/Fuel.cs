//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fuel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fuel()
        {
            this.Emkost = new HashSet<Emkost>();
        }
    
        public int FuelID { get; set; }
        public string FuelType { get; set; }
        public int Oktan { get; set; }
        public decimal Cena { get; set; }
        public System.DateTime Data { get; set; }
        public string About { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emkost> Emkost { get; set; }
    }
}