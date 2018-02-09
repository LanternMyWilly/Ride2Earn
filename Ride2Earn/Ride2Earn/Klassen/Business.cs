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
        private IEnumerable<Gebruiker> _gebruiker;

        public IEnumerable<Gebruiker> Gebruikers
        {
            get { return _gebruiker; }
            set { _gebruiker = value; }
        }

        /*public Business()
        {
            _db = new Ride2EarnDatabase();
            _gebruiker = _db.GetVoornaam();
        }*/

        public string Voornaam()
        {
            string a = string.Empty;
            foreach (Gebruiker b in Gebruikers)
            {
                a = b.ToString();
            }
            return a;
        }
    }
}
