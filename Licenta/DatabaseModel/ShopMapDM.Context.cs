﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopAppEntities : DbContext
    {
        public ShopAppEntities()
            : base("name=ShopAppEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Angajat> Angajat { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Furnizor> Furnizor { get; set; }
        public virtual DbSet<Livrare> Livrare { get; set; }
        public virtual DbSet<Magazin> Magazin { get; set; }
        public virtual DbSet<Produs> Produs { get; set; }
    }
}
