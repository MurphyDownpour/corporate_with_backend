//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CorporateWithBackend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teammate
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public System.DateTime birth_date { get; set; }
        public string position { get; set; }
        public int photo_id { get; set; }
    
        public virtual File File { get; set; }
    }
}