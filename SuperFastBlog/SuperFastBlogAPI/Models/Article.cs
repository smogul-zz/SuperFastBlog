using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperFastBlogAPI.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Topic { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public int PostedUserID { get; set; }
        public System.DateTime DatePosted { get; set; }
    }
}