using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchoolLibrary2018.Models
{
    public class UniteEnseignement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Classe Classe { get; set; }
        public int Credit { get; set; }
        public AnneeScolaire AnneeScolaire { get; set; }
    }
}
