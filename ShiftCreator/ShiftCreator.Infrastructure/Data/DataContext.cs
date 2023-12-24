using Microsoft.EntityFrameworkCore;
using ShiftCreator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Infrastructure.Data
{
    internal class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ShiftCreator;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Team)
                .WithMany(t => t.People)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.People)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.TeamLeader)
                .WithMany()
                .HasForeignKey(t => t.TeamLeaderId);
        }


        public DbSet<Person> Person { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Team> Team { get; set; }


        
    }
}
