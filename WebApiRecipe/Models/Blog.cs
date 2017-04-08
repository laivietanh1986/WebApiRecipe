namespace WebApiRecipe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blog
    {
        public int BlogId { get; set; }

        [Required]
        [StringLength(50)]
        public string Label { get; set; }

        [Required]
        [StringLength(500)]
        [NotContainBadWords]
        public string BlogContain { get; set; }
    }

    public class NotContainBadWords : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Contains("fuck"))
            {
                return   new ValidationResult("Contain Fuck :D");
            }
            return null;
        }
    }
}
