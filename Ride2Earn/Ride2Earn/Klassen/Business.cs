using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Data;

namespace Ride2Earn.Klassen
{
    class Business
    {
        private Ride2EarnDatabase _db;
        private IEnumerable<Gebruiker> _checken;
        private IEnumerable<Rit> _GetStartAdressen;
        private IEnumerable<Rit> _GetEindeAdressen;
        private IEnumerable<Gebruiker> _Wachtwoord;
        private IEnumerable<Rit> _Km;
        private IEnumerable<Rit> _Start;
        private IEnumerable<Rit> _Einde;
        private IEnumerable<Rit> _Datum;
        private IEnumerable<Rit> _Gereden;

        public IEnumerable<Rit> StartAdressen
        {
            get { return _GetStartAdressen; }
            set { _GetStartAdressen = value; }
        }

        public IEnumerable<Rit> EindAdressen
        {
            get { return _GetEindeAdressen; }
            set { _GetEindeAdressen = value; }
        }

        public IEnumerable<Gebruiker> Wachtwoorden
        {
            get { return _Wachtwoord; }
            set { _Wachtwoord = value; }
        }

        public IEnumerable<Gebruiker> Checken
        {
            get { return _checken; }
            set { _checken = value; }
        }

        public IEnumerable<Rit> Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        public IEnumerable<Rit> Datum
        {
            get { return _Datum; }
            set { _Datum = value; }
        }

        public IEnumerable<Rit> Einde
        {
            get { return _Einde; }
            set { _Einde = value; }
        }

        public IEnumerable<Rit> Gereden
        {
            get { return _Gereden; }
            set { _Gereden = value; }
        }

        public IEnumerable<Rit> KM
        {
            get { return _Km; }
            set { _Km = value; }
        }

        public Business()
        {
            _db = new Ride2EarnDatabase();
            _Wachtwoord = _db.GetWW();
            _Km = _db.GetAantalKM();
            _GetStartAdressen = _db.GetStartAdressen();
            _GetEindeAdressen = _db.GetEindAdressen();
            _checken = _db.Checken();
        }

        public Business(int id)
        {
            _db = new Ride2EarnDatabase();
            _Start = _db.GetStart(id);
            _Einde = _db.GetEinde(id);
            _Datum = _db.GetDatum(id);
            _Gereden = _db.GetGereden(id);
        }

        public List<string> GetStartAdressen()
        {
            List<string> a = new List<string>();
            foreach (Rit b in _GetStartAdressen)
            {
                bool containsItem = a.Contains(b.StartAdressen());
                if (containsItem == false)
                {
                    a.Add(b.StartAdressen());
                }
            }
            return a;
        }

        public List<string> GetEindAdressen()
        {
            List<string> a = new List<string>();
            foreach (Rit b in _GetEindeAdressen)
            {
                bool containsItem = a.Contains(b.EindAdressen());
                if (containsItem == false)
                {
                    a.Add(b.EindAdressen());
                }               
            }
            return a;
        }

        public string StartRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Start)
            {
                a = b.StartRit();
            }
            return a;
        }

        public string CheckIfExists()
        {
            string a = string.Empty;
            foreach (Gebruiker b in _checken)
            {
                a = b.ToCheck();
            }
            return a;
        }

        public string EindeRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Einde)
            {
                a = b.EindeRit();
            }
            return a;
        }

        public string DatumRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Datum)
            {
                a = b.DatumRit();
            }
            return a;
        }

        public string GeredenRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Gereden)
            {
                a = b.GeredenRit();
            }
            return a;
        }

        public string VergoedingPerRit()
        {
            double Vergoeding = 0;
            string result = string.Empty;
            string a = string.Empty;
            foreach (Rit b in _Gereden)
            {
                a = b.Vergoeding();
            }
            Vergoeding = Convert.ToDouble(a) * 0.15; 
            Vergoeding = Math.Round(Vergoeding, 2);
            result = "Vergoeding: " + Vergoeding;
            return result;

        }

        public string AantalKM()
        {
            string a = string.Empty;
            foreach (Rit b in KM)
            {
                a = b.Kilometer();
            }
            return a;
        }

        public string TotaleVergoeding()
        {
            string Vergoeding = string.Empty;
            double totaal = 0;
            string a = string.Empty;
            foreach (Rit b in KM)
            {
                a = b.Vergoeding();
            }

            totaal = Convert.ToDouble(a) * 0.15;
            totaal = Math.Round(totaal, 2);
            Vergoeding = "Totale vergoeding: €" + totaal;
            return Vergoeding;
        }

        public bool Vergelijken(string ww)
        {
            string b = string.Empty;
            foreach (Gebruiker c in Wachtwoorden)
            {
                b = c.TWW();
            }

            bool a;
            if (b == ww)
            {
                a = true;
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}
