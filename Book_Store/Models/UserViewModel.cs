using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class UserViewModel
    {
        public Login Login { get; set; }
        public Register Register { get; set; }
    }
    public class Register
    {
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
    }
    public class Login
    {
        [DisplayName("Email Address")]

        public string Email { get; set; }
        [DisplayName("Password")]

        public string Password { get; set; }
    }
}