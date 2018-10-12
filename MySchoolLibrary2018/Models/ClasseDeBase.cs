using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class ClasseDeBase
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual Niveau Niveau { get; set; }
        public virtual Filiere Filiere { get; set; }
        public virtual Etablissement Etablissement { get; set; }

        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }


    }

    public class Classe
    {
        public int Id { get; set; }
        public virtual ApplicationUser ProfesseurPrincipal { get; set; }
        public virtual ClasseDeBase ClasseDeBase { get; set; }        
        public virtual AnneeScolaire AnneeScolaire { get; set; }


        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}