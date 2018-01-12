using System;
using Microsoft.EntityFrameworkCore;
using Ride2Earn.Klassen;

namespace SQLite
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Rit> Ritten { get; set; }

        private readonly string _databasePath;

        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
            SQLitePCL.Batteries.Init();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
