using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class Carnet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser SaisiePar { get; set; }
        public ApplicationUser Etudiant { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
        public string Observations { get; set; }
        public DateTime VueLe { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser ModifierPar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}
