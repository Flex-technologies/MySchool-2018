using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class Mention
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Display(Name ="A imprimer dans le bulletin?")]
        public Boolean AImprimer { get; set; }
    }
}