//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperFastBlogAPI.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_contact
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int PostID { get; set; }
        public string Message { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual tbl_article tbl_article { get; set; }
    }
}