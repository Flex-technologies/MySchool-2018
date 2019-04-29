using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Etablissement
    {
        public Etablissement()
        {
            Classes = new HashSet<Classe>();
        }
        public int Id { get; set; }
        public string Nom { get; set; }
        public virtual TypeEtablissement Type { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string TelephoneSecretariat { get; set; }
        public string TelephoneScolarite { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string SiteWeb { get; set; }
        public virtual Inspection Inspection { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser Modifierpar { get; set; }

       // public virtual ICollection<ApplicationUser> Utilisateuers { get; set; }
       public virtual ICollection<Classe> Classes { get; set; }

        /// <summary>
        /// Converti le Model en ViewModel.
        /// </summary>
        /// <returns></returns>
        public EtablissementViewModel ToViewModel()
        {
            var model = new EtablissementViewModel
            {
                Id = Id,
                Nom = Nom,
                Type = Type,
                Email = Email,
                SiteWeb = SiteWeb,
                Adresse = Adresse,
                TelephoneScolarite = TelephoneScolarite,
                TelephoneSecretariat = TelephoneSecretariat,
                Fax = Fax,
                Ville = Ville,
                Pays = Pays,
                DateCreation = DateCreation,
                DateModification = DateModification,
                CreerPar = CreerPar,
                CreerParId = CreerPar.Id,
                Modifierpar = Modifierpar
            };

            return model;
        }
    }
}