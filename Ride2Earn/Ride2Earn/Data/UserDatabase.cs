using Ride2Earn.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ride2Earn.Data
{
    public class UserDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Gebruiker>();

        }

        public Gebruiker getUser()
        {
            lock (locker)
            {
                if(database.Table<Gebruiker>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Gebruiker>().First();
                }
            }
        }

        public int SaveUser(Gebruiker a)
        {
            lock(locker)
            {
                if (a.Nummer !=0)
                {
                    database.Update(a);
                    return a.Nummer;
                }
                else
                {
                    return database.Insert(a);
                }
            }
        }

        public int DeleteUser(int id)
        {
            lock(locker)
            {
                return database.Delete<Gebruiker>(id);
            }
        }
    }
}
