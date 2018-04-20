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
        private IEnumerable<Gebruiker> _Wachtwoord;
        private IEnumerable<Rit> _Km;
        private IEnumerable<Rit> _Start;
        private IEnumerable<Rit> _Einde;
        private IEnumerable<Rit> _Datum;
        private IEnumerable<Rit> _Gereden;

        public IEnumerable<Gebruiker> Wachtwoorden
        {
            get { return _Wachtwoord; }
            set { _Wachtwoord = value; }
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
        }

        public Business(int id)
        {
            _db = new Ride2EarnDatabase();
            _Start = _db.GetStart(id);
            _Einde = _db.GetEinde(id);
            _Datum = _db.GetDatum(id);
            _Gereden = _db.GetGereden(id);
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

        public string EindeRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Start)
            {
                a = b.EindeRit();
            }
            return a;
        }

        public string DatumRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Start)
            {
                a = b.DatumRit();
            }
            return a;
        }

        public string GeredenRit()
        {
            string a = string.Empty;
            foreach (Rit b in _Start)
            {
                a = b.GeredenRit();
            }
            return a;
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
