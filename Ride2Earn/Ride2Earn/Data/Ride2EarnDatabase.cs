using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Klassen;
using SQLite;

namespace Ride2Earn.Data
{
    public class Ride2EarnDatabase
    {
        readonly SQLiteAsyncConnection database;

        public Ride2EarnDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Rit>().Wait();
        }

        public Task<List<Rit>> GetRitAsync()
        {
            return database.Table<Rit>().ToListAsync();
        }

        public Task<int> SaveRitAsync(Rit a)
        {
            if (a.ID != 0)
            {
                return database.UpdateAsync(a);
            }
            else { return database.InsertAsync(a); }
        }
    }
}
