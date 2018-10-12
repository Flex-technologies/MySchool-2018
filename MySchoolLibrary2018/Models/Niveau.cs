using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Niveau
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public virtual Cycle Cycle { get; set; }
        public double Bareme { get; set; }

        public virtual ICollection<ClasseDeBase> ClasseDeBases { get; set; }
    }
}