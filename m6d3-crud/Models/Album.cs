using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m6d3_crud.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Groupe { get; set; }
        public int Annee { get; set; }
        public int NombreDePiste { get; set; }

    }
}