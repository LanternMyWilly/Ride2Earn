using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ride2Earn.Klassen
{
    [Table("EindAdressen")]
    class EindAdres
    {
        private int intID;
        private string strEind;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }
        public string Eind
        {
            get { return strEind; }
            set { strEind = value; }
        }
    }
}
