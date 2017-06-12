using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.core.Models;
using web.core.Repository;
using WWBG.Models;

namespace WWBG.Controllers
{
   // [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Profile()
        {

            List<SelectListItem> Academics = new List<SelectListItem>();
            Academics.Add(new SelectListItem
            {
                Text = "Primary",
                Value = "1"
            });
            Academics.Add(new SelectListItem
            {
                Text = "Secondary",
                Value = "2",
                Selected = true
            });
            Academics.Add(new SelectListItem
            {
                Text = "Tertiary",
                Value = "3"
            });

            List<SelectListItem> gender = new List<SelectListItem>();
            gender.Add(new SelectListItem
            {
                Text = "Male",
                Value = "1"
            });
            gender.Add(new SelectListItem
            {
                Text = "Female",
                Value = "2",
                Selected = true
            });


            ViewBag.AcademicLevel = new SelectList(Academics, "Value", "Text");
            ViewBag.gender = new SelectList(gender, "Value", "Text");

            ProfileModels model = new ProfileModels();
            var list = ListProfile();
            var list2 = ListUserInfo();
            model.ProfileList = list;
            model.userInfoList = list2;
            ViewBag.profile = list.SingleOrDefault();
            ViewBag.info = list2.SingleOrDefault();
            return View(model);
        }


        [HttpPost]

        public ActionResult Profile(ProfileModels model, HttpPostedFileBase uploadedPassport)
        {
            var validImageTypes = new string[]
               {
            "image/gif",
            "image/jpeg",
            "image/pjpeg",
            "image/png",
                };
            if (ModelState.IsValid)
            {
                SqlRepository<UserProfile> repo = new SqlRepository<UserProfile>();
                UserProfile profile = new UserProfile();
                

                profile.Academic = model.Academic;
                profile.Country = model.Country;
                profile.DateBirth = model.DateBirth;
                profile.Email = model.Email;
                profile.Faculty = model.Faculty;
                profile.Id = model.Id;
                profile.PhoneNumber = model.PhoneNumber;
               
                profile.UserId = User.Identity.GetUserId();
                profile.Date = DateTime.Today;
                profile.Sex = model.Sex;
                profile.State = model.State;
                if (uploadedPassport != null)
                {
                    if (!validImageTypes.Contains(uploadedPassport.ContentType))
                    {
                        ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                        TempData["Picture"] = "You need to upload either a GIF, JPG, or PNG image.";
                        return RedirectToAction("Edit");

                    }
                    else
                    {
                        string filename = System.IO.Path.GetFileName(uploadedPassport.FileName);
                        string filename1 = User.Identity.Name.ToString() +"_"+ filename;
                        string physicalPath = Server.MapPath("~/Images/ProfilePic/" + filename1);
                        uploadedPassport.SaveAs(physicalPath);

                        profile.Picture = filename1;

                    }

                }

                repo.Add(profile);

                try
                {
                    repo.SaveChanges();
                    TempData["Success"] = "Profile updated!";

                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }

                return RedirectToAction("Profile");

            }
            else
            {

                ModelState.AddModelError("", "Fill necessary fields");

            }
            return View(model);

        }


        public List<ProfileModels> ListProfile()
        {

            SqlRepository<UserProfile> repo = new SqlRepository<UserProfile>();


            List<ProfileModels> listProfile = new List<ProfileModels>();
            string userid = User.Identity.GetUserId();
            List<UserProfile> ProfileList = repo.GetAll().Where(x => x.UserId == userid).OrderBy(x => x.Id).ToList();

            foreach (var a in ProfileList)
            {
                ProfileModels model = new ProfileModels();
                model.Academic = a.Academic;
                model.Country = a.Country;
                model.DateBirth = a.DateBirth;
                model.Email = a.Email;
                model.Faculty = a.Faculty;
                model.Id = a.Id;
                model.PhoneNumber = a.PhoneNumber;
                model.Picture = a.Picture;
                model.Sex = a.Sex;
                model.State = a.State;
                model.Date = a.Date;


                listProfile.Add(model);

            }
            return listProfile;
        }
        public List<UserInfoModels> ListUserInfo()
        {

            SqlRepository<UserInfo> repo = new SqlRepository<UserInfo>();
            string userid = User.Identity.GetUserId();

            List <UserInfoModels> listuser = new List<UserInfoModels>();

            List<UserInfo> userList = repo.GetAll().Where( x=>x.UserId == userid).OrderBy(x => x.Id).ToList();

            foreach (var a in userList)
            {
                UserInfoModels model = new UserInfoModels();
                model.FirstName = a.FirstName;
                model.IsActive = a.IsActive;
                model.LastName = a.LastName;
                model.Id = a.Id;
                model.Date = a.Date;
                             
                listuser.Add(model);

            }
            return listuser;
        }

        public ActionResult Post (UserPostTableModel model, HttpPostedFileBase uploadedPassport)
        {
           
       
      var validImageTypes = new string[]
                   {
            "image/gif",
            "image/jpeg",
            "image/pjpeg",
            "image/png",
                    };
                if (ModelState.IsValid)
                {
                    SqlRepository<UserPostTable> repo = new SqlRepository<UserPostTable>();
                    UserPostTable post = new UserPostTable();


                    post.Id = model.Id;
                    post.Text = model.Text;
                   
                    post.UserId = User.Identity.GetUserId();
                    post.Date = DateTime.Today;
                   
                    if (uploadedPassport != null)
                    {
                        if (!validImageTypes.Contains(uploadedPassport.ContentType))
                        {
                            ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                            TempData["Picture"] = "You need to upload either a GIF, JPG, or PNG image.";
                            return RedirectToAction("Edit");

                        }
                        else
                        {
                            string filename = System.IO.Path.GetFileName(uploadedPassport.FileName);
                            string filename1 = User.Identity.Name.ToString() + "_" + filename;
                            string physicalPath = Server.MapPath("~/Images/ProfilePic/" + filename1);
                            uploadedPassport.SaveAs(physicalPath);

                            post.Media = filename1;

                        }

                    }

                    repo.Add(post);

                    try
                    {
                        repo.SaveChanges();
                        TempData["Success"] = "Post uploaded!";

                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Trace.TraceInformation("Property: {0} Error: {1}",
                                                        validationError.PropertyName,
                                                        validationError.ErrorMessage);
                            }
                        }
                    }

                    return RedirectToAction("Post");

                }
                else
                {

                    ModelState.AddModelError("", "Fill necessary fields");

                }
                return View(model);

            }

        
        public ActionResult Event()
        {
            return View();
        }
        public ActionResult Ads()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        public class Chat : Hub
        {
            public void EnviarMensagem(string apelido, string mensagem)
            {
                Clients.Caller(apelido, mensagem);
            }
        }
        // GET: /ChatRoom/  
        public ActionResult SignalRChat()
        {
            return View();
        }

    }


}