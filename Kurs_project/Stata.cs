//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs_project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stata
    {
        public int StataID { get; set; }
        public Nullable<int> Plotnost { get; set; }
        public Nullable<int> Oktan { get; set; }
        public string Cvet { get; set; }
        public Nullable<int> FuelID { get; set; }
    
        public virtual Fuel Fuel { get; set; }
    }
}