using System;
using System.Collections.Generic;

namespace web.core.Models
{
    public partial class UserProfile
    {
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
        public Nullable<int> UserinfoId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
