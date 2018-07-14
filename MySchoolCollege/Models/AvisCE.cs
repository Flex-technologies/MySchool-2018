using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class AvisCE //Avis chef d'établissement
    {
        public int Id { get; set; }
        public string Avis { get; set; }
        public Boolean Brevet { get; set; }//cet avis est obligattoire dans le brevet
        public Boolean LivretStandard { get; set; }
        public Boolean LivretBacGeneral { get; set; }
        public Boolean LivretBacPro { get; set; }
    }
}