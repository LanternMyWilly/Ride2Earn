using Microsoft.EntityFrameworkCore;
using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite
{
    public class GebruikerRepository : IGebruikersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public GebruikerRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<Gebruiker>> GetGebruiker()
        {
            try
            {
                var gebruikers = await _databaseContext.Gebruikers.ToListAsync();
                return gebruikers;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Gebruiker> GetGebruikerByID(int id)
        {
            try
            {
                var gebruikers = await _databaseContext.Gebruikers.FindAsync(id);
                return gebruikers;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> AddGebruiker(Gebruiker a)
        {
            try
            {
                var gebruikers = await _databaseContext.Gebruikers.AddAsync(a);
                await _databaseContext.SaveChangesAsync();
                var isAdded = gebruikers.State == EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGebruiker(Gebruiker a)
        {
            try
            {
                var tracking =  _databaseContext.Update(a);
                await _databaseContext.SaveChangesAsync();
                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> RemoveGebruiker(int id)
        {
            try
            {
                var gebruiker = await _databaseContext.Gebruikers.FindAsync(id);
                var tracking = _databaseContext.Remove(gebruiker);
                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Modified;
                return isDeleted;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Gebruiker>> QueryGebruiker(Func<Gebruiker,bool> predicate)
        {
            try
            {
                var gebruikers = _databaseContext.Gebruikers.Where(predicate);
                return gebruikers.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
