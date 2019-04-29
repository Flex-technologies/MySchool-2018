using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class Inspection
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public virtual TypeInspection TypeInspection { get; set; }
        public virtual Ministere Ministere { get; set; }
        public virtual Inspection InspectionParent { get; set; }

        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser ModifierPar { get; set; }
        public virtual ICollection<Etablissement> Etablissements { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }


        /// <summary>
        /// Converti le Model en ViewModel
        /// </summary>
        /// <returns></returns>
        public InspectionViewModel ToViewModel()
        {
            var model = new InspectionViewModel
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

        
    }
}
