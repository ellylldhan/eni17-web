﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace m6tp1_dojo.Models
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }

        public virtual Arme Arme { get; set; }
    }
}