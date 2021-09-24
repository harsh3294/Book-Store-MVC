using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models
{
    public class Role
    {
        [DisplayName("Id")]

        public int Role1 { get; set; }
        [DisplayName("Role Name")]

        public string Role_Name { get; set; }
    }
}