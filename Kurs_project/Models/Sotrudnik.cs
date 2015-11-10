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
    using System.ComponentModel.DataAnnotations;

    public partial class Sotrudnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnik()
        {
            this.Operaciya = new HashSet<Operaciya>();
        }
    
        public int SotrudnikID { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string Family { get; set; }
        [Display(Name = "Отчество")]
        public string Otchestvo { get; set; }
        [Display(Name = "Должность")]
        public string Dolgnost { get; set; }
        [Display(Name = "Дата начала работы")]
        public Nullable<System.DateTime> Data_nach_rab { get; set; }
        [Display(Name = "Время окончания работы")]
        public Nullable<System.DateTime> Data_okon_rab { get; set; }
        [Display(Name ="Описание")]
        public string About { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operaciya> Operaciya { get; set; }
    }
}
