using MySchoolLibrary2018.Models.ModelViews;
using MySchoolLibrary2018.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using MySchoolCollege.Properties;
using MySchoolLibrary2018.Models;

namespace MySchoolCollege.Controllers
{
    [Authorize(Roles ="Administrateur")]
    public class ParametreController : BaseController
    {
        private EtablissementRepository _etablissementRepository;
        private TypeEtablissementRepository _typeEtablissementRepository;
        public ParametreController()
        {
            _etablissementRepository = new EtablissementRepository(Db);
            _typeEtablissementRepository = new TypeEtablissementRepository(Db);
        }
        // GET: Parametre
        public ActionResult Index()
        {
            return View();
        }

        //Get
        /// <summary>
        /// Voir les détails d'un établissement
        /// </summary>
        /// <param name="id">identifiant unique de l'établissement</param>
        /// <returns></returns>
        public ActionResult DetailsEtablissement(int id)
        {
            var etablissement = _etablissementRepository.Get(id);
            if( etablissement == null)
            {
                return HttpNotFound();
            }

            var model = new EtablissementViewModel
            {
                Id = etablissement.Id,
                Nom = etablissement.Nom,
                Type = etablissement.Type,
                Adresse = etablissement.Adresse,
                Ville = etablissement.Ville,
                Pays = etablissement.Pays,
                TelephoneScolarite = etablissement.TelephoneScolarite,
                TelephoneSecretariat = etablissement.TelephoneSecretariat,
                Fax = etablissement.Fax,
                Email = etablissement.Email,
                SiteWeb = etablissement.SiteWeb,
                DateCreation = etablissement.DateCreation,
                DateModification = etablissement.DateModification,
                CreerPar = etablissement.CreerPar,
                Modifierpar = etablissement.Modifierpar

            };
            return View(model);
        }

        /// <summary>
        /// La liste des établissements
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Etablissements(int? page)
        {
            List<ListeEtablissementViewModel> model = _etablissementRepository.GetList().Select(e => new ListeEtablissementViewModel {
                Id = e.Id,
                Nom = e.Nom,
                Type = e.Type,
                Email = e.Email,
                SiteWeb = e.SiteWeb,
                Adresse = e.Adresse,
                TelephoneScolarite = e.TelephoneScolarite,
                TelephoneSecretariat = e.TelephoneSecretariat,
                Fax = e.Fax,
                Ville = e.Ville,
                Pays = e.Pays,
                DateCreation = e.DateCreation,
                DateModification = e.DateModification,
                CreerPar = e.CreerPar,
                Modifierpar = e.Modifierpar

            }).ToList();
            var pageNumber = page ?? 1;
            var nLignesParPage = int.Parse(Resources.NombreLigneParPage);
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }

        //GET: 
        [HttpGet]
        public ActionResult AjouterEtablissement()
        {
            var model = new EtablissementViewModel();
            var types = _typeEtablissementRepository.GetList().Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            model.Types = types;
            return View(model);
        }

        /// <summary>
        /// Ajouter un nouveau établissement
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AjouterEtablissement( EtablissementViewModel model)
        {
            if (ModelState.IsValid)
            {
                Etablissement etablissement = new Etablissement();
                etablissement.Email = model.Email;
                etablissement.Adresse = model.Adresse;
                etablissement.Ville = model.Ville;
                etablissement.Pays = model.Pays;
                etablissement.CreerPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                etablissement.Modifierpar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                etablissement.Nom = model.Nom;
                etablissement.SiteWeb = model.SiteWeb;
                etablissement.TelephoneScolarite = model.TelephoneScolarite;
                etablissement.TelephoneSecretariat = model.TelephoneSecretariat;
                etablissement.Fax = model.Fax;
                etablissement.Type = _typeEtablissementRepository.Get(model.TypeEtablissementId);
                etablissement.DateCreation = DateTime.Now;
                etablissement.DateModification = DateTime.Now;

                _etablissementRepository.Add(etablissement);
                TempData["Message"] = "Etablissement ajouté avec succés";
                return RedirectToAction("Etablissements");
                

            }
            //si on arrive ici c'est à dire quelque chose ne va pas.
            var types = _typeEtablissementRepository.GetList().Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            model.Types = types;
            return View(model);
        }

        [HttpGet]
        public ActionResult ModifierEtablissement(int id)
        {
            //var model = new EtablissementViewModel();
            var etablissement = _etablissementRepository.Get(id);
            if(etablissement == null)
            {
                return HttpNotFound();
            }
            var types = _typeEtablissementRepository.GetList().Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
           
            var model = new EtablissementViewModel
            {
                Id = etablissement.Id,
                Nom = etablissement.Nom,
                Type = etablissement.Type,
                Adresse = etablissement.Adresse,
                Ville =  etablissement.Ville,
                Pays = etablissement.Pays,
                TelephoneScolarite = etablissement.TelephoneScolarite,
                TelephoneSecretariat = etablissement.TelephoneSecretariat,
                Fax = etablissement.Fax,
                Email = etablissement.Email,
                SiteWeb = etablissement.SiteWeb,
                DateCreation = etablissement.DateCreation,
                DateModification = etablissement.DateModification,
                CreerPar = etablissement.CreerPar,
                Modifierpar = etablissement.Modifierpar,
                Types = types,
               

            };
            try
            {
                model.TypeEtablissementId = etablissement.Type.Id;
            }
            catch
            {

            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierEtablissement(EtablissementViewModel model)
        {
            if (ModelState.IsValid)
            {

                Etablissement etablissement = _etablissementRepository.Get(model.Id,true) ;
                
                etablissement.Email = model.Email;
                etablissement.Adresse = model.Adresse;
                etablissement.Ville = model.Ville;
                etablissement.Pays = model.Pays;
                
                etablissement.Modifierpar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                etablissement.Nom = model.Nom;
                etablissement.SiteWeb = model.SiteWeb;
                etablissement.TelephoneScolarite = model.TelephoneScolarite;
                etablissement.TelephoneSecretariat = model.TelephoneSecretariat;
                etablissement.Fax = model.Fax;
                etablissement.Type = _typeEtablissementRepository.Get(model.TypeEtablissementId);
                
                etablissement.DateModification = DateTime.Now;

                _etablissementRepository.Update(etablissement);
                TempData["Message"] = "Etablissement modifié avec succés";

                return RedirectToAction("Etablissements");
            }
            //si on arrive ici c'est à dire quelque chose ne va pas.
            return View(model);
        }

        //Get
        public ActionResult SupprimerEtablissement(int id)
        {
            
            var etablissement = _etablissementRepository.Get(id);
            if (etablissement == null)
            {
                return HttpNotFound();
            }

            var model = new EtablissementViewModel
            {
                Id = etablissement.Id,
                Nom = etablissement.Nom,
                Type = etablissement.Type,
                Adresse = etablissement.Adresse,
                Ville = etablissement.Ville,
                Pays = etablissement.Pays,
                TelephoneScolarite = etablissement.TelephoneScolarite,
                TelephoneSecretariat = etablissement.TelephoneSecretariat,
                Fax = etablissement.Fax,
                Email = etablissement.Email,
                SiteWeb = etablissement.SiteWeb,
                DateCreation = etablissement.DateCreation,
                DateModification = etablissement.DateModification,
                CreerPar = etablissement.CreerPar,
                Modifierpar = etablissement.Modifierpar

            };


            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerEtablissementCorfirmation(int id)
        {
            _etablissementRepository.Delete(id);
            TempData["Message"] = "L'établissement a été supprimé avec succés";

            return RedirectToAction("Etablissements");
        }
    }
}