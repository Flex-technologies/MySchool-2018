using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class CycleViewModel
    {
        [Required]
        [Display(Name ="Code")]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Niveau> Niveaux { get; set; }
    }
}
