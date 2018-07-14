using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string CodeMatiere { get; set; }
        public string Description { get; set; }
        public Boolean Lve { get; set; }//Langue vivante étrangère

        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }

    }
    public class ServiceMatiere
    {
        public int Id { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
        public Matiere Matiere { get; set; }
        public int Coeficient { get; set; }
        public int? VolumeHoraire { get; set; }
        public ApplicationUser Professeur { get; set; }
        public Classe Classe { get; set; }

        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }

    }
}