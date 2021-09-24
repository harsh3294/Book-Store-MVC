using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book_Store.Models
{
    public class User
    {
        [DisplayName("Id")]

        public int User_Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Contact Number")]
        public string MobileNumber { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Role")]
        public string Role_Id { get; set; }
    }
}