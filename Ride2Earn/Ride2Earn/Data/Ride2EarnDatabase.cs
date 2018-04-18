using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Helpers;
using Ride2Earn.Klassen;
using Ride2Earn.Models;
using SQLite;
using Xamarin.Forms;

namespace Ride2Earn.Data
{
    public class Ride2EarnDatabase
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Gebruiker> Gebruikers { get; set; }
        public ObservableCollection<Rit> Ritten { get; set; }
        public Ride2EarnDatabase()
        {
            database = DependencyService.Get<IFileHelper>().DbConnection();
            database.CreateTable<Gebruiker>();
            database.CreateTable<Rit>();
            this.Gebruikers = new ObservableCollection<Gebruiker>(database.Table<Gebruiker>());
            this.Ritten = new ObservableCollection<Rit>(database.Table<Rit>());
        }

        public IEnumerable<Gebruiker> GetWW()
        {
            lock(collisionLock)
            {
                return database.Query<Gebruiker>("SELECT Wachtwoord FROM Gebruikers where ID = 1").AsEnumerable();
            }
        }

        public IEnumerable<Gebruiker> GetGebruiker()
        {
            lock (collisionLock)
            {
                return database.Query<Gebruiker>("SELECT * FROM Gebruikers where ID = 1").AsEnumerable();
            }
        }

        public int SaveGebruikerAsync(Gebruiker a)
        {
            lock(collisionLock)
            {
                if (a.ID !=0)
                {
                    database.Update(a);
                    return a.ID;
                }
                else
                {
                    database.Insert(a);
                    return a.ID;
                }
            }
        }

        public int SaveRit(Rit a)
        {
            lock(collisionLock)
            {
                if (a.ID != 0)
                {
                    database.Update(a);
                    return a.ID;
                }
                else
                {
                    database.Insert(a);
                    return a.ID;
                }
            }
        }

       

        /*readonly SQLiteAsyncConnection database;

        public Ride2EarnDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Rit>();
            database.CreateTableAsync<Gebruiker>();
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

        public Task<int> SaveGebruikerAsync(Gebruiker a)
        {
            if (a.ID != 0)
            {
                return database.UpdateAsync(a);
            }
            else { return database.InsertAsync(a); }
        }
        
        public Task<List<Gebruiker>> GetGebruikerAsync()
        {
            return database.Table<Gebruiker>().ToListAsync();
        }

        public Task<int> EditGebruiker(Gebruiker a)
        {
            return database.UpdateAsync(a);
        }

        public IEnumerable<Gebruiker> test()
        {
            var query = from t in database.Table<Gebruiker>() where t.ID == 0 select t;
            return query.AsEnumerable();
        }*/
    }
}
