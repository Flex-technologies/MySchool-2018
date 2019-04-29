using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class Ministere
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }

        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser ModifierPar { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }



        /// <summary>
        /// Converti le model en ViewModel
        /// </summary>
        /// <returns></returns>
        public MinistereViewModel ToViewModel()
        {
            var model = new MinistereViewModel
            {

                Id = Id,
                Nom = Nom,
                Telephone = Telephone,
                Adresse = Adresse,
                Ville = Ville,
                Pays = Pays,

                CreerLe = CreerLe,
                ModifierLe = ModifierLe,
                CreerPar = CreerPar,
                CreerParId = CreerPar.Id,
                ModifierPar = ModifierPar,
                Inspections = Inspections
            };
            return model;
        }

    }
}
