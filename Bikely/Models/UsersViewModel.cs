using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bikely.Models
{
    public class UsersViewModel
    {
        public string userId { get; set; }
        public string roleName { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public bool phoneNumConfirmed { get; set; }
        public bool showHiddenLinks { get; set; } 
        //this makes admin hides something - ? admin hides : owner or renter hides
    }
}