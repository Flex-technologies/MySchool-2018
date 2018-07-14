using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class RoleListViewModel
    {
        
        public string Id { get; set; }
        [Display(Name = "Nom")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Total utilisateurs")]
        public int TotalUtilisateurs { get; set; }
    }
}