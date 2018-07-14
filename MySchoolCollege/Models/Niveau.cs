using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class Niveau
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Cycle Cycle { get; set; }
        public double Bareme { get; set; }

        public virtual ICollection<ClasseDeBase> ClasseDeBases { get; set; }
    }
}