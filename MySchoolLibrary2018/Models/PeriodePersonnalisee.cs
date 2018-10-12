using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MySchoolLibrary2018.Models
{
    public class PeriodePersonnalisee
    {
        public int Id { get; set; }
        [Display(Name ="Période")]
        public string Periode { get; set; }
        public virtual AnneeScolaire AnneeScolaire { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}