using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class AutorisationViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Id { get; set; }
        [Required]
        [Display(Name ="Libellé")]
        public string libelle { get; set; }
        [Display(Name ="Entrée")]
        public Entree Entree { get; set; }
        public Sortie Sortie { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
