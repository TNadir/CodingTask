using CodingSolution.Data.Domen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodingSolution.Data.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DbConn")
        {

        }

        public DbSet<Sectors> Sectors { get; set; }

        public DbSet<Candidates> Candidates { get; set; }

        public DbSet<Applicants> Applicants { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Applicants>()
                .HasKey(c => new { c.CandidateId, c.SectorId });

            modelBuilder.Entity<Sectors>()
                .HasMany(c => c.Applicants)
                .WithRequired()
                .HasForeignKey(c => c.SectorId);

            modelBuilder.Entity<Candidates>()
                .HasMany(c => c.Applicants)
                .WithRequired()
                .HasForeignKey(c => c.CandidateId);

        }


    }
}