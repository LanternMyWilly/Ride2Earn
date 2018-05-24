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

        /*public int SaveStartAdres(StartAdres a)
        {
            lock (collisionLock)
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

        public int SaveEindAdres(EindAdres a)
        {
            lock (collisionLock)
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
        }*/

        public IEnumerable<Gebruiker> GetWW()
        {
            lock(collisionLock)
            {
                return database.Query<Gebruiker>("SELECT Wachtwoord FROM Gebruikers where ID = 1").AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetAantalKM()
        {
            lock (collisionLock)
            {
                return database.Query<Rit>("SELECT sum(Gereden) as Gereden FROM ritten").AsEnumerable();
            }
        }

        public IEnumerable<Gebruiker> GetGebruiker()
        {
            lock (collisionLock)
            {
                return database.Query<Gebruiker>("SELECT * FROM Gebruikers where ID = 1").AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetStartAdressen()
        {
            lock(collisionLock)
            {
                return database.Query<Rit>("SELECT Start FROM Ritten").AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetEindAdressen()
        {
            lock (collisionLock)
            {
                return database.Query<Rit>("SELECT Einde FROM Ritten").AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetRitten()
        {
            lock (collisionLock)
            {
                return database.Query<Rit>("SELECT * FROM Ritten").AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetDatum(int id)
        {
            
            lock (collisionLock)
            {
                id += 1;
                return database.Query<Rit>("SELECT Datum FROM Ritten where ID = ?", id).AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetStart(int id)
        {
            lock (collisionLock)
            {
                id += 1;
                return database.Query<Rit>("SELECT Start FROM Ritten where ID = ?", id).AsEnumerable();
            }
        }
        public IEnumerable<Rit> GetEinde(int id)
        {
            lock (collisionLock)
            {
                id += 1;
                return database.Query<Rit>("SELECT Einde FROM Ritten where ID = ?", id).AsEnumerable();
            }
        }

        public IEnumerable<Rit> GetGereden(int id)
        {
            lock (collisionLock)
            {
                id += 1;
                return database.Query<Rit>("SELECT Gereden FROM Ritten where ID = ?", id).AsEnumerable();
            }
        }

        public IEnumerable<Rit> CleanTable()
        {
            lock (collisionLock)
            {
                return database.Query<Rit>("delete from Ritten").AsEnumerable();
            }
        }

        public void droptable()
        {
            lock(collisionLock)
            {
                database.DropTable<Rit>();
            }
            
        }

        public void createtable()
        {
            lock(collisionLock)
            {
                database.CreateTable<Rit>();
            }
            
        }

        public IEnumerable<Rit> DropID()
        {
            lock (collisionLock)
            {
                return database.Query<Rit>("DBCC CHECKIDENT('Ritten', RESEED, 0)").AsEnumerable();
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
            lock (collisionLock)
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
    }
}
