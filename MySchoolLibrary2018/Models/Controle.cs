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
        public Semestre Semestre { get; set; }
        public int Note { get; set; }
        public ServiceMatiere Matiere { get; set; }
        public int NotationSur { get; set; }
        public Classe Classe { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}