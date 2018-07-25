using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MySchoolLibrary2018.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }

        //Personalisation de ApplicationUser
        public string Matricule { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Sélectionner une option")]
        public Civillite Civillite { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string LieuDeNaissance { get; set; }
        public string Nationalite { get; set; }
        public Fonction Fonction { get; set; }
        public ApplicationUser Parent { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string CodePostal { get; set; }

        //public  ICollection<ApplicationRole> GRoles { get; set; }
    }

   

    public enum Civillite { Mr =1, Mme=2, Mlle=3 }

    
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }

        //public  ICollection<ApplicationUser> GUsers { get; set; }
       
    }
    
    
    
   

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Controle> Controles { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<AnneeScolaire> AnneeScolaires { get; set; }
        public DbSet<Etablissement> Etablissements { get; set; }
        public DbSet<TypeEtablissement> TypeEtablissements { get; set; }
        public DbSet<PeriodePersonnalisee> PeriodePersonnalisees { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<Niveau> Niveaux { get; set; }
        public DbSet<Autorisation> Autorisations { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<AvisCE> AvisCEs { get; set; }
        public DbSet<MotifAbsence> MotifAbsences { get; set; }
        public DbSet<MotifRetard> MotifRetards { get; set; }
        public DbSet<MotifSanction> MotifSanctions { get; set; }
        public DbSet<TypeMotif> TypeMotifs { get; set; }
        public DbSet<Punition> Punitions { get; set; }
        public DbSet<Sanction> Sanctions { get; set; }
        public DbSet<Orientation> Orientations { get; set; }
        public DbSet<Nature> Natures { get; set; }
        public DbSet<SpecialiteOrientation> SpecialiteOrientations { get; set; }
        public DbSet<OptionSpecialite> OptionSpecialites { get; set; }
        public DbSet<EtablissementAccueil> EtablissementAccueils { get; set; }
        public DbSet<Domaine> Domaines { get; set; }
        public DbSet<NiveauDeMaitrise> NiveauDeMaitrises { get; set; }
        public DbSet<ClasseDeBase> ClasseDeBases { get; set; }
        public DbSet<ServiceMatiere> ServiceMatieres { get; set; }
        public DbSet<Fonction> Fonctions { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Notation> Notations { get; set; }
        public DbSet<AvisOrientation> AvisOrientations { get; set; }
        public DbSet<DemandeOrientation> DemandeOrientations { get; set; }
        public DbSet<UniteEnseignement> UniteEnseignements { get; set; }
        public DbSet<DossierEtudiant> DossierEtudiants { get; set; }
        public DbSet<DossierPunition> DossierPunitions { get; set; }
        public DbSet<DossierSanction> DossierSanctions { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Batiment> Batiments { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Carnet> Carnets { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<PointageEtudiant> PointageEtudiants { get; set; }
        
    }
}