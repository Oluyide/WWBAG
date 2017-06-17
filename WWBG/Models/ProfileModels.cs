using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.core.Models;

namespace WWBG.Models
{
    public class ProfileModels
    {
        public List<ProfileModels> ProfileList { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Academic { get; set; }
        public string Faculty { get; set; }
        public string Sex { get; set; }
        public string DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }
        public List<SelectListItem> AcademicLevel { get; set; }
        public int AcademicId { get; set; }
        public string Class { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public int GenderId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        //  public Nullable<int> UserinfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public List<UserInfoModels> userInfoList { get; set; }

    }

    public  class UserPostTableModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Media { get; set; }
        public List<UserInfoModels> userInfoList { get; set; }
        public List<UserPostTableModel> userPostList { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}