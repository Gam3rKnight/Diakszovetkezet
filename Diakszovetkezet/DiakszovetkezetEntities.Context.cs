﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diakszovetkezet
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DiakszovetkezetEF : DbContext
    {
        public DiakszovetkezetEF()
            : base("name=DiakszovetkezetEF")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<StudentTime> StudentTime { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Work> Work { get; set; }
    }
}