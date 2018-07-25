using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
        public DateTime DateCours { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public Salle Salle { get; set; }
        public Classe Classe { get; set; }
        public ServiceMatiere Matiere { get; set; }
        public ApplicationUser Professeur { get; set; }
        public string Commentaires { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser ModifierPar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}
