using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m5d4_forms.Models
{
    public class PersonneViewModel
    {
        public int? Id { get; set; }
        //public string Nom { get; set; }
        //public string Prenom { get; set; }
        public int? Age { get; set; }

        public Personne Personne { get; set; }
    }
}