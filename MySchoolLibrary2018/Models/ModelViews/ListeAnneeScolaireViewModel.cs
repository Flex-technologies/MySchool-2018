using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class ListeAnneeScolaireViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Année Académique")]
        public string AnneeAcademique { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name ="Créer le")]
        public DateTime DateCreation { get; set; }
        [Display(Name = "Modifier le")]
        public DateTime DateModification { get; set; }
        [Display(Name = "Créer par")]
        public ApplicationUser CreerPar { get; set; }
        [Display(Name = "Modifier par")]
        public ApplicationUser Modifierpar { get; set; }
        [Display(Name = "Périodes")]
        public ICollection<PeriodePersonnalisee> Periodes { get; set; }
    }
}
