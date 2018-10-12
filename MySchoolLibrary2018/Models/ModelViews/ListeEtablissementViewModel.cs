using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class ListeEtablissementViewModel
    {

        public int Id { get; set; }

        [Display(Name ="Nom Etablissement")]
        public string Nom { get; set; }
        [Display(Name ="Type Etablisssement")]
        public TypeEtablissement Type { get; set; }

        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        [Display(Name ="Téléphone Sécrétariat")]
        public string TelephoneSecretariat { get; set; }
        [Display(Name = "Téléphone Scolarité")]
        public string TelephoneScolarite { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [Display(Name = "Site web")]
        public string SiteWeb { get; set; }
        [Display(Name = "Créer le")]
        public DateTime DateCreation { get; set; }
        [Display(Name = "Modifier le")]
        public DateTime DateModification { get; set; }
        [Display(Name = "Créer par")]
        public ApplicationUser CreerPar { get; set; }
        [Display(Name = "Modifier par")]
        public ApplicationUser Modifierpar { get; set; }
    }
    public class EtablissementViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Nom Etablissement")]
        public string Nom { get; set; }
        [Display(Name = "Type Etablisssement")]
        public TypeEtablissement Type { get; set; }

        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        [Display(Name = "Téléphone Sécrétariat")]
        public string TelephoneSecretariat { get; set; }
        [Display(Name = "Téléphone Scolarité")]
        public string TelephoneScolarite { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [Display(Name = "Site web")]
        public string SiteWeb { get; set; }
        [Display(Name = "Créer le")]
        public DateTime DateCreation { get; set; }
        [Display(Name = "Modifier le")]
        public DateTime DateModification { get; set; }
        [Display(Name = "Créer par")]
        public ApplicationUser CreerPar { get; set; }
        [Display(Name = "Modifier par")]
        public ApplicationUser Modifierpar { get; set; }

        public List<SelectListItem> Types { get; set; }
        public string TypeEtablissementId { get; set; }
    }
}
