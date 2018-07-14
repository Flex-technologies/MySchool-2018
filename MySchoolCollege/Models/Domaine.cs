using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class Domaine
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Boolean Lv1 { get; set; }
    }

    public class NiveauDeMaitrise
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Niveau { get; set; }
    }
}