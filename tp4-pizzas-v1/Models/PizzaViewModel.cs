using tp4_pizzas_v1.ValidationAttributes;
using PizzaClassLibrary.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace tp4_pizzas_v1.Models
{
    public class PizzaViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Pate> Pates { get; set; }
        public List<SelectListItem> Ingredients { get; set; }

        [ListRange(Max = 5, Min = 2)]
        public List<int> IngredientIds { get; set; }
    }
}