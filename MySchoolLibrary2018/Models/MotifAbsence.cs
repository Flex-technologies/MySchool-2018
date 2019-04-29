using MySchoolLibrary2018.Models.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class MotifAbsence
    {
       
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Recevable { get; set; }
        public Boolean ReglerAdministrativement { get; set; }
        public Boolean HorsEtablissement { get; set; }
        public Boolean Sante { get; set; }

        /// <summary>
        /// Convertir MotifAbsence en MotifAbsenceViewModel
        /// </summary>
        /// <returns></returns>
        public MotifAbsenceViewModel ToModel()
        {
            var motifAbsenceViewModel = new MotifAbsenceViewModel
            {
                Id = this.Id,
                Description = this.Description,
                Recevable = this.Recevable,
                ReglerAdministrativement = this.ReglerAdministrativement,
                HorsEtablissement = this.HorsEtablissement,
                Sante = this.Sante

            };


            return motifAbsenceViewModel;
        }
    }

    public class MotifRetard
    {
        
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Recevable { get; set; }
        public Boolean ReglerAdministrativement { get; set; }
        public Boolean Bulletin { get; set; } //Comptabilisé dans le bulletin
       
    }
}