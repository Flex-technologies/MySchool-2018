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
using System.Diagnostics;

namespace MySchoolCollege.Controllers
{
    [Authorize(Roles ="Administrateur")]
    public class ParametreController : BaseController
    {
        private readonly EtablissementRepository _etablissementRepository;
        private readonly TypeEtablissementRepository _typeEtablissementRepository;
        private readonly AnneeScolaireRepository _anneeScolaireRepository;
        private readonly PeriodeRepository _periodeRepository;
        private readonly NiveauRepository _niveauRepository;
        private readonly CycleRepository _cycleRepository;
        private readonly AutorisationRepository _autorisationRepository;
        private readonly FiliereRepository _filiereRepository;
        private readonly MentionRepository _mentionRepository;
        private readonly AvisCERepository _avisCERepository;
        private readonly MotifAbsenceRepository _motifAbsenceRepository;
        private readonly MotifRetardRepository _motifRetardRepository;
        private readonly MinistereRepository _ministereRepository;
        private readonly InspectionRepository _inspectionRepository;
        private readonly TypeInspectionRepository _typeInspectionRepository;
        private readonly ClasseDeBaseRepository _classeDeBaseRepository;

        private readonly int nLignesParPage = int.Parse(Resources.NombreLigneParPage);

        public ParametreController()
        {
            _etablissementRepository = new EtablissementRepository(Db);
            _typeEtablissementRepository = new TypeEtablissementRepository(Db);
            _anneeScolaireRepository = new AnneeScolaireRepository(Db);
            _periodeRepository = new PeriodeRepository(Db);
            _niveauRepository = new NiveauRepository(Db);
            _cycleRepository = new CycleRepository(Db);
            _autorisationRepository = new AutorisationRepository(Db);
            _filiereRepository = new FiliereRepository(Db);
            _mentionRepository = new MentionRepository(Db);
            _avisCERepository = new AvisCERepository(Db);
            _motifAbsenceRepository = new MotifAbsenceRepository(Db);
            _motifRetardRepository = new MotifRetardRepository(Db);
            _ministereRepository = new MinistereRepository(Db);
            _inspectionRepository = new InspectionRepository(Db);
            _typeInspectionRepository = new TypeInspectionRepository(Db);
            _classeDeBaseRepository = new ClasseDeBaseRepository(Db);
        }
        // GET: Parametre
        public ActionResult Index()
        {
            return View();
        }

        //Début type établissement
        public ActionResult TypesEtablissement(int? page)
        {
            List<TypeEtablissementViewModel> model = _typeEtablissementRepository.GetList().Select(t => t.ToViewModel()).ToList();
            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }
        public ActionResult AjouterTypeEtablissement()
        {
            TypeEtablissementViewModel model = new TypeEtablissementViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AjouterTypeEtablissement(TypeEtablissementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var type = model.ToModel();
                try
                {
                    _typeEtablissementRepository.Add(type);
                    TempData["Message"] = "Type ajouté avec succès.";
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("TypesEtablissement");
            }
            return View(model);
        }

        public ActionResult SupprimerTypeEtablissement(string id)
        {
            var type = _typeEtablissementRepository.Get(id);
            if(type == null)
            {
                return HttpNotFound();
            }
            return View(type.ToViewModel());
        }

        [HttpPost]
        public ActionResult SupprimerTypeEtablissementConfirmation(string id)
        {
            try
            {
                _typeEtablissementRepository.Delete(id);
                TempData["Message"] = "Type supprimé avec succès";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }

            return RedirectToAction("TypesEtablissement");
        }
        //Fin type établissement

        //Début Etablissement
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

            var model = etablissement.ToViewModel();
            return View(model);
        }

        /// <summary>
        /// La liste des établissements
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Etablissements(int? page)
        {
            List<EtablissementViewModel> model = _etablissementRepository.GetList().Select(e => e.ToViewModel()).ToList();
            var pageNumber = page ?? 1;
            //  
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }

        //GET: 
        [HttpGet]
        public ActionResult AjouterEtablissement()
        {
            var model = new EtablissementViewModel();
            var types = _typeEtablissementRepository.GetList().Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            var inspections = _inspectionRepository.GetList().Select(s => new SelectListItem { Text = s.Nom, Value = s.Id.ToString()}).ToList();
            model.Types = types;
            model.Inspections = inspections;
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
                Etablissement etablissement = model.ToModel();
                
                etablissement.CreerPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                etablissement.Modifierpar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
               
                etablissement.Type = _typeEtablissementRepository.Get(model.TypeEtablissementId);
                etablissement.Inspection = _inspectionRepository.Get(model.InspectionId);
                etablissement.DateCreation = DateTime.Now;
                etablissement.DateModification = DateTime.Now;

                try
                {
                    _etablissementRepository.Add(etablissement);
                    TempData["Message"] = "Etablissement ajouté avec succés";
                    
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("Etablissements");

            }
            //si on arrive ici c'est à dire quelque chose ne va pas.
            var types = _typeEtablissementRepository.GetList().Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            var inspections = _inspectionRepository.GetList().Select(s => new SelectListItem { Text = s.Nom, Value = s.Id.ToString() }).ToList();
            model.Types = types;
            model.Inspections = inspections;
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
            var inspections = _inspectionRepository.GetList().Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString()}).ToList();
            

