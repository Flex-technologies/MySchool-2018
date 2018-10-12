using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class DossierSanction
    {
        public int Id { get; set; }
        public DossierEtudiant Dossier { get; set; }
        public MotifSanction Motif { get; set; }
        public Lieu Lieu { get; set; }
        public Victime Victime { get; set; }
        public Temoin Temoin { get; set; }
        public string Commentaires { get; set; }
        public Sanction Sanction { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser ModifierPar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModiferLe { get; set; }

    }
}
