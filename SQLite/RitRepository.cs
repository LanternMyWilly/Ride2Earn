using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ride2Earn.Data;
using Ride2Earn.Klassen;

namespace SQLite
{
    public class RitRepository : IRitRepository
    {
        private readonly DatabaseContext _databaseContent;

        public RitRepository(string dbPath)
        {
            _databaseContent = new DatabaseContext(dbPath);
        }

        public async Task<bool> AddRit(Rit a)
        {
            try
            {
                var ritten = await _databaseContent.Ritten.AddAsync(a);
                await _databaseContent.SaveChangesAsync();
                var isAdded = ritten.State == EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            { return false; }
        }
    }
}
