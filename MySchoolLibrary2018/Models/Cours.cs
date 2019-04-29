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
        public virtual AnneeScolaire AnneeScolaire { get; set; }
        public DateTime DateCours { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public virtual Salle Salle { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual ServiceMatiere Matiere { get; set; }
        public virtual ApplicationUser Professeur { get; set; }
        public string Commentaires { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser ModifierPar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}