            var model = etablissement.ToViewModel();
            model.Types = types;
            model.Inspections = inspections;
            try
            {
                model.TypeEtablissementId = etablissement.Type.Id;
                model.InspectionId = etablissement.Inspection.Id;
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
                
                Etablissement etablissement = _etablissementRepository.Get(model.Id);
                model.ToSaveModel(etablissement);
                etablissement.Modifierpar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                etablissement.CreerPar = Db.Users.Where(u => u.Id == model.CreerParId).First();
                etablissement.Type = _typeEtablissementRepository.Get(model.TypeEtablissementId);
                etablissement.Inspection = _inspectionRepository.Get(model.InspectionId);
                etablissement.DateModification = DateTime.Now;
                //Db.Database.Log = s => Debug.WriteLine(s);
                try
                {
                    
                    _etablissementRepository.Update(etablissement);
                    TempData["Message"] = "Etablissement modifié avec succés";
                    
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }
                

                return RedirectToAction("Etablissements");
            }
            //si on arrive ici c'est à dire quelque chose ne va pas.
            var types = _typeEtablissementRepository.GetList().Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            var inspections = _inspectionRepository.GetList().Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            model.Types = types;
            model.Inspections = inspections;
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
        public ActionResult SupprimerEtablissementConfirmation(int id)
        {
            try
            {
                _etablissementRepository.Delete(id);
                TempData["Message"] = "L'établissement a été supprimé avec succés";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }
            return RedirectToAction("Etablissements");
        }
        //Fin Etablissement

        //Début Année scolaire
        public ActionResult DetailsAnneeScolaire(int id)
        {
            var anneeScolaire = _anneeScolaireRepository.Get(id);
            if(anneeScolaire == null)
            {
                return HttpNotFound();
            }
            var model = new ListeAnneeScolaireViewModel
            {
                Id = anneeScolaire.Id,
                AnneeAcademique = anneeScolaire.AnneeAcademique,
                Description = anneeScolaire.Description,
                DateCreation = anneeScolaire.DateCreation,
                DateModification = anneeScolaire.DateModification,
                CreerPar = anneeScolaire.CreerPar,
                Modifierpar = anneeScolaire.Modifierpar,
                Periodes = anneeScolaire.Periodes

            };
            return View(model);
        }
            /// <summary>
            /// Obtenir la liste des années Scolaire
            /// </summary>
            /// <param name="page"></param>
            /// <returns></returns>
        public ActionResult AnneeScolaires(int? page)
        {
            List<ListeAnneeScolaireViewModel> model = _anneeScolaireRepository.GetList().Select(a => new ListeAnneeScolaireViewModel {

                Id = a.Id,
                AnneeAcademique =a.AnneeAcademique,
                Description = a.Description,
                DateCreation = a.DateCreation,
                DateModification = a.DateModification,
                CreerPar = a.CreerPar,
                Modifierpar = a.Modifierpar,
                Periodes = a.Periodes


            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }

        [HttpGet]
        public ActionResult AjouterAnneeScolaire()
        {
            var model = new ListeAnneeScolaireViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterAnneeScolaire(ListeAnneeScolaireViewModel model)
        {
            if (ModelState.IsValid)
            {
                var anneeScolaire = new AnneeScolaire();
                var userCreation = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                anneeScolaire.AnneeAcademique = model.AnneeAcademique;
                anneeScolaire.Description = model.Description;
                anneeScolaire.DateCreation = DateTime.Now;
                anneeScolaire.DateModification = DateTime.Now;
                anneeScolaire.CreerPar = userCreation;
                anneeScolaire.Modifierpar = userCreation;
                try
                {
                    _anneeScolaireRepository.Add(anneeScolaire);
                }catch
                {
                    ModelState.AddModelError("","Erreur inattendue");
                    return View(model);
                }

                TempData["Message"] = "Année scolaire ajoutée avec succés";
                return RedirectToAction("AnneeScolaires");

            }
            //si on arrive ici ça veux dire que quelque chose ne va pas.
            return View(model);
        }

        [HttpGet]
        public ActionResult ModifierAnneeScolaire(int id)
        {
            var anneeScolaire = _anneeScolaireRepository.Get(id);
            if(anneeScolaire == null)
            {
                return HttpNotFound();
            }
            var model = new ListeAnneeScolaireViewModel {
                Id = anneeScolaire.Id,
                AnneeAcademique = anneeScolaire.AnneeAcademique,
                Description = anneeScolaire.Description,
                DateCreation = anneeScolaire.DateCreation,
                DateModification = anneeScolaire.DateModification,
                CreerPar = anneeScolaire.CreerPar,
                Modifierpar = anneeScolaire.Modifierpar,
                Periodes = anneeScolaire.Periodes

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierAnneeScolaire(ListeAnneeScolaireViewModel model)
        {
            if (ModelState.IsValid)
            {
                var anneeScolaire = _anneeScolaireRepository.Get(model.Id);
                var userModification = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                anneeScolaire.AnneeAcademique = model.AnneeAcademique;
                anneeScolaire.Description = model.Description;
                anneeScolaire.DateModification = DateTime.Now;
                anneeScolaire.Modifierpar = userModification;
                try
                {
                    _anneeScolaireRepository.Update(anneeScolaire);
                }
                catch
                {
                    ModelState.AddModelError("", "Erreur inattendue!");
                    return View(model);
                }

                TempData["Message"] = "Année scolaire modifiée avec succés";
                return RedirectToAction("AnneeScolaires");

            }
            //si on arrive ici ça veux dire que quelque chose ne va pas.
            return View(model);
        }

        public ActionResult SupprimerAnneeScolaire(int id)
        {
            var anneeScolaire = _anneeScolaireRepository.Get(id);
            if (anneeScolaire == null)
            {
                return HttpNotFound();
            }
            var model = new ListeAnneeScolaireViewModel
            {
                Id = anneeScolaire.Id,
                AnneeAcademique = anneeScolaire.AnneeAcademique,
                Description = anneeScolaire.Description,
                DateCreation = anneeScolaire.DateCreation,
                DateModification = anneeScolaire.DateModification,
                CreerPar = anneeScolaire.CreerPar,
                Modifierpar = anneeScolaire.Modifierpar,
                Periodes = anneeScolaire.Periodes

            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerAnneeScolaireConfirmation(int id)
        {
            try
            {
                _anneeScolaireRepository.Delete(id);
                TempData["Message"] = "Année scolaire supprimée avec succés";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue lors de la suppression";
            }
            
           
            return RedirectToAction("AnneeScolaires");
        }

        //Fin Année scolaire
        //début période

        /// <summary>
        /// obtenir la liste des périodes personnalisées
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Periodes(int? page)
        {
            List<PeriodeViewModel> model = _periodeRepository.GetList().Select(p => new PeriodeViewModel {
                Id = p.Id,
                Periode = p.Periode,
                AnneeScolaire = p.AnneeScolaire,
                DateDebut = p.DateDebut,
                DateFin = p.DateFin

            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }

        [HttpGet]
        public ActionResult AjouterPeriode(int IdAnnee)
        {
            var model = new PeriodeViewModel();
            model.DateDebut = DateTime.Now.Date;
            model.DateFin = DateTime.Now.Date;
            var annees = new List<SelectListItem>();
            if (IdAnnee != 0)
            {
                model.AnneeScolaireId = IdAnnee;
                annees = _anneeScolaireRepository.GetList().Where(a => a.Id == IdAnnee).Select(a => new SelectListItem { Text = a.Description, Value = a.Id.ToString() }).ToList();
            }
            else
            {
                annees = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.Description, Value = a.Id.ToString() }).ToList();
           
            }

             model.AnneeScolaires = annees;
             return View(model);
        }
        [HttpPost]
        public ActionResult AjouterPeriode(PeriodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AnneeScolaire = _anneeScolaireRepository.Get(model.AnneeScolaireId);
                var periode = new PeriodePersonnalisee
                                    {
                                    Periode = model.Periode,
                                    AnneeScolaire = model.AnneeScolaire,
                                    DateDebut = model.DateDebut,
                                    DateFin = model.DateFin
                };

                try
                {
                    _periodeRepository.Add(periode);
                    TempData["Message"] = "Période ajoutée avec succés";
                    return RedirectToAction("Periodes");
                }
                catch
                {
                    ModelState.AddModelError("", "Erreur inattendue!");
                    return View(model);
                }

            }

            //si on arrive ici ça veut dire ya quelque chose qui va pas
            var annees = new List<SelectListItem>();
            if (model.AnneeScolaireId != 0)
            {
               
                annees = _anneeScolaireRepository.GetList().Where(a => a.Id == model.AnneeScolaireId).Select(a => new SelectListItem { Text = a.Description, Value = a.Id.ToString() }).ToList();
            }
            else
            {
                annees = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.Description, Value = a.Id.ToString() }).ToList();

            }

            model.AnneeScolaires = annees;
            return View(model);
        }

        [HttpGet]
        public ActionResult ModifierPeriode(int id)
        {
            var periode = _periodeRepository.Get(id);
            if (periode == null)
            {
                return HttpNotFound();
            }
            var model = new PeriodeViewModel
            {

                Id = periode.Id,
                Periode = periode.Periode,
                AnneeScolaire = periode.AnneeScolaire,
                DateDebut = periode.DateDebut,
                DateFin = periode.DateFin,
                AnneeScolaireId = periode.AnneeScolaire.Id
            };
            
            var annees = new List<SelectListItem>();
            annees = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.Description, Value = a.Id.ToString() }).ToList();
            model.AnneeScolaires = annees;
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifierPeriode(PeriodeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AnneeScolaire = _anneeScolaireRepository.Get(model.AnneeScolaireId);
                var periode = _periodeRepository.Get(model.Id);
                periode.Periode = model.Periode;
                periode.AnneeScolaire = model.AnneeScolaire;
                periode.DateDebut = model.DateDebut;
                periode.DateFin = model.DateFin;
                try
                {
                    _periodeRepository.Update(periode);
                    TempData["Message"] = "Période modifiée avec succés!";
                    return RedirectToAction("Periodes");
                }
                catch
                {
                    ModelState.AddModelError("", "Erreur inattendue!");
                    return View(model);
                }
            }

            //si on arrive ici ça veut dire ya quelque chose qui va pas
            var annees = new List<SelectListItem>();
            annees = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.Description, Value = a.Id.ToString() }).ToList();
            model.AnneeScolaires = annees;
            return View(model);
        }

