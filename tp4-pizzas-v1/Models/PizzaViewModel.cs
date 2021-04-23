using PizzaClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp4_pizzas_v1.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}