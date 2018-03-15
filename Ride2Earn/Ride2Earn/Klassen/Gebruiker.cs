using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ride2Earn.Klassen
{
    public class Gebruiker
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Nummer { get; set; }
        public int Pcode { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Straat { get; set; }
        public string Gemeente { get; set; }
        public string RknNummer { get; set; }
    }
}
