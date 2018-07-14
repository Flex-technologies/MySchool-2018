using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class MotifAbsence
    {
        [Display(Name ="Code")]
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Recevable { get; set; }
        public Boolean ReglerAdministrativement { get; set; }
        public Boolean HorsEtablissement { get; set; }
        public Boolean Sante { get; set; }
    }

    public class MotifRetard
    {
        [Display(Name = "Code")]
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Recevable { get; set; }
        public Boolean ReglerAdministrativement { get; set; }
        public Boolean Bulletin { get; set; } //Comptabilisé dans le bulletin
       
    }
}