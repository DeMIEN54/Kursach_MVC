//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace Kurs_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Emkost
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emkost()
        {
            this.Operaciya = new HashSet<Operaciya>();
        }
    
        public int EmkostID { get; set; }      
        public int Nomer { get; set; }
        public double Obyem { get; set; }
        public int FuelID { get; set; }
        public string About { get; set; }
    
        public virtual Fuel Fuel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operaciya> Operaciya { get; set; }
    }
}
