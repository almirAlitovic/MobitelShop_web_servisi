//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobitelShop_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uposlenici
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public bool Status { get; set; }
        public int UlogeId { get; set; }
    
        public virtual Uloge Uloge { get; set; }
    }
}
