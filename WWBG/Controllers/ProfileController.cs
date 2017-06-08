using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Profile()
        {
            ProfileModels model = new ProfileModels();
            var list = ListProfile();
            var list2 = ListUserInfo();
            model.ProfileList = list;
            model.userInfo = list2;
           
            ViewBag.info = list2.Single();
            return View(model);
        }


        [HttpPost]

        public ActionResult Profile(ProfileModels model)
        {
         
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
                profile.Picture = model.Picture;
                profile.Sex = model.Sex;
                profile.State = model.State;
            

                repo.Add(profile);

                try
                {
                    repo.SaveChanges();
                    TempData["Success"] = "Saved!";

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

            List<UserProfile> ProfileList = repo.GetAll().OrderBy(x=>x.Id).ToList();

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
    }


}