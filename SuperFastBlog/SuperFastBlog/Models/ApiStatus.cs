using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperFastBlog.Models
{

    public enum Status
    {
        Complete = 1,
        Error = 2,
        NoResult = 3,
        Unknown = 4
    }

    public class ApiStatus
    {
        public int Code { get; set; } 
        public string Message { get; set; }
    }
}