﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPSoft_SkedgeITModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ppsoftEntities : DbContext
    {
        public ppsoftEntities()
            : base("name=ppsoftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<access_level> access_level { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<shift> shifts { get; set; }
        public DbSet<department> departments { get; set; }
    }
}
