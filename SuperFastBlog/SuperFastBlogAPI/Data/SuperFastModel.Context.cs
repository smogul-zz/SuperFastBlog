﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SuperFastEntities : DbContext
    {
        public SuperFastEntities()
            : base("name=SuperFastEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbl_article> tbl_article { get; set; }
        public DbSet<tbl_contact> tbl_contact { get; set; }
        public DbSet<tbl_user> tbl_user { get; set; }
    }
}
