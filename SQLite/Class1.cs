using Microsoft.EntityFrameworkCore;
using Ride2Earn.Models;
using System;

namespace SQLite
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Rit> Ritten { get; set; }

        private readonly string _databasePath;
        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
