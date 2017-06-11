using System;
using System.Collections.Generic;

namespace web.core.Models
{
    public partial class UserPostTable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Media { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
