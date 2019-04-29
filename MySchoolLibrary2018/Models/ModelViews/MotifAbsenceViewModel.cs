using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models.ModelViews
{
    
    public class MotifAbsenceViewModel
    {
        [Display(Name = "Code")]
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Recevable { get; set; }
        [Display(Name = "Régler Administrativement")]
        public Boolean ReglerAdministrativement { get; set; }
        [Display(Name = "Hors Etablissement")]
        public Boolean HorsEtablissement { get; set; }
        [Display(Name = "Santé")]
        public Boolean Sante { get; set; }

        /// <summary>
        /// Convertir MotifAbsenceViewModel en MotifAbsence
        /// </summary>
        /// <returns></returns>
        public MotifAbsence ToModel()
        {
            var motifAbsence = new MotifAbsence
            {
                Id = this.Id,
                Description = this.Description,
                Recevable = this.Recevable,
                ReglerAdministrativement = this.ReglerAdministrativement,
                HorsEtablissement = this.HorsEtablissement,
                Sante = this.Sante

            };
            

            return motifAbsence;
        }
    }

    public class MotifRetardViewModel
    {
        [Display(Name = "Code")]
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Recevable { get; set; }
        [Display(Name = "Régler Administrativement")]
        public Boolean ReglerAdministrativement { get; set; }
        public Boolean Bulletin { get; set; } //Comptabilisé dans le bulletin

        public MotifRetard ToModel()
        {
            var motifRetard = new MotifRetard
            {
                Id = this.Id,
                Description = this.Description,
                Recevable = this.Recevable,
                ReglerAdministrativement = this.ReglerAdministrativement,
                Bulletin = this.Bulletin

            };

            return motifRetard;
        }

    }
}
