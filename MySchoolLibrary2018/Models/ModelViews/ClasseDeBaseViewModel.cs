using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MySchoolLibrary2018.Models.ModelViews
{
    public class ClasseDeBaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string NiveauId { get; set; }
        public virtual Niveau Niveau { get; set; }
        [Required]
        public string FiliereId { get; set; }
        public virtual Filiere Filiere { get; set; }
        

        public virtual ApplicationUser CreerPar { get; set; }
        public virtual ApplicationUser ModifierPar { get; set; }

        public DateTime CreerLe { get; set; }
        public DateTime ModifierLe { get; set; }

        public List<SelectListItem> Niveaux { get; set; }
        public List<SelectListItem> Filieres { get; set; }
       


        /// <summary>
        /// Générer le model à partir du ViewModel
        /// </summary>
        /// <returns></returns>
        public ClasseDeBase ToModel()
        {
            var model = new ClasseDeBase
            {
                Id = Id,
                Nom = Nom,
                CreeLe = CreerLe,
                CreerPar = CreerPar,
                
                Filiere = Filiere,
                Niveau = Niveau,
                ModifierLe = ModifierLe,
                Modifierpar = ModifierPar
            };

            return model;
        }

        public void ToSaveModel(ClasseDeBase model)
        {
            model.Id = Id;
            model.Nom = Nom;
            //model.CreeLe = CreerLe;
            //model.CreerPar = CreerPar;
            model.Filiere = Filiere;
            model.Niveau = Niveau;
            model.ModifierLe = ModifierLe;
            model.Modifierpar = ModifierPar;
        }
    }
}
