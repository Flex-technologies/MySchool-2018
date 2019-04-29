using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class AvisCE //Avis chef d'établissement
    {
        public int Id { get; set; }
        public string Avis { get; set; }
        public Boolean Brevet { get; set; }//cet avis est obligattoire dans le brevet
        public Boolean LivretStandard { get; set; }
        public Boolean LivretBacGeneral { get; set; }
        public Boolean LivretBacPro { get; set; }

        /// <summary>
        /// Génére le Viewmodel à partir du Model
        /// </summary>
        /// <returns></returns>
        public AvisCEViewModel ToModel()
        {
            var avisce = new AvisCEViewModel
            {
                Id = Id,
                Avis = Avis,
                Brevet = Brevet,
                LivretBacGeneral = LivretBacGeneral,
                LivretBacPro = LivretBacPro,
                LivretStandard = LivretStandard
            };
            return avisce;
        }
    }
}