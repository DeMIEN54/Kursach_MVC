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
    
    public partial class Operaciya
    {
        public int OperaciyaID { get; set; }
        public double Prih_rash { get; set; }
        public System.DateTime Data_prih_rash { get; set; }
        public int EmkostID { get; set; }
        public int SotrudnikID { get; set; }
        public int Otdel_kadrovID { get; set; }
        public string About { get; set; }
    
        public virtual Emkost Emkost { get; set; }
        public virtual Otdel_kadrov Otdel_kadrov { get; set; }
        public virtual Sotrudnik Sotrudnik { get; set; }
    }
}