using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRecipe.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotContainBadWords]
        public string Address { get; set; }
    }
}