using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobitelShop_API.DTO
{
    public class MobiteliDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public bool Status { get; set; }
        public string Memorija { get; set; }
        public string CpuJezgre { get; set; }
        public string Brend { get; set; }
        public string SlikaUrl { get; set; }
        public string OperativniSistem { get; set; }
    }
}