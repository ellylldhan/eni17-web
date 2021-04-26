using System;
using m5d4_forms.ValidationAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace m5d4_forms.Models
{
    public class Personne
    {
        public int Id { get; set; }

        [Required]
        [MyValidationAttribute]
        public string Nom { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Prenom { get; set; }

        [Range(5, 150)]
        public int Age { get; set; }
    }
}