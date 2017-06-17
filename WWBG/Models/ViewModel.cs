using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WWBG.Models
{
    [MetadataType(typeof(UserProf))]
    public partial class UserDa
    {
        internal class UserProf
        {
            [Key]
            public int UserId { get; set; }
            public string UserName { get; set; }
        }
    }
}