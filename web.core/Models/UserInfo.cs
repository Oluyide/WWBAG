using System;
using System.Collections.Generic;

namespace web.core.Models
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string AcademicLevel { get; set; }
        public string Faculty { get; set; }
        public string Class { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> DateBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string UserId { get; set; }
    }
}
