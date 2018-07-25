using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class AvisOrientation
    {
        public string Id { get; set; }
        public string Avis { get; set; }
        public string Commentaires { get; set; }

    }

    public class DemandeOrientation
    {
        public int Id { get; set; }
        public SpecialiteOrientation Specialite { get; set; }
        public OptionSpecialite Option { get; set; }
        public EtablissementAccueil EtablissementDemander { get; set; }
        public string Commentaires { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser ModifierPar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }

    }
}
