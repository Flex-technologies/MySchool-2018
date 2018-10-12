using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class MentionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "A imprimer dans le bulletin?")]
        public Boolean AImprimer { get; set; }
    }
}
