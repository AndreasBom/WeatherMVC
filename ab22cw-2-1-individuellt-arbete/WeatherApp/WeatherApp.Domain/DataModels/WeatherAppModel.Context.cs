﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WeatherAppEntities : DbContext
    {
        public WeatherAppEntities()
            : base("name=WeatherAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Forcast> Forcasts { get; set; }
        public virtual DbSet<GeoLocation> GeoLocations { get; set; }
    }
}