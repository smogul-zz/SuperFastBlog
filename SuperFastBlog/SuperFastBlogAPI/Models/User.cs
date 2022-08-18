using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperFastBlogAPI.Models
{
    /// <summary>
    /// roles enum
    /// </summary>
    public enum Roles
    {

        Admin = 1,
        Normal = 2,
        Customer = 3
    }

    /// <summary>
    /// user class
    /// </summary>
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}