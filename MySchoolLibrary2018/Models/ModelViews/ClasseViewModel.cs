using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class ClasseViewModel
    {
        public int Id { get; set; }
        public  ApplicationUser ProfesseurPrincipal { get; set; }
        [Required]
        public string Nom { get; set; }
        public  ClasseDeBase ClasseDeBase { get; set; }
        public  AnneeScolaire AnneeScolaire { get; set; }
        public  Etablissement Etablissement { get; set; }

        public string ProfesseurPrinciplaId { get; set; }
        public List<SelectListItem> Professeurs { get; set; }

        [Required]
        public int ClasseDeBaseId { get; set; }
        public List<SelectListItem> ClasseDeBases { get; set; }
        [Required]
        public int EtablissementId { get; set; }
        public List<SelectListItem> Etablissements { get; set; }
        [Required]
        public int AnneeScolaireId { get; set; }
        public List<SelectListItem> AnneeScolaires { get; set; }

        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }

        //collections
        public ICollection<Inscription> Inscriptions { get; set; }
        public ICollection<ServiceMatiere> ServiceMatieres { get; set; }
        public ICollection<UniteEnseignement> UniteEnseignements { get; set; }
        public ICollection<Cours> Cours { get; set; }
        public ICollection<Controle> Controles { get; set; }


        public Classe ToModel()
        {
            return new Classe
            {
                Id = Id,
                Nom = Nom,
                ProfesseurPrincipal = ProfesseurPrincipal,
                ClasseDeBase = ClasseDeBase,
                AnneeScolaire = AnneeScolaire,
                Etablissement = Etablissement,
                CreerLe = CreerLe,
                CreerPar = CreerPar,
                ModifierLe = ModifierLe,
                Modifierpar = Modifierpar

            };
        }
        public void ToSaveModel(Classe classe)
        {
            classe.Id = Id;
            classe.Nom = Nom;
            classe.ProfesseurPrincipal = ProfesseurPrincipal;
            classe.ClasseDeBase = ClasseDeBase;
            classe.AnneeScolaire = AnneeScolaire;
            classe.Etablissement = Etablissement;
            classe.CreerPar = CreerPar;
            classe.Modifierpar = Modifierpar;
            classe.CreerLe = CreerLe;
            classe.ModifierLe = ModifierLe;
        }
    }
}
