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
    
    public partial class Sotrudnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnik()
        {
            this.Operaciya = new HashSet<Operaciya>();
        }
    
        public int SotrudnikID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Otchestvo { get; set; }
        public string Dolgnost { get; set; }
        public Nullable<System.DateTime> Data_nach_rab { get; set; }
        public Nullable<System.DateTime> Data_okon_rab { get; set; }
        public int Otdel_kadrovID { get; set; }
        public string About { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operaciya> Operaciya { get; set; }
        public virtual Otdel_kadrov Otdel_kadrov { get; set; }
    }
}
