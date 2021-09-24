using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Book_Store.Models
{
    public class Location
    {
        [DisplayName("Id")]

        public int Location_Id { get; set; }
        [DisplayName("Location Name")]

        public string Location_Name { get; set; }
    }
}