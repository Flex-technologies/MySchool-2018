using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Controle
    {
        public int Id { get; set; }
        public DateTime DateControle { get; set; }
        public ApplicationUser Etudiant { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
        public int Note { get; set; }
        public Matiere Matiere { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
    }
}