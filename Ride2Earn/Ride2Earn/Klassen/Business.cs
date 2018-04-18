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

        public IEnumerable<Gebruiker> Wachtwoorden
        {
            get { return _Wachtwoord; }
            set { _Wachtwoord = value; }
        }

        public Business()
        {
            _db = new Ride2EarnDatabase();
            _Wachtwoord = _db.GetWW();
        }

        /*public string Voornaam()
        {
            string a = string.Empty;
            foreach (Gebruiker b in Gebruikers)
            {
                a = b.T();
            }
            return a;
        }*/

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
