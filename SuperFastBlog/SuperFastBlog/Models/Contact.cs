using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperFastBlog.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PostID { get; set; }
        public string Message { get; set; }
        public System.DateTime Date { get; set; }

    }
}