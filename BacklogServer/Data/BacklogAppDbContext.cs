using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BacklogServer.Data
{
    public class BacklogAppDbContext : DbContext
    {
        // these are set to test values for the time being
        private const string dbUser = "root";
        private const string dbPassword = "student"; // is there a more secure way for this
        private const string dbServer = "localhost";
        private const string dbName = "Backlogs";
        private const string _PATH = "Data/backlogs.db";
        // private DbSet<Backlog> _backlogs;
        // private DbSet<Backlog> _users; // temporary
        // public DbSet<Backlog> Backlogs 
        // {
        //     get => _backlogs; 
        //     set => _backlogs = value;
        // }
        // public DbSet<Backlog> Users 
        // {
        //     get => _users; 
        //     set => _users = value;
        // }

        public DbSet<Backlog> Backlogs {get; set;}
        public DbSet<BacklogItem> BacklogItems {get; set;}
        public BacklogAppDbContext(DbContextOptions<BacklogAppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Backlog>()
                .HasKey(b => new { b.UserId, b.BacklogId });
            modelBuilder.Entity<BacklogItem>()
                .HasKey(b => b.ItemId );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={_PATH}");
                // optionsBuilder.UseMySql($"Server={dbServer};Database={dbName};User={dbUser};Password={dbPassword};", new MySqlServerVersion(new Version(9, 6, 0)));    
            }
            
        }
    }
}