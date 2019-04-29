using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class MinistereViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom Ministère")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public string Ville { get; set; }
        [Required]
        public string Pays { get; set; }

        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }
        public virtual ApplicationUser CreerPar { get; set; }
        public string CreerParId { get; set; }
        public virtual ApplicationUser ModifierPar { get; set; }
        public virtual ICollection<Inspection> Inspections { get; set; }

        /// <summary>
        /// Converti le ViewModel en model
        /// </summary>
        /// <returns></returns>
        public Ministere ToModel()
        {
            var model = new Ministere
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
                ModifierPar = ModifierPar,
                Inspections = Inspections
            };
            return model;
        }
    }
}
