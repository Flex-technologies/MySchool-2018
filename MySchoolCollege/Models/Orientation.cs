using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class Orientation
    {
        public Orientation()
        {
            this.EtablissementAccueils = new HashSet<EtablissementAccueil>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public Nature Nature { get; set; }
        public Cycle Cycle { get; set; }
        public Niveau Niveau { get; set; }
        public ICollection<EtablissementAccueil> EtablissementAccueils { get; set; }
       
    }

    public class Nature
    {
        public string Id { get; set; }
    }

    public class SpecialiteOrientation
    {
        public string Id { get; set; }
        public Orientation Orientation { get; set; }
    }
    public class OptionSpecialite
    {
        public string Id { get; set; }
        public SpecialiteOrientation SpecialiteOrientation { get; set; }
    }

    public class EtablissementAccueil : Etablissement
    {
        public EtablissementAccueil()
        {
            this.Orientations = new HashSet<Orientation>();
        }

        public ICollection<Orientation> Orientations { get; set; }
    }

    
}