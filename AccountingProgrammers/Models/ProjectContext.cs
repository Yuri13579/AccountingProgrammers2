using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingProgrammers.Interfaces;
using AccountingProgrammers.Models;
using AccountingProgrammers.Repository;

namespace AccountingProgrammers.Models
{
    public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<ProjectDeveloper> ProjectDevelopers { get; set; }
        
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<ProjectDeveloper>()
                .HasKey(p => new {p.ProjectId, p.DeveloperId});
            
        }

        public DbSet<AccountingProgrammers.Models.ProjectDeveloper> ProjectDeveloper { get; set; }

        
    }
}
