using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace m6tp1_dojo.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public List<ArtMartial> ArtsMartiaux { get; set; }
        //public List<SelectListItem> ArtsMartiaux { get; set; }
        public List<long> ArtsMartiauxIds { get; set; }



    }
}