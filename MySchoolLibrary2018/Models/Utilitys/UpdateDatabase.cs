using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MySchoolLibrary2018.Models.Utilitys
{
    public static class UpdateDatabase
    {
       /// <summary>
       /// Ajoute l'objet en parametre dans la base de donnée
       /// </summary>
       /// <param name="OurContext">DbContext</param>
       /// <param name="obj">Object</param>
       public static void Create(ApplicationDbContext OurContext, Object obj)
       {
            OurContext.Entry(obj).State = EntityState.Added;
            OurContext.SaveChanges();
       }

        

        /// <summary>
        /// Enregistre les modifications de l'objet en parametre dans la base de donnée
        /// </summary>
        /// <param name="OurContext">DbContext</param>
        /// <param name="obj">Object</param>
        public static void Update(ApplicationDbContext OurContext, Object obj)
        {
            OurContext.Entry(obj).State = EntityState.Modified;
            OurContext.SaveChanges();
        }

        /// <summary>
        /// Supprime l'objet en parametre dans la base de donnée
        /// </summary>
        /// <param name="OurContext">DbContext</param>
        /// <param name="obj">Object</param>
        public static void Delete(ApplicationDbContext OurContext, Object obj)
        {
            OurContext.Entry(obj).State = EntityState.Deleted;
            OurContext.SaveChanges();
        }
    }
}