using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class InspectionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string Pays { get; set; }
        public TypeInspection TypeInspection { get; set; }
        public int TypeInspectionId { get; set; }
        [Display(Name="Ministère")]
        public virtual Ministere Ministere { get; set; }
        public int MinistereId { get; set; }
        [Display(Name = "Insp. Dépendance")]
        public virtual Inspection InspectionParent { get; set; }
        public int? InspectionParentId { get; set; }
        

        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public string CreerParId { get; set; }
        public virtual ApplicationUser ModifierPar { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }
        public List<SelectListItem> MinisteresSelect { get; set; }
        public List<SelectListItem> InspectionsSelect { get; set; }
        public List<SelectListItem> TypeInspectionsSelect { get; set; }


        /// <summary>
        /// Converti le ViewModel en Model.
        /// </summary>
        /// <returns></returns>
        public Inspection ToModel()
        {
            var model = new Inspection
            {

                Id = Id,
                Nom = Nom,
                Telephone = Telephone,
                Adresse = Adresse,
                Ville = Ville,
                Pays = Pays,
                TypeInspection = TypeInspection,
                InspectionParent = InspectionParent,
                Ministere = Ministere,
                CreerLe = CreerLe,
                ModifierLe = ModifierLe,
                CreerPar = CreerPar,
                ModifierPar = ModifierPar,
                Inspections = Inspections
            };

            return model;
        }

        public void ToSaveModel(Inspection model)
        {
           
            model.Id = Id;
            model.Nom = Nom;
            model.Telephone = Telephone;
            model.Adresse = Adresse;
            model.Ville = Ville;
            model.Pays = Pays;
            model.TypeInspection = TypeInspection;
            model.InspectionParent = InspectionParent;
            model.Ministere = Ministere;
            model.CreerLe = CreerLe;
            model.ModifierLe = ModifierLe;
            model.CreerPar = CreerPar;
            model.ModifierPar = ModifierPar;
            model.Inspections = Inspections;

            
        }
    }
}
