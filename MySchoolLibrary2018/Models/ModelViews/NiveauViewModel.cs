using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class NiveauViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        public Cycle Cycle { get; set; }
        [Display(Name ="Baréme")]
        public double Bareme { get; set; }
        public List<SelectListItem> Cycles { get; set; }
        [Required]
        public string CycleId { get; set; }
        public virtual ICollection<ClasseDeBase> ClasseDeBases { get; set; }
    }
}
