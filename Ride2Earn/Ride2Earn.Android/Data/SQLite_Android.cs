using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Ride2Earn.Data;
using Ride2Earn.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace Ride2Earn.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "DitIsEenDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}