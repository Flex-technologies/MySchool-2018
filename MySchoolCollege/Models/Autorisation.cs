using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySchoolCollege.Models
{
    public class Autorisation
    {
        [Display(Name="Code")]
        public string Id { get; set; }
        public string libelle { get; set; }
        public Entree Entree { get; set; }
        public Sortie Sortie { get; set; }
        public string Description { get; set; }
    }

    public enum Entree 
    {
        Ouverture,
        EntreeHabituel,
        PremierCoursAssurer,
        Fixe
    }
    public enum Sortie
    {
        Fermeture,
        SortieHabituelle,
        DernierCoursAssurer,
        Fixe
    }
}