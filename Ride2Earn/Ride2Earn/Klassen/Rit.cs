using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ride2Earn.Klassen
{
    [Table("Ritten")]
    public class Rit
    {
        private int sID;
        private string sStart;
        private string sEinde;
        private DateTime sDatum;
        private double sGereden;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return sID; }
            set { sID = value; }
        }
        public string Start
        {
            get { return sStart; }
            set { sStart = value; }
        }
        public string Einde
        {
            get { return sEinde; }
            set { sEinde = value; }
        }
        public DateTime Datum
        {
            get { return sDatum; }
            set { sDatum = value; }
        }
        public double Gereden
        {
            get { return sGereden; }
            set { sGereden = value; }
        }
   
    }

}
