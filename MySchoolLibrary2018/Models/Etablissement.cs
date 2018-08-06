using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class Etablissement
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public TypeEtablissement Type { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string TelephoneSecretariat { get; set; }
        public string TelephoneScolarite { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string SiteWeb { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
    }
}