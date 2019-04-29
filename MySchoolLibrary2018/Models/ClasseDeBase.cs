using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class ClasseDeBase
    {
        public ClasseDeBase()
        {
            Classes = new HashSet<Classe>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual Niveau Niveau { get; set; }
        public virtual Filiere Filiere { get; set; }
        

        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreeLe { get; set; }
        public DateTime ModifierLe { get; set; }

        public virtual ICollection<Classe> Classes { get; set; }

        /// <summary>
        /// Générer le ViewModel à partir du Model
        /// </summary>
        /// <returns></returns>
        public ClasseDeBaseViewModel ToViewModel()
        {
            var classe = new ClasseDeBaseViewModel
            {
                Id = Id,
                Nom = Nom,
                CreerLe = CreeLe,
                CreerPar = CreerPar,
                
                Filiere = Filiere,
                FiliereId = Filiere.Id,
                Niveau = Niveau,
                NiveauId = Niveau.Id,
                ModifierLe = ModifierLe,
                ModifierPar = Modifierpar
               
            };

            return classe;
        }


    }

    public class Classe
    {
        public Classe()
        {
            Inscriptions = new HashSet<Inscription>();
            ServiceMatieres = new HashSet<ServiceMatiere>();
            UniteEnseignements = new HashSet<UniteEnseignement>();
            Cours = new HashSet<Cours>();
            Controles = new HashSet<Controle>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual ApplicationUser ProfesseurPrincipal { get; set; }
        public virtual ClasseDeBase ClasseDeBase { get; set; }        
        public virtual AnneeScolaire AnneeScolaire { get; set; }
        public virtual Etablissement Etablissement { get; set; }

        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }
        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }

        //colections
        public virtual ICollection<Inscription> Inscriptions { get; set; }
        public virtual ICollection<ServiceMatiere> ServiceMatieres { get; set; }
        public virtual ICollection<UniteEnseignement> UniteEnseignements { get; set; }
        public virtual ICollection<Cours> Cours { get; set; }
        public virtual ICollection<Controle> Controles { get; set; }



        public ClasseViewModel ToViewModel()
        {
            var classe =  new ClasseViewModel
            {
                Id = Id,
                Nom = Nom,
                ClasseDeBase = ClasseDeBase,
                ClasseDeBaseId = ClasseDeBase.Id,
                AnneeScolaire = AnneeScolaire,
                AnneeScolaireId = AnneeScolaire.Id,
                Etablissement = Etablissement,
                EtablissementId = Etablissement.Id,
                CreerLe = CreerLe,
                CreerPar = CreerPar,
                ModifierLe = ModifierLe,
                Modifierpar = Modifierpar,
                Inscriptions = Inscriptions,
                ServiceMatieres = ServiceMatieres,
                UniteEnseignements = UniteEnseignements,
                Cours = Cours,
                Controles = Controles
                
            };

            if(ProfesseurPrincipal == null)
            {
                //Ne rien faire
            }
            else
            {
                classe.ProfesseurPrincipal = ProfesseurPrincipal;
                classe.ProfesseurPrinciplaId = ProfesseurPrincipal.Id;
            }

            return classe;
        }
    }
}