using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class TypeEtablissement
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public TypeEtablissementViewModel ToViewModel()
        {
            TypeEtablissementViewModel viewModel = new TypeEtablissementViewModel {

                Id = Id,
                Description = Description
            };

            return viewModel;

        }

        public ICollection<Etablissement> etablissements { get; set; }
    }
}