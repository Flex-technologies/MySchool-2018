using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Fonction //Administratif
    {
        [Display(Name = "Libellé")]
        public string Id { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<ApplicationUser> Utilisateurs { get; set; }

    }
}