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
        public virtual AnneeScolaire AnneeScolaire { get; set; }
        public virtual ApplicationUser Etudiant { get; set; }
        public virtual Autorisation Regime { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}
