using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class UtilisateurViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength=6)]
        public string Matricule { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Civilité")]
        [Range(1, int.MaxValue, ErrorMessage = "Sélectionner une option")]
        public Civillite Civillite { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        public string Nom { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }

        [Required]
        [Display(Name = "Lieu de naissance")]
        public string LieuDeNaissance { get; set; }

        [Required]
        [Display(Name = "Nationalité")]
        public string Nationalite { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirmer mot de passe")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Le mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        public List<SelectListItem> ApplicationRoles { get; set; }
        [Display(Name = "Role")]
        public string ApplicationRoleId { get; set; }

        public List<SelectListItem> Fonctions { get; set; }
        public string FonctionId { get; set; }

        [Display(Name = "Parents/Tuteurs")]
        public List<SelectListItem> Parents { get; set; }
        public string ParentId { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Telephone { get; set; }
        public string CodePostal { get; set; }
        public string Photo { get; set; }
        public List<ApplicationRole> Roles { get; set; }
    }

    public class UtilisateurViewUpDateModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        public string Matricule { get; set; }

        [Required]
        [Display(Name = "Civilité")]
        [Range(1, int.MaxValue, ErrorMessage = "Sélectionner une option")]
        public Civillite Civillite { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        public string Nom { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [Display(Name = "Date de Naissance")]
        public DateTime DateNaissance { get; set; }

        [Required]
        [Display(Name = "Lieu de naissance")]
        public string LieuDeNaissance { get; set; }

        [Required]
        [Display(Name = "Nationalité")]
        public string Nationalite { get; set; }

        
        
        public List<SelectListItem> Fonctions { get; set; }
        public string FonctionId { get; set; }

        [Display(Name = "Parents/Tuteurs")]
        public List<SelectListItem> Parents { get; set; }
        public string ParentId { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Telephone { get; set; }
        public string CodePostal { get; set; }
        public string Photo { get; set; }

        public List<ApplicationRole> Roles { get; set; }
    }
}