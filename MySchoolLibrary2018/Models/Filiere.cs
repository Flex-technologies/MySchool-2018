using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Filiere
    {
        [Display(Name = "Code")]
        public string Id { get; set; }
        public string Description { get; set; }
        public TypeEtablissement TypeEtablissement { get; set; }
        public string LivretScolaire { get; set; }

        public virtual ICollection<ClasseDeBase> ClasseDeBase { get; set; }
    }
}