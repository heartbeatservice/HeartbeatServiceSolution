﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HBS.Data.Entities.SchedulingTimeTracking.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchTimeTrackingEntities : DbContext
    {
        public SchTimeTrackingEntities()
            : base("name=SchTimeTrackingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserTimeTrackHistory> UserTimeTrackHistories { get; set; }
    }
}
