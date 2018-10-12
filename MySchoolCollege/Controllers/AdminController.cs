using Microsoft.AspNet.Identity;
//using MySchoolCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using System.Web.WebPages.Html;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
//using MySchoolCollege.Models.ModelViews;
using System.Data.Entity;
//using MySchoolCollege.Models.Utilitys;
using MySchoolLibrary2018.Models;
using MySchoolLibrary2018.Models.ModelViews;
using PagedList;
using MySchoolCollege.Properties;

namespace MySchoolCollege.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        
       
       

        //GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        

        //GET: Liste des roles
        public ActionResult Roles(int? page)
        {

            List<RoleListViewModel> model = new List<RoleListViewModel>();
            try
            {
                model = RoleManager.Roles.Select(r => new RoleListViewModel
                {
                    Id = r.Id,
                    Description = r.Description,
                    RoleName = r.Name,
                    TotalUtilisateurs = r.Users.Count
                }
                                                ).ToList();

            }
            catch (Exception e)
            {
                //ViewBag.Message = "Aucun enregistrement retouné!";
                ViewBag.Message = e.Message;
            }
            var pageNumber = page ?? 1;

            return View(model.ToPagedList(pageNumber, int.Parse(Resources.NombreLigneParPage)));
        }

        //GET: Détails role
        public ActionResult DetailsRole(string id, string utilisateurId, Boolean? sup)
        {
            RoleViewModel model = new RoleViewModel();
            ApplicationRole role = RoleManager.FindById(id);

            if (role != null)
            {
                model.Id = role.Id;
                model.RoleName = role.Name;
                model.Description = role.Description;
                model.DateCreation = role.DateCreation;
                model.DateModification = role.DateModification;
               
            }
            else
            {
                return HttpNotFound();
            }

            //Enlever un utilisateur du groupe 
            if (sup == true)
            {

                IdentityResult supResult = UserManager.RemoveFromRoles(utilisateurId, model.RoleName);
                if (supResult.Succeeded)
                {
                    model.Users = role.Users.Select(u => UserManager.FindById(u.UserId)).ToList();
                    ViewBag.MessageSucces = "Utilisateur enlevé du groupe avec succés";
                    ViewBag.MessageClass = "success";
                }
            }
            model.Users = role.Users.Select(u => UserManager.FindById(u.UserId)).ToList();
            var userAEnlever = model.Users.Select(x => x.Id).ToArray();
            model.Utilisateurs = UserManager.Users.Where(x => !userAEnlever.Contains(x.Id)).Select(s => new SelectListItem { Value = s.Id, Text = s.Prenom + " " + s.Nom }).ToList();

            return View(model);
        }
        //GET: Ajouter un utilisateur à un groupe
        [HttpPost]
        public ActionResult DetailsRole(string id, string utilisateurId)
        {
            ApplicationRole role = RoleManager.FindById(id);
            RoleViewModel model = new RoleViewModel();
            
            if (role != null)
            {
                model.Id = role.Id;
                model.Description = role.Description;
                model.DateCreation = role.DateCreation;
                model.DateModification = role.DateModification;
                model.RoleName = role.Name;
               
                //Ajouter un utilisateur dans le groupe               
                if (!string.IsNullOrEmpty(utilisateurId))
                {
                    IdentityResult roleResult = UserManager.AddToRole(utilisateurId, role.Name);
                    if (roleResult.Succeeded)
                    {
                        model.Users = role.Users.Select(u => UserManager.FindById(u.UserId)).ToList();
                        TempData["Message"] = "Utilisateur ajouté avec succés";
                        
                    }
                    else
                    {
                        TempData["MessageErreur"] = "Utilisateur déja dans le groupe";
                        
                    }
                }
                model.Users = role.Users.Select(u => UserManager.FindById(u.UserId)).ToList();
                var userAEnlever = model.Users.Select(x => x.Id).ToArray();
                model.Utilisateurs = UserManager.Users.Where(x => !userAEnlever.Contains(x.Id)).Select(s => new SelectListItem { Text = s.Prenom + " " + s.Nom, Value = s.Id }).ToList();


            }


            return View(model);
        }
        //GET: Ajouter un role
        [HttpGet]
        public ActionResult AjouterRole()
        {
            var roleViewModel = new RoleViewModel();
            return View(roleViewModel);
        }


        //POST: Ajouter un role
        [HttpPost]
        public ActionResult AjouterRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole();
                role.Id = roleViewModel.Id;
                role.Description = roleViewModel.Description;
                role.DateCreation = DateTime.Now;
                role.DateModification = DateTime.Now;
                role.Name = roleViewModel.RoleName;
                try
                {
                    IdentityResult roleResult = RoleManager.Create(role);
                    if (roleResult.Succeeded)
                    {
                        TempData["Message"] = "Role ajouté avec succès";
                        return RedirectToAction("Roles");
                    }
                }
                catch (Exception e)
                {
                    //ViewBag.MessageError = e.Message;
                    ViewBag.MessageError = "Une erreur est survenue. vérifier les données saisies";
                }

            }
            return View(roleViewModel);
        }

        //GET: Modifier un role
        [HttpGet]
        public ActionResult ModifierRole(string id)
        {
            RoleViewModel model = new RoleViewModel();
            ApplicationRole role = RoleManager.FindById(id);
            if (role != null)
            {
                model.Id = role.Id;
                model.RoleName = role.Name;
                model.Description = role.Description;

            }
            else
            {
                return HttpNotFound();

            }
            return View(model);
        }

        //POST: Modifier un role
        [HttpPost]
        public ActionResult ModifierRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = RoleManager.FindById(model.Id);
                if (role != null)
                {
                    role.Name = model.RoleName;
                    role.Description = model.Description;
                    role.DateModification = DateTime.Now;
                    IdentityResult roleResult = RoleManager.Update(role);
                    if (roleResult.Succeeded)
                    {
                        TempData["Message"] = "Role modifier avec succès";
                        return RedirectToAction("Roles");
                    }
                }
            }
            return View(model);
        }


        //GET: Supprimer un role
        [HttpGet]
        public ActionResult SupprimerRole(string id)
        {
            RoleViewModel model = new RoleViewModel();
            ApplicationRole role = RoleManager.FindById(id);
            if (role != null)
            {
                model.Id = role.Id;
                model.RoleName = role.Name;
                model.Description = role.Description;
                model.Users = role.Users.Select(u => UserManager.FindById(u.UserId)).ToList();
                

            }
            else
            {
                return HttpNotFound();

            }
            return View(model);
        }


        //POST: Supprimer un role
        [HttpPost]
        public ActionResult SupprimerRole(RoleViewModel model)
        {
            if (model != null)
            {
                ApplicationRole role = RoleManager.FindById(model.Id);
                var compteur = role.Users.Count;
                var message = "";
                var UsersId = role.Users.Select(u => u.UserId);
                while (role.Users.Count != 0)
                {
                    role.Users.Clear();
                   
                }
                
                if(compteur != 0)
                {
                    message = compteur + " utilisateurs retirés et ";
                }
                IdentityResult roleResult = RoleManager.Delete(role);
                if (roleResult.Succeeded)
                {
                    TempData["Message"] = message + "le groupe (role) a été supprimé avec succès";
                    return RedirectToAction("Roles");
                }
            }
            return View(model);
        }

        //GET: liste des utilisateurs
        public ActionResult ListeUtilisateurs(int? page)
        {


            List<UtilisateurListViewModel> model = UserManager.Users.Select(u => new UtilisateurListViewModel
            {
                Id = u.Id,
                Civillite = u.Civillite,
                Prenom = u.Prenom,
                Nom = u.Nom,
                DateNaissance = u.DateNaissance,
                Email = u.Email,
                Fonction = u.Fonction,
                Nationalite = u.Nationalite,
                LieuDeNaissance = u.LieuDeNaissance,
                Parent = u.Parent,
                Adresse = u.Adresse,
                Ville = u.Ville,
                Pays = u.Pays


            }
             ).ToList();
            var pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber, int.Parse(Resources.NombreLigneParPage)));
        }

        //GET: Ajouter un  utilisateur
        public ActionResult AjouterUtilisateur()
        {
            UtilisateurViewModel model = new UtilisateurViewModel();

            model.ApplicationRoles = RoleManager.Roles.Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            model.Fonctions = Db.Fonctions.Select(s => new SelectListItem { Text = s.Id, Value = s.Id }).ToList();
            //On cherche l'id du groupe avec description "parent"
            var RoleParent = RoleManager.FindByName("Parents");
            string roleId = "";
            if (RoleParent != null)
            {
                roleId = RoleParent.Id;
            }
            model.Parents = UserManager.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId)).Select(s => new SelectListItem { Text = s.Prenom + " " + s.Nom, Value = s.Id }).ToList();

            //initiatlier la date de naissance avec la date du jour
            model.DateNaissance = DateTime.Now.Date;
            return View(model);
        }

        //POST: Ajouter un utilisateur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AjouterUtilisateur(UtilisateurViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = new IdentityResult();
                var user = new ApplicationUser
                {
                    Matricule = model.Matricule,
                    Civillite = model.Civillite,
                    UserName = model.Email,
                    Email = model.Email,
                    Prenom = model.Prenom,
                    Nom = model.Nom,
                    DateNaissance = model.DateNaissance,
                    LieuDeNaissance = model.LieuDeNaissance,
                    Nationalite = model.Nationalite,
                    Adresse = model.Adresse,
                    Ville = model.Ville,
                    Pays = model.Pays,
                    PhoneNumber = model.Telephone,
                    CodePostal = model.CodePostal

                };

                


                //Parent
                var part = UserManager.FindById(model.ParentId);
                try
                {
                    ApplicationUser parent = part;
                    user.Parent = parent;
                }
                catch
                {

                }


                ApplicationRole role = await RoleManager.FindByIdAsync(model.ApplicationRoleId);
                if (role != null)
                {
                    result = await UserManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                        //Ajouter l'utilisateur dans le groupe 
                        IdentityResult roleResult = await UserManager.AddToRoleAsync(user.Id, role.Name);
                        if (!roleResult.Succeeded)
                        {
                            ViewBag.MessageError = "Impossible d'ajouter l'utilisateur au groupe";
                        }
                        //fonction de l'utilisateur
                        var fonct = from f in Db.Fonctions where f.Id == model.FonctionId select f;
                        try
                        {
                            Fonction fonction = fonct.First();
                            var userEncours = Db.Users.Find(user.Id);
                            userEncours.Fonction = fonction;
                            Db.SaveChanges();
                            
                        }
                        catch
                        {
                          
                        }
                        TempData["Message"] = "Utilisateur ajouté avec succès";
                        return RedirectToAction("Listeutilisateurs", "Admin");
                    }


                    // Pour plus d'informations sur l'activation de la confirmation de compte et de la réinitialisation de mot de passe, visitez https://go.microsoft.com/fwlink/?LinkID=320771
                    // Envoyer un message électronique avec ce lien
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");




                }



            }

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            model.ApplicationRoles = RoleManager.Roles.Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            model.Fonctions = Db.Fonctions.Select(s => new SelectListItem { Text = s.Id, Value = s.Id }).ToList();
            //On cherche l'id du groupe avec description "parent"
            var RoleParent = RoleManager.FindByName("Parents");
            string roleId = "";
            if (RoleParent != null)
            {
                roleId = RoleParent.Id;
            }
            model.Parents = UserManager.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId)).Select(s => new SelectListItem { Text = s.Prenom + " " + s.Nom, Value = s.Id }).ToList();

            return View(model);
        }

        //TODO GET: Modifier un  utilisateur
        public ActionResult ModifierUtilisateur(string id)
        {
            var user = UserManager.Users.Where(u => u.Id == id)
                .Include(u => u.Fonction)
                .Include(u => u.Parent)
                .FirstOrDefault();

            //Explicit loading for parent and fonction

            UtilisateurViewUpDateModel model = new UtilisateurViewUpDateModel();
            if (user != null)
            {
                model.Id = user.Id;
                model.Matricule = user.Matricule;
                model.Prenom = user.Prenom;
                model.Nom = user.Nom;
                model.LieuDeNaissance = user.LieuDeNaissance;
                model.DateNaissance = user.DateNaissance;
                model.Civillite = user.Civillite;
                model.Adresse = user.Adresse;
                try
                {
                    model.FonctionId = user.Fonction.Id;
                    
                }
                catch
                {

                }
                try
                {
                    model.ParentId = user.Parent.Id;
                }
                catch
                {

                }
                model.CodePostal = user.CodePostal;
                model.Nationalite = user.Nationalite;

                model.Pays = user.Pays;
                model.Ville = user.Ville;
                model.Telephone = user.PhoneNumber;
                model.CodePostal = user.CodePostal;


            }
            else
            {
                return HttpNotFound();
            }

            //Alimentation de la liste déroulante foncton
            model.Fonctions = Db.Fonctions.Select(s => new SelectListItem { Text = s.Id, Value = s.Id }).ToList();
            //On cherche l'id du groupe avec description "parent"
            var RoleParent = RoleManager.FindByName("Parents");
            string roleId = "";
            if (RoleParent != null)
            {
                roleId = RoleParent.Id;
            }
            //Alimentation de la liste déroulante Parents
            model.Parents = UserManager.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId)).Select(s => new SelectListItem { Text = s.Prenom + " " + s.Nom, Value = s.Id }).ToList();

            return View(model);
        }

        //TODO POST: Modifier un utilisateur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ModifierUtilisateur(UtilisateurViewUpDateModel model)
        {
            if (ModelState.IsValid)
            {

                var result = new IdentityResult();
                //var user = await UserManager.FindByIdAsync(model.Id);
                var user = await Db.Users.Where(u => u.Id == model.Id).FirstOrDefaultAsync();
                user.Matricule = model.Matricule;
                user.Civillite = model.Civillite;
                //user.UserName = model.Email;
                //user.Email = model.Email;
                user.Prenom = model.Prenom;
                user.Nom = model.Nom;
                user.DateNaissance = model.DateNaissance;
                user.LieuDeNaissance = model.LieuDeNaissance;
                user.Nationalite = model.Nationalite;
                user.Adresse = model.Adresse;
                user.Ville = model.Ville;
                user.Pays = model.Pays;
                user.CodePostal = model.CodePostal;
                user.PhoneNumber = model.Telephone;
                //fonction de l'utilisateur
                var fonct = from f in Db.Fonctions where f.Id == model.FonctionId select f;
                try
                {
                    Fonction fonction = fonct.First();
                    user.Fonction = Db.Fonctions.Find(model.FonctionId);
                   
                }
                catch
                {

                }


                //Parent
                var parentIdtemp = model.ParentId;
                //var part = await UserManager.FindByIdAsync(parentIdtemp);
                var part = Db.Users.Find(parentIdtemp);
                try
                {
                    ApplicationUser parent = part;
                    user.Parent = part;
                }
                catch
                {

                }


                //result = await UserManager.UpdateAsync(user);
                Db.Entry(user).State = EntityState.Modified;
                var saveChanges = Db.SaveChanges();
                if (saveChanges >= 1)
                {
                    TempData["Message"] = "Utilisateur modifier avec succès";
                    return RedirectToAction("listeUtilisateurs");
                }


            }

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            //model.ApplicationRoles = RoleManager.Roles.Select(s => new SelectListItem { Text = s.Description, Value = s.Id }).ToList();
            model.Fonctions = Db.Fonctions.Select(s => new SelectListItem { Text = s.Id, Value = s.Id }).ToList();
            //On cherche l'id du groupe avec description "parent"
            var RoleParent = RoleManager.FindByName("Parents");
            string roleId = "";
            if (RoleParent != null)
            {
                roleId = RoleParent.Id;
            }
            model.Parents = UserManager.Users.Where(u => u.Roles.Any(r => r.RoleId == roleId)).Select(s => new SelectListItem { Text = s.Prenom + " " + s.Nom, Value = s.Id }).ToList();

            return View(model);
        }
        
        public async Task<ActionResult> DetailsUtilisateur(string id)
        {
            var user = await Db.Users
                                .Where( u => u.Id == id)
                                .Include( f => f.Fonction)
                                .Include( p => p.Parent)
                                .FirstOrDefaultAsync();
            UtilisateurViewModel model = new UtilisateurViewModel();
            if (user != null)
            {
                model.Id = user.Id;
                model.Matricule = user.Matricule;
                model.Prenom = user.Prenom;
                model.Nom = user.Nom;
                model.LieuDeNaissance = user.LieuDeNaissance;
                model.DateNaissance = user.DateNaissance;
                model.Civillite = user.Civillite;
                model.Adresse = user.Adresse;
                try
                {
                    model.FonctionId = user.Fonction.Id;

                }
                catch
                {

                }
                try
                {
                    model.ParentId = user.Parent.Id;
                }
                catch
                {

                }
                model.CodePostal = user.CodePostal;
                model.Nationalite = user.Nationalite;

                model.Pays = user.Pays;
                model.Ville = user.Ville;
                model.Telephone = user.PhoneNumber;
                model.CodePostal = user.CodePostal;
                model.Roles = user.Roles.Select(r => RoleManager.FindById(r.RoleId)).ToList();


            }

            return View(model);
        }

        //TODO GET: Supprimer un  utilisateur

        //TODO POST: Supprimer un utilisateur

        //
        // GET: /Account/ResetPassword
        public ActionResult ResetPassword()
        {
            string code = UserManager.GeneratePasswordResetToken(User.Identity.GetUserId());
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            model.Email = User.Identity.GetUserName();
            model.Code = code;
            return code == null ? View("Error") : View(model);
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Ne révélez pas que l'utilisateur n'existe pas
                return RedirectToAction("ResetPasswordConfirmation", "Admin");
            }
            //Vérification du mot de passe actuelle
            var passwordCorrect = await UserManager.CheckPasswordAsync(user, model.OldPassword);
            if (!passwordCorrect)
            {
                ModelState.AddModelError("", "L'ancien mot de passe n'est pas valide!");
                return View(model);
            }
            else
            {
                var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.OldPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation", "Admin");
                }

                AddErrors(result);
            }
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}