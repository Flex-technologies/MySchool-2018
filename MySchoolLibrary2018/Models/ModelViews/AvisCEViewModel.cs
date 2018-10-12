using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class AvisCEViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Avis { get; set; }
        public Boolean Brevet { get; set; }//cet avis est obligattoire dans le brevet
        [Display(Name = "Livret Standard")]
        public Boolean LivretStandard { get; set; }
        [Display(Name ="Livret Bac Général")]
        public Boolean LivretBacGeneral { get; set; }
        [Display(Name = "Livret Bac Pro")]
        public Boolean LivretBacPro { get; set; }

        /// <summary>
        /// Génére le model à partir du viewModel
        /// </summary>
        /// <returns></returns>
        public AvisCE ToModel()
        {
            var avisce = new AvisCE {
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
