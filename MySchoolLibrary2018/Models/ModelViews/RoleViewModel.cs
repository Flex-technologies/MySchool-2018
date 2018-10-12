using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models
{
    public class RoleViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string RoleName { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name ="Créer le")]
        public DateTime DateCreation { get; set; }
        [Display(Name ="Modifier le")]
        public DateTime DateModification { get; set; }
        public List<ApplicationUser> Users { get; set; }//liste des utlisateurs du groupe
        public List<SelectListItem> Utilisateurs { get; set; }//pour remplir la liste déroulante
        public string UtilisateurId { get; set; }
    }
}