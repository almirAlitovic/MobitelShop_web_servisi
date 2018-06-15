using MobitelShop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobitelShop_API.DTO
{
    public class NarudzbaDTO
    {
        public int Id { get; set; }
        public string BrojNarudzbe { get; set; }
        public System.DateTime Datum { get; set; }
        public float UkupniIznos { get; set; }
        public int StatusNarudzbeId { get; set; }
        public int KupacId { get; set; }
        public List<NarudzbaStavke> stavke { get; set; }
    }
}