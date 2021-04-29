using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m6tp1_dojo.Models
{
    public class Samourai : Entity
    {
        //public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartiaux { get; set; }
    }
}