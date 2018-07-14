using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class ClasseDeBase
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Niveau Niveau { get; set; }
        public Filiere Filiere { get; set; }
        public Etablissement Etablissement { get; set; }

        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }


    }

    public class Classe
    {
        public int Id { get; set; }
        public ApplicationUser ProfesseurPrincipal { get; set; }
        public ClasseDeBase ClasseDeBase { get; set; }        
        public AnneeScolaire AnneeScolaire { get; set; }


        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}