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
    public class TokenDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        public TokenDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Token>();

        }

        public Token getUser()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token a)
        {
            lock (locker)
            {
                if (a.ID != 0)
                {
                    database.Update(a);
                    return a.ID;
                }
                else
                {
                    return database.Insert(a);
                }
            }
        }

        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
