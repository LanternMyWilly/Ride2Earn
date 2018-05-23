using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ride2Earn.Klassen
{
    [Table("StartAdressen")]
    class StartAdres
    {
        private int intID;
        private string strStart;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }
        public string Start
        {
            get { return strStart; }
            set { strStart = value; }
        }
    }
}
