using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class PeriodeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Période")]
        public string Periode { get; set; }
        
        [Display(Name ="Année scolaire")]
        public AnneeScolaire AnneeScolaire { get; set; }
        [Required]
        [Display(Name ="Date début")]
        public DateTime DateDebut { get; set; }
        [Required]
        [Display(Name ="Date fin")]
        public DateTime DateFin { get; set; }
        [Display(Name = "Années scolaire")]
        public List<SelectListItem> AnneeScolaires { get; set; }
        public int AnneeScolaireId { get; set; }
    }
}
