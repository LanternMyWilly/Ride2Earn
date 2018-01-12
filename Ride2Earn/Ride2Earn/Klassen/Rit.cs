using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Ride2Earn.Klassen
{
    public class Rit
    {
        private int intID;
        private string strStart;
        private string strEinde;
        private double dblAfstand;
        private double dblGereden;

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
        public string Einde
        {
            get { return strEinde; }
            set { strEinde = value; }
        }
        public double Afstand
        {
            get { return dblAfstand; }
            set { dblAfstand = value; }
        }
        public double Gereden
        {
            get { return dblGereden; }
            set { dblGereden = value; }
        }

        public Rit()
        { }

    }
}
