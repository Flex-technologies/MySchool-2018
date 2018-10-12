using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class AnneeScolaire
    {
        public AnneeScolaire()
        {
            Periodes = new List<PeriodePersonnalisee>();
        }
        public int Id { get; set; }
        public string AnneeAcademique { get; set; }
        public string Description { get; set; }
       
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }

        public virtual ICollection<PeriodePersonnalisee> Periodes { get; set; }
    }

    
}