using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class FiliereViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name ="Type Etablissement")]
        public TypeEtablissement TypeEtablissement { get; set; }
        public List<SelectListItem> TypesEtablissement { get; set; }
        [Required]
        public string TypeEtablissementId { get; set; }
        [Display(Name ="Livret scolaire")]
        public string LivretScolaire { get; set; }

        public virtual ICollection<ClasseDeBase> ClasseDeBases { get; set; }
    }
}
