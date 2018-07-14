using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class AnneeScolaire
    {
        public int Id { get; set; }
        public string AnneeAcademique { get; set; }
        public string Description { get; set; }
        //Période
        public DateTime DateDebut{ get; set; }
        public DateTime DateFin { get; set; }
        //
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
        public ApplicationUser CreerPar { get; set; }
        public ApplicationUser Modifierpar { get; set; }
    }
}