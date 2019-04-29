using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Matiere
    {
        public int Id { get; set; }
        public string CodeMatiere { get; set; }
        public string Description { get; set; }
        public Boolean Lve { get; set; }//Langue vivante étrangère
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }

    }
    public class ServiceMatiere
    {
        public int Id { get; set; }
        public virtual AnneeScolaire AnneeScolaire { get; set; }
        public virtual Matiere Matiere { get; set; }
        public int Coeficient { get; set; }
        public int? VolumeHoraire { get; set; }
        public virtual ApplicationUser Professeur { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual UniteEnseignement UniteEnseignement { get; set; }
        public int Credit { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }

    }
}