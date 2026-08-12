using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BacklogServer.Models
{
    public class BacklogDbContext
    {
        // these are set to test values for the time being
        private const string dbUser = "root";
        private const string dbPassword = "student"; // is there a more secure way for this
        private const string dbServer = "localhost";
        private const string dbName = "Backlogs";

        private DbSet<Backlog> _backlogs;
        private DbSet<Backlog> _users; // temporary
        public DbSet<Backlog> Backlogs 
        {
            get => _backlogs; 
            set => _backlogs = value;
        }
        public DbSet<Backlog> Users 
        {
            get => _users; 
            set => _users = value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"Server={dbServer};Database={dbName};User={dbUser};Password={dbPassword};", new MySqlServerVersion(9, 6, 0));
        }
    }
}