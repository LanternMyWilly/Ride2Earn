using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride2Earn.Models
{
    public class Gebruiker
    {
        private string strVoornaam;
        private string strAchternaam;
        private string strEmail;
        private string strWachtwoord;
        private string strStraat;
        private string strGemeente;
        private string strRknNummer;
        private string strStart;
        private string strEinde;
        private double dblAfstand;
        private int intNummer;
        private int intPostcode;
        private int intID;       

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }
        public string Voornaam
        {
            get { return strVoornaam; }
            set { strVoornaam = value; }
        }
        public string Achternaam
        {
            get { return strAchternaam; }
            set { strAchternaam = value; }
        }
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public string Wachtwoord
        {
            get { return strWachtwoord; }
            set { strWachtwoord = value; }
        }
        public string Straat
        {
            get { return strStraat; }
            set { strStraat = value; }
        }
        public string Gemeente
        {
            get { return strGemeente; }
            set { strGemeente = value; }
        }
        public string RknNummer
        {
            get { return strRknNummer; }
            set { strRknNummer = value; }
        }

        public int Nummer
        {
            get { return intNummer; }
            set { intNummer = value; }
        }
        public int Postcode
        {
            get { return intPostcode; }
            set { intPostcode = value; }
        }

        public Gebruiker()
        { }

        public override string ToString()
        {
            return $"{strVoornaam}, {strAchternaam}";
        }
        

        public Gebruiker(string pStart, string pEinde, double pAfst)
        {
            strStart = pStart;
            strEinde = pEinde;
            dblAfstand = pAfst;
        }
    }
}
