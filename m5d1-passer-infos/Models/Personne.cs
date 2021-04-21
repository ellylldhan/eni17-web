using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m5d1_passer_infos.Models
{
    public class Personne
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
    }
}