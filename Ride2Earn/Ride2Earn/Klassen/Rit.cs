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

        public string Kilometer()
        {
            return string.Format("{0}", Gereden);
        }

        public string StartRit()
        {
            return string.Format("Vertrekadres: {0}", Start);
        }

        public string EindeRit()
        {
            return string.Format("Bestemming: {0}", Einde);
        }

        public string DatumRit()
        {
            return string.Format("Datum: {0}", Datum.Date.ToString("dd/MM/yyyy"));
        }

        public string GeredenRit()
        {
            return string.Format("Aantal km: {0}", Gereden);
        }

        public override string ToString()
        {
            return string.Format("{0}", Gereden);
        }
        public string Vergoeding()
        {
            return string.Format("{0}", Gereden);
        }
    }

}
