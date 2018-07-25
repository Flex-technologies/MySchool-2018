using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class PointageEtudiant
    {
        public int Id { get; set; }
        public ApplicationUser Etudiant { get; set; }
        public Cours Cours { get; set; }
        public Boolean Present { get; set; }
        public Boolean Retard { get; set; }
        public int MinuteRedarder { get; set; }
        public Boolean AbsenceJustifier { get; set; }
        public Boolean RetardJustifier { get; set; }
        public MotifAbsence MotifAbsence { get; set; }
        public MotifRetard MotifRetard { get; set; }
        public string Commentaire { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser ModifierPar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
    }
}
