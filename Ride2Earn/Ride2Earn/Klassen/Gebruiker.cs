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
    public class Gebruiker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        private int _id;
        private int _nummer;
        private int _pcode;
        private string _voornaam;
        private string _achternaam;
        private string _email;
        private string _wachtwoord;
        private string _straat;
        private string _gemeente;
        private string _rknnummer;

        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _id; }
            set { this._id = value; OnPropertyChanged(nameof(ID)); }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set { _voornaam = value;  OnPropertyChanged(nameof(Voornaam)); }
        }
        public string Achternaam
        {
            get { return _achternaam; }
            set { _achternaam = value; OnPropertyChanged(nameof(Achternaam)); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { _wachtwoord = value; OnPropertyChanged(nameof(Wachtwoord)); }
        }
        public string Straat
        {
            get { return _straat; }
            set { _straat = value; OnPropertyChanged(nameof(Straat)); }
        }
        public string Gemeente
        {
            get { return _gemeente; }
            set { _gemeente = value; OnPropertyChanged(nameof(Gemeente)); }
        }
        public string RknNummer
        {
            get { return _rknnummer; }
            set { _rknnummer = value; OnPropertyChanged(nameof(RknNummer)); }
        }
        public int Nummer
        {
            get { return _nummer; }
            set { this._nummer = value; OnPropertyChanged(nameof(Nummer)); }
        }
        public int Pcode
        {
            get { return _pcode; }
            set { this._pcode = value; OnPropertyChanged(nameof(Pcode)); }
        }

        /*public override string ToString()
        {
            return $"Voornaam: {Voornaam}, Achternaam: {Achternaam}";
        }*/

    }
}
