using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class TypeEtablissementViewModel
    {
        [Required]
        [Display( Name = "Code")]
        public string Id { get; set; }
        [Required]
        public string Description { get; set; }

        public TypeEtablissement ToModel()
        {
            TypeEtablissement typeEtablissement = new TypeEtablissement
            {
                Id = Id,
                Description = Description
            };

            return typeEtablissement;
        }
        
    }
}
