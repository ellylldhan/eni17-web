using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace m5d4_forms.ValidationAttributes
{
    public class MyValidationAttribute : ValidationAttribute
    {
        public string Data { get; set; }

        public MyValidationAttribute()
        {
            // Forcer une valeur par défaut
            this.Data = "A";
        }

        public MyValidationAttribute(string data)
        {
            // Forcer une valeur par défaut
            this.Data = data;
        }

        //public override bool IsValid(object value)
        //{
        //    return base.IsValid(value);
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validationContext.ObjectInstance as Personne;
            //validationContext.ObjectType // m5d4-forms.Models.Personne
            //validationContext.Items;

            if ((value as string).StartsWith("A"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Ne commence pas par A");

            //return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}