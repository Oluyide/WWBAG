using System;
using System.Collections.Generic;

namespace web.core.Models
{
    public partial class ContactTable
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string Message { get; set; }
    }
}