        public ActionResult SupprimerPeriode(int Id)
        {
            var periode = _periodeRepository.Get(Id);
            if(periode == null)
            {
                return HttpNotFound();
            }
            var model = new PeriodeViewModel
            {

                Id = periode.Id,
                Periode = periode.Periode,
                AnneeScolaire = periode.AnneeScolaire,
                DateDebut = periode.DateDebut,
                DateFin = periode.DateFin
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerPeriodeConfirmation(int Id)
        {
            try
            {
                _periodeRepository.Delete(Id);
                TempData["Message"] = "Période supprimée avec succés";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue lors de la suppression";
            }
            return RedirectToAction("Periodes");
        }
        //fin 

        //Début niveau
        /// <summary>
        /// Obtenir la liste des Niveaux
        /// </summary>
        /// <param name="page">Numéro de page pour la navigation dans les tableaux</param>
        /// <returns></returns>
        public ActionResult Niveaux(int? page)
        {
            List<NiveauViewModel> model = _niveauRepository.GetList().Select(n => new NiveauViewModel {
                Id = n.Id,
                Description = n.Description,
                Cycle = n.Cycle,
                Bareme = n.Bareme,
                ClasseDeBases = n.ClasseDeBases

            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }
        [HttpGet]
        public ActionResult AjouterNiveau()
        {
            NiveauViewModel model = new NiveauViewModel();
            model.Cycles = _cycleRepository.GetList().Select(c => new SelectListItem { Value = c.Id, Text = c.Description }).ToList() ;

            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterNiveau(NiveauViewModel model)
        {
            var cycle = _cycleRepository.Get(model.CycleId);
            model.Cycle = cycle;

            if (ModelState.IsValid)
            {
                Niveau niveau = new Niveau {
                    Id = model.Id,
                    Description = model.Description,
                    Bareme = model.Bareme,
                    Cycle = cycle

                };

                try
                {
                    _niveauRepository.Add(niveau);
                    TempData["Message"] = "Niveau ajouté avec succès";
                    return RedirectToAction("Niveaux");
                }
                catch
                {
                    ModelState.AddModelError("", "Erreur inattendue!");
                }
            }
            //si arrive ici ça veut dire quelque chose ne va pas.
            model.Cycles = _cycleRepository.GetList().Select(c => new SelectListItem { Value = c.Id, Text = c.Description }).ToList();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult ModifierNiveau(string id)
        {
            var niveau = _niveauRepository.Get(id);
            if(niveau == null)
            {
                return HttpNotFound();
            }
            var model = new NiveauViewModel {
                Id = niveau.Id,
                Description = niveau.Description,
                Bareme = niveau.Bareme,
                Cycle = niveau.Cycle,
                Cycles = _cycleRepository.GetList().Select(c => new SelectListItem { Value = c.Id, Text = c.Description }).ToList(),
                CycleId = niveau.Cycle.Id
             };
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifierNiveau(NiveauViewModel model)
        {
            if (ModelState.IsValid)
            {
                var niveau = _niveauRepository.Get(model.Id);
                niveau.Description = model.Description;
                niveau.Bareme = model.Bareme;
                var cycle = _cycleRepository.Get(model.CycleId);
                niveau.Cycle = cycle;
                try
                {
                    _niveauRepository.Update(niveau);
                    TempData["Message"] = "Niveau modifié avec succès";
                    return RedirectToAction("Niveaux");
                }
                catch
                {
                   
                    ModelState.AddModelError("", "Erreur inattendue!");
                    return View(model);
                }
            }
            model.Cycles = _cycleRepository.GetList().Select(c => new SelectListItem { Value = c.Id, Text = c.Description }).ToList();
            return View(model);
        }
        public ActionResult SupprimerNiveau( string id)
        {
            var niveau = _niveauRepository.Get(id);
            if(niveau == null)
            {
                return HttpNotFound();
            }
            var model = new NiveauViewModel
            {
                Id = niveau.Id,
                Description = niveau.Description,
                Bareme = niveau.Bareme,
                Cycle = niveau.Cycle,
                

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerNiveauConfirmation(string id)
        {
            try
            {
                _niveauRepository.Delete(id);
                TempData["Message"] = "Niveau supprimé avec succès";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue lors de la suppression!";
            }
            return RedirectToAction("Niveaux");

        }
        //fin niveau

        //Debut Cycle
        public ActionResult Cycles(int? page)
        {
            List<CycleViewModel> model = _cycleRepository.GetList().Select(c => new CycleViewModel {
                Id = c.Id,
                Description = c.Description

            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }
        [HttpGet]
        public ActionResult AjouterCycle()
        {
            var model = new CycleViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterCycle(CycleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cycle = new Cycle();
                cycle.Id = model.Id;
                cycle.Description = model.Description;
                try
                {
                    _cycleRepository.Add(cycle);
                    TempData["Message"] = "Cycle ajouté avec succès";
                    return RedirectToAction("Cycles");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }
            }
            //si on arrive ici ça veut dire que quelque chose ne va pas
            return View(model);
        }
        [HttpGet]
        public ActionResult ModifierCycle(string id)
        {
            var cycle = _cycleRepository.Get(id);
            if(cycle == null)
            {
                return HttpNotFound();
            }
            var model = new CycleViewModel
            {
                Id = cycle.Id,
                Description = cycle.Description
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifierCycle(CycleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cycle = _cycleRepository.Get(model.Id);
                cycle.Description = model.Description;
                try
                {
                    _cycleRepository.Update(cycle);
                    TempData["Message"] = "Cycle modifié avec succès";
                    return RedirectToAction("Cycles");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

            }
            //si on arrive ici ça veut dire que ya quelque qui va pas
            return View(model);
        }
        public ActionResult SupprimerCycle(string id)
        {
            var cycle = _cycleRepository.Get(id);
            if(cycle == null)
            {
                return HttpNotFound();
            }
            var model = new CycleViewModel {
                                Id = cycle.Id,
                                Description = cycle.Description
                            };
            
            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerCycleConfirmation(string id)
        {
            try
            {
                _cycleRepository.Delete(id);
                TempData["Message"] = "Cycle supprimé avec succès.";
                
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue";
                
            }
            return RedirectToAction("Cycles");
        }

        //Fin Cycle
        //Début autorisation
        /// <summary>
        /// Obtenir la liste des autoriisations
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Autorisations(int? page)
        {
            List<AutorisationViewModel> model = _autorisationRepository.GetList().Select( a => new AutorisationViewModel {
                Id = a.Id,
                libelle = a.libelle,
                Entree = a.Entree,
                Sortie = a.Sortie,
                Description = a.Description

            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }
        [HttpGet]
        public ActionResult AjouterAutorisation()
        {
            var model = new AutorisationViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterAutorisation(AutorisationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var autorisation = new Autorisation {
                    Id = model.Id,
                    libelle = model.libelle,
                    Entree = model.Entree,
                    Sortie = model.Sortie,
                    Description = model.Description
                };
                try
                {
                    _autorisationRepository.Add(autorisation);
                    TempData["Message"] = "Autorisation ajoutée avec succès.";
                    return RedirectToAction("Autorisations");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }
            }
            //si on arrive ici ça veut dire quelque chose ne va pas
            return View(model);
        }
        public ActionResult ModifierAutorisation(string id)
        {
            var autorisation = _autorisationRepository.Get(id);
            if(autorisation == null)
            {
                return HttpNotFound();
            }
            var model = new AutorisationViewModel {

                Id = autorisation.Id,
                libelle = autorisation.libelle,
                Entree = autorisation.Entree,
                Sortie = autorisation.Sortie,
                Description =autorisation.Description

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifierAutorisation(AutorisationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var autorisation = _autorisationRepository.Get(model.Id);
                autorisation.libelle = model.libelle;
                autorisation.Entree = model.Entree;
                autorisation.Sortie = model.Sortie;
                autorisation.Description = model.Description;
                try
                {
                    _autorisationRepository.Update(autorisation);
                    TempData["Message"] = "Autorisation modifiée avec succès.";
                    return RedirectToAction("Autorisations");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue";
                }
            }
            return View(model);
        }
        public ActionResult SupprimerAutorisation(string id)
        {
            var autorisation = _autorisationRepository.Get(id);
            if(autorisation == null)
            {
                return HttpNotFound();
            }
            AutorisationViewModel model = new AutorisationViewModel {
                Id = autorisation.Id,
                libelle = autorisation.libelle,
                Entree = autorisation.Entree,
                Sortie = autorisation.Sortie,
                Description = autorisation.Description
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerAutorisationConfirmation(string id)
        {
            try
            {
                _autorisationRepository.Delete(id);
                TempData["Message"] = "Autorisation supprimée avec succès.";
                
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
                
            }
            return RedirectToAction("Autorisations");
        }
        //Fin autorisation
        //Début Filière
        /// <summary>
        /// Obtenir la liste des filières
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Filieres(int? page)
        {
            List<FiliereViewModel> model = _filiereRepository.GetList().Select(f => new FiliereViewModel {
                Id = f.Id,
                Description = f.Description,
                TypeEtablissement = f.TypeEtablissement,
                LivretScolaire = f.LivretScolaire,
                ClasseDeBases = f.ClasseDeBase

            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber,nLignesParPage));
        }
        public ActionResult AjouterFiliere()
        {
            var model = new FiliereViewModel();
            List<SelectListItem> typeEtab = _typeEtablissementRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id }).ToList();
            model.TypesEtablissement = typeEtab;
            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterFiliere(FiliereViewModel model)
        {
            if (ModelState.IsValid)
            {
                var filiere = new Filiere {
                    Id = model.Id,
                    Description = model.Description,
                    TypeEtablissement = _typeEtablissementRepository.Get(model.TypeEtablissementId),
                    LivretScolaire = model.LivretScolaire

                };
                try
                {
                    _filiereRepository.Add(filiere);
                    TempData["Message"] = "filière ajoutée avec succès";
                    return RedirectToAction("Filieres");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }
            }
            //si on arrive ici ça veut dire que ya probléme
            model.TypesEtablissement = _typeEtablissementRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id }).ToList();
            return View(model);
        }
        public ActionResult ModifierFiliere(string id)
        {
            var filiere = _filiereRepository.Get(id);
            if(filiere == null)
            {
                return HttpNotFound();
            }
            var model = new FiliereViewModel {
                Id = filiere.Id,
                Description = filiere.Description,
                //TypeEtablissement = filiere.TypeEtablissement,
                //TypeEtablissementId = filiere.TypeEtablissement.Id,
                LivretScolaire = filiere.LivretScolaire
            };
            model.TypeEtablissement = filiere.TypeEtablissement;
            model.TypeEtablissementId = filiere.TypeEtablissement.Id;
            model.TypesEtablissement = _typeEtablissementRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifierFiliere(FiliereViewModel model)
        {
            if (ModelState.IsValid)
            {
                var filiere = _filiereRepository.Get(model.Id);
                filiere.Description = model.Description;
                filiere.TypeEtablissement = _typeEtablissementRepository.Get(model.TypeEtablissementId);
                filiere.LivretScolaire = model.LivretScolaire;
                try
                {
                    _filiereRepository.Update(filiere);
                    TempData["Message"] = "Filière modifiée avec succès.";
                    return RedirectToAction("Filieres");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }
            }
            //si on arrive ici ça veut dire quelque chose ne va pas
            model.TypesEtablissement = _typeEtablissementRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id }).ToList();
            return View(model);
        }
        public ActionResult SupprimerFiliere(string id)
        {
            var filiere = _filiereRepository.Get(id);
            if(filiere == null)
            {
                return HttpNotFound();
            }
            var model = new FiliereViewModel {
                Id = filiere.Id,
                Description = filiere.Description,

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerFiliereConfirmation(string id)
        {
            try
            {
                _filiereRepository.Delete(id);
                TempData["Message"] = "Filière supprimée avec succès.";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }
            return RedirectToAction("Filieres");
        }
        //Fin Filière
        //Début mentions
        public ActionResult Mentions(int? page)
        {
            List<MentionViewModel> model = _mentionRepository.GetList().Select(m => new MentionViewModel {
                Id = m.Id,
                Description = m.Description,
                AImprimer = m.AImprimer
            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }
        public ActionResult AjouterMention()
        {
            var model = new MentionViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterMention(MentionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mention = new Mention {
                    Description = model.Description,
                    AImprimer = model.AImprimer
                };
                try
                {
                    _mentionRepository.Add(mention);
                    TempData["message"] = "Mention ajoutée avec succès.";
                    return RedirectToAction("Mentions");
                }
                catch
                {
                    TempData["messageErreur"] = "Erreur inattendue!";
                }
            }
            //si on arrive ici ça veut dire que quelque chose qui ne va pas.
            return View(model);
        }
        public ActionResult ModifierMention(int id)
        {
            var mention = _mentionRepository.Get(id);
            if(mention == null)
            {
                return HttpNotFound();
            }
            MentionViewModel model = new MentionViewModel {

                Id = mention.Id,
                Description = mention.Description,
                AImprimer = mention.AImprimer
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifierMention(MentionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mention = _mentionRepository.Get(model.Id);
                mention.Description = model.Description;
                mention.AImprimer = model.AImprimer;

                try
                {
                    _mentionRepository.Update(mention);
                    TempData["message"] = "Mention modifiée avec succès.";
                    return RedirectToAction("Mentions");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattentue!";
                }
            }
            //si on arrive ici ça veut dire que quelque chose ne va pas.
            return View(model);
        }
        public ActionResult SupprimerMention(int id)
        {
            var mention = _mentionRepository.Get(id);
            if(mention == null)
            {
                return HttpNotFound();
            }
            var model = new MentionViewModel {

                Id = mention.Id,
                Description = mention.Description,
                AImprimer = mention.AImprimer
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerMentionConfirmation(int id)
        {
            try
            {
                _mentionRepository.Delete(id);
                TempData["message"] = "Mention supprimée avec succès.";
               
            }
            catch
            {
                TempData["messageErreur"] = "Erreur inattendue!";
            }
            return RedirectToAction("Mentions");
        }
        //Fin mentions
        //Début Avis Chef d'établissement
        public ActionResult AvisCE(int? page)
        {
            List<AvisCEViewModel> model = _avisCERepository.GetList().Select(a => new AvisCEViewModel {
                Id = a.Id,
                Avis = a.Avis,
                Brevet = a.Brevet,
                LivretBacGeneral = a.LivretBacGeneral,
                LivretBacPro = a.LivretBacPro,
                LivretStandard = a.LivretStandard

            }).ToList();
            var pageNumber = page ?? 1;
              
            return View(model.ToPagedList(pageNumber,nLignesParPage));
           
        }
        public ActionResult AjouterAvisCE()
        {
            var model = new AvisCEViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterAvisCE( AvisCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var avisCE = model.ToModel();
                try
                {
                    _avisCERepository.Add(avisCE);
                    TempData["message"] = "AvisCE ajouté avec succès.";
                    return RedirectToAction("AvisCE");
                }
                catch(Exception e)
                {
                    TempData["messageErreur"] = "Erreur inattendue!";
                    ModelState.AddModelError("", e.Message);
                }
            }
            //si on arrive ici ça veut dire que quelque chose ne va pas
            return View(model);
        }
        public ActionResult ModifierAvisCE(int id)
        {
            var avisce = _avisCERepository.Get(id);
            if(avisce == null)
            {
                return HttpNotFound();
            }
            var model = avisce.ToModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ModifierAvisCE(AvisCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var avisce = model.ToModel();
                _avisCERepository.Context.Entry(avisce).State = EntityState.Modified;
                try
                {
                    _avisCERepository.Update(avisce);
                    TempData["message"] = "AvisCE modifié avec succès.";
                    return RedirectToAction("AvisCE");
                }
                catch(Exception e)
                {
                    TempData["messageErreur"] = "Erreure inattendue!";
                    ModelState.AddModelError("", e.Message);
                }
            }
            //si on arrive ici ça veut dire que quelque chose ne va pas
            return View(model);
        }
        public ActionResult SupprimerAvisCE(int id)
        {
            var avisce = _avisCERepository.Get(id);
            if(avisce == null)
            {
                return HttpNotFound();
            }
            
            var model = avisce.ToModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult SupprimerAvisCEConfirmation(int id)
        {
            try
            {
                _avisCERepository.Delete(id);
                TempData["message"] = "AvisCE supprimé avec succès.";

            }
            catch
            {
                TempData["messageErreur"] = "Erreur inattendue!";
            }

            return RedirectToAction("AvisCE");
        }
        //Fin Avis
        //Début MotifAbsence
        /// <summary>
        /// Retourne la liste des motifs d'absence sous forme de pagination
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult MotifAbsences(int? page)
        {
            List<MotifAbsenceViewModel> model = _motifAbsenceRepository.GetList().Select(m => m.ToModel()).ToList();
            var pageNumber = page ?? 1;
            
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }
        public ActionResult AjouterMotifAbsence()
        {
            MotifAbsenceViewModel model = new MotifAbsenceViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult AjouterMotifAbsence(MotifAbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motif = model.ToModel();
                try
                {
                    _motifAbsenceRepository.Add(motif);
                    TempData["message"] = "Motif d'absence ajouté avec succès.";
                    return RedirectToAction("MotifAbsences");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);

                }
            }
            //Si on arrive ici ça veut dire qu'il ya un probleme
            return View(model);
        }

        public ActionResult ModifierMotifAbsence(string id)
        {
            var motif = _motifAbsenceRepository.Get(id);
            if(motif == null)
            {
                return HttpNotFound();
            }
            var model = motif.ToModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierMotifAbsence(MotifAbsenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motif = model.ToModel();
                
                //Reattacher le model au context
                _motifAbsenceRepository.Context.Entry(motif).State = EntityState.Modified;

                try
                {
                    _motifAbsenceRepository.Update(motif);
                    TempData["message"] = "Motif d'absence modifié avec succès.";
                    return RedirectToAction("MotifAbsences");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            //si on arrive ici ça veut dire que quelque chose ne va pas
            return View(model);
        }
        
        public ActionResult SupprimerMotifAbsence(string id)
        {
            var motif = _motifAbsenceRepository.Get(id);

            if(motif == null) {

                return HttpNotFound();
            }
            var model = motif.ToModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerMotifAbsenceConfirmation(string id)
        {
            try
            {
                _motifAbsenceRepository.Delete(id);
                TempData["message"] = "Motif Absence supprimé avec succès.";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }

            return RedirectToAction("MotifAbsences");
        }
        //Fin MotifAbsence
        
        //Début Ministere
        public ActionResult Ministeres(int? page)
        {
            List<MinistereViewModel> model = _ministereRepository.GetList().Select(m => m.ToViewModel()).ToList();
            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber,nLignesParPage));
        }

        public ActionResult AjouterMinistere()
        {
            MinistereViewModel model = new MinistereViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AjouterMinistere(MinistereViewModel model)
        {
            if (ModelState.IsValid)
            {
                Ministere ministere = model.ToModel();
                ministere.CreerLe = DateTime.Now;
                ministere.ModifierLe = DateTime.Now;
                ministere.CreerPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                ministere.ModifierPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();

                try
                {
                    _ministereRepository.Add(ministere);
                    TempData["message"] = "Organisme créé avec succès.";
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("Ministeres");
            }

            //Si on arrive ici ça veut dire que quelque ne va pas.
            return View(model);
        }
        
        public ActionResult ModifierMinistere(int id)
        {
            var ministere = _ministereRepository.Get(id);
            if(ministere == null)
            {
                return HttpNotFound();
            }
            var model = ministere.ToViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierMinistere(MinistereViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ministere = model.ToModel();

                ministere.ModifierLe = DateTime.Now;
                ministere.ModifierPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                ministere.CreerPar = Db.Users.Where(u => u.Id == model.CreerParId).First();

                //Rattache le model au context courant
                _ministereRepository.Context.Entry(ministere).State = EntityState.Modified;

                try
                {
                    _ministereRepository.Update(ministere);
                    TempData["message"] = "Organisme modifié avec succès.";
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("Ministeres");

            }

            //Si on arrive ici ça veut dire que quelque chose ne va pas.
            return View(model);
        }

        public ActionResult SupprimerMinistere(int id)
        {
            var ministere = _ministereRepository.Get(id);
            if(ministere == null)
            {
                return HttpNotFound();
            }

            var model = ministere.ToViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerMinistereConfirmation(int id)
        {
            try
            {
                _ministereRepository.Delete(id);
                TempData["message"] = "Organisme supprimé avec succès!";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }
            return RedirectToAction("Ministeres");
        }
        //Fin Ministere

        //Début inspection
        public ActionResult TypesInspection(int? page)
        {
            List<TypeInspectionViewModel> model = _typeInspectionRepository.GetList().Select(t => t.ToViewModel()).ToList();
            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber,nLignesParPage));
        }

        public ActionResult AjouterTypeInspection()
        {
            TypeInspectionViewModel model = new TypeInspectionViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AjouterTypeInspection(TypeInspectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var typeInspection = model.ToModel();
                try
                {
                    _typeInspectionRepository.Add(typeInspection);
                    TempData["Message"] = "Type (" + typeInspection.Id + ") ajouté avec succès.";
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("TypesInspection");
            }
            return View(model);
        }

        public ActionResult SupprimerTypeInspection(int id)
        {
            var typeInspection = _typeInspectionRepository.Get(id);
            TypeInspectionViewModel model = typeInspection.ToViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerTypeInspectionConfirmation(int id)
        {
            try
            {
                _typeInspectionRepository.Delete(id);
                TempData["Message"] = "Type (" + id + ") supprimé avec succès.";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }

            return RedirectToAction("TypesInspection");
        }

        public ActionResult Inspections(int? page)
        {
            List<InspectionViewModel> model = _inspectionRepository.GetList().Select(i => i.ToViewModel()).ToList();
            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber,nLignesParPage));
        }

        public ActionResult AjouterInspection()
        {
            InspectionViewModel model = new InspectionViewModel();
            model.MinisteresSelect = _ministereRepository.GetList().Select(m => new SelectListItem { Text = m.Nom, Value = m.Id.ToString()}).ToList();
            model.InspectionsSelect = _inspectionRepository.GetList().Select( i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString()}).ToList();
            model.TypeInspectionsSelect = _typeInspectionRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id.ToString()}).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AjouterInspection(InspectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreerPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                model.ModifierPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                model.CreerLe = DateTime.Now;
                model.ModifierLe = DateTime.Now;

                if(model.InspectionParentId == null)
                {
                    model.InspectionParent = null;
                }
                else
                {
                    model.InspectionParent = _inspectionRepository.Get(int.Parse(model.InspectionParentId.ToString()));
                }
                
                model.Ministere = _ministereRepository.Get(model.MinistereId);
                model.TypeInspection = _typeInspectionRepository.Get(model.TypeInspectionId);
                var inspection = model.ToModel();
                try
                {
                    _inspectionRepository.Add(inspection);
                    TempData["message"] = "Inspection ajoutée avec succès.";
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("Inspections");
            }

            //Si on arrive ici ça veut dire que quelque chose ne va pas.
            model.MinisteresSelect = _ministereRepository.GetList().Select(m => new SelectListItem { Text = m.Nom, Value = m.Id.ToString() }).ToList();
            model.InspectionsSelect = _inspectionRepository.GetList().Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            model.TypeInspectionsSelect = _typeInspectionRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id.ToString() }).ToList();

            return View(model);
        }

        public ActionResult ModifierInspection(int id)
        {
            var inspection = _inspectionRepository.Get(id);
            if(inspection == null)
            {
                return HttpNotFound();
            }
            var model = inspection.ToViewModel();
            model.TypeInspectionId = inspection.TypeInspection.Id;

            if (inspection.InspectionParent == null)
            {
                model.InspectionParentId = null;
            }
            else
            {
                model.InspectionParentId = inspection.InspectionParent.Id;
            }
            
            model.MinistereId = inspection.Ministere.Id;
            model.CreerParId = inspection.CreerPar.Id;
            model.MinisteresSelect = _ministereRepository.GetList().Select(m => new SelectListItem { Text = m.Nom, Value = m.Id.ToString() }).ToList();
            model.InspectionsSelect = _inspectionRepository.GetList().Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            model.TypeInspectionsSelect = _typeInspectionRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierInspection(InspectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreerPar = Db.Users.Where(u => u.Id == model.CreerParId).First();
                model.ModifierPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                model.ModifierLe = DateTime.Now;
                if (model.InspectionParentId == null)
                {
                    model.InspectionParent = null;
                }
                else
                {
                    model.InspectionParent = _inspectionRepository.Get(int.Parse(model.InspectionParentId.ToString()));
                }
               
                model.Ministere = _ministereRepository.Get(model.MinistereId);
                model.TypeInspection = _typeInspectionRepository.Get(model.TypeInspectionId);
                //var inspection = model.ToModel();
                var inspection = _inspectionRepository.Get(model.Id);
                model.ToSaveModel(inspection);
                try
                {
                    
                    _inspectionRepository.Update(inspection);
                    TempData["Message"] = "Inspection modifiée avec succès.";
                }
                catch
                {
                    
                    TempData["MessageErreur"] = "Erreur inattendue!";
                }

                return RedirectToAction("Inspections");
            }

            //Si on arrive ici ça veut que quelque chose ne va pas.
            model.MinisteresSelect = _ministereRepository.GetList().Select(m => new SelectListItem { Text = m.Nom, Value = m.Id.ToString() }).ToList();
            model.InspectionsSelect = _inspectionRepository.GetList().Select(i => new SelectListItem { Text = i.Nom, Value = i.Id.ToString() }).ToList();
            model.TypeInspectionsSelect = _typeInspectionRepository.GetList().Select(t => new SelectListItem { Text = t.Description, Value = t.Id.ToString() }).ToList();

            return View(model);
        }

        public ActionResult SupprimerInspection(int id)
        {
            var inspection = _inspectionRepository.Get(id);
            if(inspection == null)
            {
                return HttpNotFound();
            }
            var model = inspection.ToViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerInspectionConfirmation(int id)
        {
            try
            {
                _inspectionRepository.Delete(id);
                TempData["message"] = "Inspection supprimée avec succès.";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }

            return RedirectToAction("Inspections");
        }
        //Fin inspection

        //Début ClasseDeBase
        public ActionResult ClasseDeBases(int? page)
        {
            List<ClasseDeBaseViewModel> model = _classeDeBaseRepository.GetList().Select(c => c.ToViewModel()).ToList();
            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber,nLignesParPage));
        }

        public ActionResult AjouterClasseDeBase()
        {
            ClasseDeBaseViewModel model = new ClasseDeBaseViewModel();
            model.Niveaux = _niveauRepository.GetList().Select(n => new SelectListItem { Value = n.Id, Text = n.Description }).ToList();
            model.Filieres = _filiereRepository.GetList().Select(f => new SelectListItem { Value = f.Id, Text = f.Description }).ToList();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AjouterClasseDeBase(ClasseDeBaseViewModel model)
        {
            model.CreerPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
            model.ModifierPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
            model.CreerLe = DateTime.Now;
            model.ModifierLe = DateTime.Now;
            model.Niveau = _niveauRepository.Get(model.NiveauId);
            model.Filiere = _filiereRepository.Get(model.FiliereId);
           

            if (ModelState.IsValid)
            {
                var classe = new ClasseDeBase();
                classe = model.ToModel();
                try
                {
                    _classeDeBaseRepository.Add(classe);
                    TempData["Message"] = "Clase de base ajoutée avec succès!";
                    return RedirectToAction("ClasseDeBases");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue";
                }
            }

            //si on arrive ici ça veut dire qu'il y a un problème!
            model.Niveaux = _niveauRepository.GetList().Select(n => new SelectListItem { Value = n.Id, Text = n.Description }).ToList();
            model.Filieres = _filiereRepository.GetList().Select(f => new SelectListItem { Value = f.Id, Text = f.Description }).ToList();
            return View(model);
        }

        public ActionResult ModifierClasseDeBase(int Id)
        {
            var classe = _classeDeBaseRepository.Get(Id);
            if(classe == null)
            {
                return HttpNotFound();
            }

            var model = new ClasseDeBaseViewModel();
            model = classe.ToViewModel();
            model.Niveaux = _niveauRepository.GetList().Select(n => new SelectListItem { Value = n.Id, Text = n.Description }).ToList();
            model.Filieres = _filiereRepository.GetList().Select(f => new SelectListItem { Value = f.Id, Text = f.Description }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierClasseDeBase(ClasseDeBaseViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                model.ModifierPar = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
                model.ModifierLe = DateTime.Now;
                model.Niveau = _niveauRepository.Get(model.NiveauId);
                model.Filiere = _filiereRepository.Get(model.FiliereId);

                var classe = _classeDeBaseRepository.Get(model.Id);
                model.ToSaveModel(classe);
                try
                {
                    _classeDeBaseRepository.Update(classe);
                    TempData["Message"] = "Clase de base modifiée avec succès!";
                    return RedirectToAction("ClasseDeBases");
                }
                catch
                {
                    TempData["MessageErreur"] = "Erreur inattendue";
                }
            }

            //si on arrive ici ça veut dire qu'il y a un problème!
            model.Niveaux = _niveauRepository.GetList().Select(n => new SelectListItem { Value = n.Id, Text = n.Description }).ToList();
            model.Filieres = _filiereRepository.GetList().Select(f => new SelectListItem { Value = f.Id, Text = f.Description }).ToList();
            return View(model);
        }

        public ActionResult SupprimerClasseDeBase(int id)
        {
            var classe = _classeDeBaseRepository.Get(id);
            if(classe == null)
            {
                return HttpNotFound();
            }
            var model = new ClasseDeBaseViewModel();
            model = classe.ToViewModel();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult SupprimerClasseDeBaseConfirmation(int id)
        {
            try
            {
                _classeDeBaseRepository.Delete(id);
                TempData["Message"] = "Classe de base supprimée avec succès!";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }
            return RedirectToAction("ClasseDeBases");
        }
        //Fin ClasseDeBase

    }
}