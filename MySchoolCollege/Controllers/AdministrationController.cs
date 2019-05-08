using MySchoolCollege.Properties;
using MySchoolLibrary2018.Models.ModelViews;
using MySchoolLibrary2018.Models.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySchoolCollege.Controllers
{
    [Authorize(Roles = "Directeur,Surveillant")]
    public class AdministrationController : BaseController
    {
        private readonly ClasseRepository _classeRepository;
        private readonly EtablissementRepository _etablissementRepository;
        private readonly AnneeScolaireRepository _anneeScolaireRepository;
        private readonly ClasseDeBaseRepository _classeDeBaseRepository;

        private readonly int nLignesParPage = int.Parse(Resources.NombreLigneParPage);

        public AdministrationController()
        {
            _classeRepository = new ClasseRepository(Db);
            _etablissementRepository = new EtablissementRepository(Db);
            _anneeScolaireRepository = new AnneeScolaireRepository(Db);
            _classeDeBaseRepository = new ClasseDeBaseRepository(Db);
        }

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        //Gestion des classes
        public ActionResult Classes(int? page, int? annee)
        {
            var userOnLigne = Db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            int id = 0;
            if (userOnLigne.Etablissement != null)
            {

                id = userOnLigne.Etablissement.Id;
            }
            var etablissement = userOnLigne.Etablissement; //_etablissementRepository.Get(id);
            List<ClasseViewModel> model = new List<ClasseViewModel>();
            if (etablissement == null)
            {
                if (annee != 0)
                {
                    model = _classeRepository.GetList().Select(c => c.ToViewModel()).Where(c => c.AnneeScolaireId == annee).ToList();
                }
                else
                {
                    model = _classeRepository.GetList().Select(c => c.ToViewModel()).ToList();
                }

            }
            else
            {
                model = _classeRepository.GetList(etablissement.Id).Select(c => c.ToViewModel()).ToList();
            }

            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber, nLignesParPage));
        }

        public ActionResult AjouterClasse()
        {
            var userOnLigne = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
            var etablissement = userOnLigne.Etablissement;
            var model = new ClasseViewModel();

            model.Professeurs = Db.Users.Where(u1 => u1.Etablissement.Id == etablissement.Id).Where(u => u.Fonction.Id == "PROFESSEUR").Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id }).ToList();
            model.AnneeScolaires = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.AnneeAcademique, Value = a.Id.ToString() }).ToList();
            model.Etablissements = _etablissementRepository.GetList().Where(et => et.Id == etablissement.Id).Select(e => new SelectListItem { Text = e.Nom, Value = e.Id.ToString() }).ToList();
            model.ClasseDeBases = _classeDeBaseRepository.GetList().Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AjouterClasse(ClasseViewModel model)
        {
            var userOnLigne = Db.Users.Where(u => u.UserName == User.Identity.Name).First();

            if (ModelState.IsValid)
            {
                model.CreerLe = DateTime.Now;
                model.CreerPar = userOnLigne;
                model.ModifierLe = DateTime.Now;
                model.Modifierpar = userOnLigne;

                model.ProfesseurPrincipal = Db.Users.Where(u => u.Id == model.ProfesseurPrinciplaId).FirstOrDefault();
                model.AnneeScolaire = _anneeScolaireRepository.Get(model.AnneeScolaireId);
                model.Etablissement = _etablissementRepository.Get(model.EtablissementId);
                model.ClasseDeBase = _classeDeBaseRepository.Get(model.ClasseDeBaseId);


                //On vérifie si la classe n'est pas déjà créée
                var xclasse = Db.Classes.Where(c => (c.AnneeScolaire.Id == model.AnneeScolaireId) && (c.Etablissement.Id == model.EtablissementId) && (c.ClasseDeBase.Id == model.ClasseDeBaseId)).FirstOrDefault();
                if (xclasse != null)
                {
                    ModelState.AddModelError("", "La classe est déjà ajoutée");
                }
                else
                {
                    var classe = model.ToModel();
                    try
                    {
                        _classeRepository.Add(classe);
                        TempData["Message"] = "Classe [" + classe.ClasseDeBase.Nom + "] ajoutée avec succès!";
                    }
                    catch
                    {
                        TempData["MessageErreur"] = "Erreur inattendue!";
                    }

                    return RedirectToAction("Classes");
                }

            }

            //Si on arrive ici ça veut dire qu'il ya un probléme
            var etablissement = userOnLigne.Etablissement;
            model.Professeurs = Db.Users.Where(u1 => u1.Etablissement.Id == etablissement.Id).Where(u => u.Fonction.Id == "PROFESSEUR").Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id }).ToList();
            model.AnneeScolaires = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.AnneeAcademique, Value = a.Id.ToString() }).ToList();
            model.Etablissements = _etablissementRepository.GetList().Where(et => et.Id == etablissement.Id).Select(e => new SelectListItem { Text = e.Nom, Value = e.Id.ToString() }).ToList();
            model.ClasseDeBases = _classeDeBaseRepository.GetList().Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList();

            return View(model);
        }

        public ActionResult ModifierClasse(int id)
        {
            var classe = _classeRepository.Get(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            var model = classe.ToViewModel();
            var userOnLigne = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
            var etablissement = userOnLigne.Etablissement;
            if (etablissement != null)
            {
                model.Professeurs = Db.Users.Where(u1 => u1.Etablissement.Id == etablissement.Id).Where(u => u.Fonction.Id == "PROFESSEUR").Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id }).ToList();
                model.Etablissements = _etablissementRepository.GetList().Where(et => et.Id == etablissement.Id).Select(e => new SelectListItem { Text = e.Nom, Value = e.Id.ToString() }).ToList();
            }
            else
            {
                model.Professeurs = Db.Users.Where(u => u.Fonction.Id == "PROFESSEUR").Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id }).ToList();
                model.Etablissements = _etablissementRepository.GetList().Select(e => new SelectListItem { Text = e.Nom, Value = e.Id.ToString() }).ToList();
            }

            model.AnneeScolaires = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.AnneeAcademique, Value = a.Id.ToString() }).ToList();
            model.ClasseDeBases = _classeDeBaseRepository.GetList().Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult ModifierClasse(ClasseViewModel model)
        {
            var userOnLigne = Db.Users.Where(u => u.UserName == User.Identity.Name).First();
            if (ModelState.IsValid)
            {

                model.ModifierLe = DateTime.Now;
                model.Modifierpar = userOnLigne;
                model.ProfesseurPrincipal = Db.Users.Where(u => u.Id == model.ProfesseurPrinciplaId).FirstOrDefault();
                model.AnneeScolaire = _anneeScolaireRepository.Get(model.AnneeScolaireId);
                model.Etablissement = _etablissementRepository.Get(model.EtablissementId);
                model.ClasseDeBase = _classeDeBaseRepository.Get(model.ClasseDeBaseId);

                //On vérifie si la classe n'est pas déjà créée
                var xclasse = Db.Classes.Where(c => (c.AnneeScolaire.Id == model.AnneeScolaireId) && (c.Etablissement.Id == model.EtablissementId) && (c.ClasseDeBase.Id == model.ClasseDeBaseId)).FirstOrDefault();
                if (xclasse != null && xclasse.Id != model.Id)
                {
                    ModelState.AddModelError("", "La classe est déjà ajoutée");
                }
                else
                {
                    var classe = _classeRepository.Get(model.Id);
                    model.CreerPar = classe.CreerPar;
                    model.ToSaveModel(classe);
                    try
                    {
                        _classeRepository.Update(classe);
                        TempData["Message"] = "Classe [" + classe.ClasseDeBase.Nom + "] modifiée avec succès!";
                    }
                    catch
                    {
                        TempData["MessageErreur"] = "Erreur inattendue!";
                    }

                    return RedirectToAction("Classes");
                }
            }
            //si on arrive ici ça veux dire qu'il ya un probleme
            var etablissement = userOnLigne.Etablissement;
            if (etablissement != null)
            {
                model.Professeurs = Db.Users.Where(u1 => u1.Etablissement.Id == etablissement.Id).Where(u => u.Fonction.Id == "PROFESSEUR").Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id }).ToList();
                model.Etablissements = _etablissementRepository.GetList().Where(et => et.Id == etablissement.Id).Select(e => new SelectListItem { Text = e.Nom, Value = e.Id.ToString() }).ToList();
            }
            else
            {
                model.Professeurs = Db.Users.Where(u => u.Fonction.Id == "PROFESSEUR").Select(p => new SelectListItem { Text = p.Prenom + " " + p.Nom, Value = p.Id }).ToList();
                model.Etablissements = _etablissementRepository.GetList().Select(e => new SelectListItem { Text = e.Nom, Value = e.Id.ToString() }).ToList();
            }

            model.AnneeScolaires = _anneeScolaireRepository.GetList().Select(a => new SelectListItem { Text = a.AnneeAcademique, Value = a.Id.ToString() }).ToList();
            model.ClasseDeBases = _classeDeBaseRepository.GetList().Select(c => new SelectListItem { Text = c.Nom, Value = c.Id.ToString() }).ToList();

            return View(model);
        }

        [Authorize(Roles = "Administrateur")]
        public ActionResult SupprimerClasse(int id)
        {
            var classe = _classeRepository.Get(id);
            if (classe == null)
            {
                return HttpNotFound();
            }

            var model = classe.ToViewModel();
            return View(model);
        }

        [Authorize(Roles = "Administrateur")]
        [HttpPost]
        public ActionResult SupprimerClasseConfirmation(int id)
        {
            try
            {
                _classeRepository.Delete(id);
                TempData["Message"] = "Classe supprimée avec succès!";
            }
            catch
            {
                TempData["MessageErreur"] = "Erreur inattendue!";
            }

            return RedirectToAction("Classes");
        }
        public ActionResult VueClasse(int id)
        {
            ClasseViewModel model = new ClasseViewModel();
            var classe = _classeRepository.Get(id);
            if (classe == null)
            {
                return HttpNotFound();
            }
            model = classe.ToViewModel();
            return View(model);
        }
        //Fin gestion des classes
    }
}