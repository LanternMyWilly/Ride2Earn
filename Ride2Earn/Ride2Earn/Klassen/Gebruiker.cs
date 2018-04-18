using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ride2Earn.Klassen
{
    [Table("Gebruikers")]
    public class Gebruiker
    {
        private int sID;
        private int sNummer;
        private int sPcode;
        private string sVoornaam;
        private string sAchternaam;
        private string sEmail;
        private string sWachtwoord;
        private string sStraat;
        private string sGemeente;
        private string sRknNummer;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return sID; }
            set { sID = value; }
        }
        public int Nummer
        {
            get { return sNummer; }
            set { sNummer = value; }
        }
        public int Pcode
        {
            get { return sPcode; }
            set { sPcode = value; }
        }
        public string Voornaam
        {
            get { return sVoornaam; }
            set { sVoornaam = value; }
        }
        public string Achternaam
        {
            get { return sAchternaam; }
            set { sAchternaam = value; }
        }
        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public string Wachtwoord
        {
            get { return sWachtwoord; }
            set { sWachtwoord = value; }
        }
        public string Straat
        {
            get { return sStraat; }
            set { sStraat = value; }
        }
        public string Gemeente
        {
            get { return sGemeente; }
            set { sGemeente = value; }
        }
        public string RknNummer
        {
            get { return sRknNummer; }
            set { sRknNummer = value; }
        }      

        public string TWW()
        {
            return string.Format("{0}", Wachtwoord);
        }
    }
}
