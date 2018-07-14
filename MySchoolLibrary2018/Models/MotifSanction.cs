using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolLibrary2018.Models
{
    public class MotifSanction
    {
        public int Id { get; set; }
        public string Motif { get; set; }
        public TypeMotif TypeMotif { get; set; }
        public Boolean Dossier { get; set; }
    }

    public class TypeMotif
    {
        [Display(Name ="Type d'incident")]
        public string Id { get; set; }
    }

    public class Punition
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }

    public class Sanction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Boolean Exclusion { get; set; } //Exclusion associée à la sanction

    }
}