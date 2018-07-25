using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class Batiment
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Etablissement Lieu { get; set; }
    }

    public class Salle
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public Batiment Batiment { get; set; }
    }
}
