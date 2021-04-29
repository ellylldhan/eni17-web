using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m6tp1_dojo.Models
{
    public class Arme: Entity
    {
        public string Nom { get; set; }
        public int Degats { get; set; }

        public override string ToString()
        {
            return $"{Nom} (dégats: {Degats})";
        }
    }
}