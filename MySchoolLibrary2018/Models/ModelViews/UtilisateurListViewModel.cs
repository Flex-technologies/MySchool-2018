using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class UtilisateurListViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Civilité")]
        public Civillite Civillite { get; set; }
        
       
        public string Matricule { get; set; }

        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        public string Nom { get; set; }

        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }

        public string Email { get; set; }
       
        [Display(Name = "Lieu de Naissance")]
        public string LieuDeNaissance { get; set; }

        [Display(Name = "Nationalité")]
        public string Nationalite { get; set; }

        public Fonction Fonction { get; set; }
        public ApplicationUser Parent { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }

        public List<ApplicationRole> Roles { get; set; }
    }
}