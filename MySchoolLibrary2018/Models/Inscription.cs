using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class Inscription
    {
        public int Id { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
        public ApplicationUser Etudiant { get; set; }
        public Autorisation Regime { get; set; }
        public Classe Classe { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}
