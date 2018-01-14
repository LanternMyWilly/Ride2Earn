using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ride2Earn.Models
{
    public class GebruikersViewModel : INotifyPropertyChanged
    {
        private readonly IGebruikersRepository _gebruikersRepository;
        private IEnumerable<Gebruiker> _Gebruikers;

        public IEnumerable<Gebruiker> Gebruikers
        {
            get
            {
                return _Gebruikers;
            }
            set
            {
                _Gebruikers = value;
                OnPropertyChanged();
            }
        }

        public string GebruikerVoornaam { get; set; }
        public string GebruikerAchternaam { get; set; }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    Gebruikers = await _gebruikersRepository.GetGebruiker();
                });
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var gebruiker = new Gebruiker
                    {
                        Voornaam = GebruikerVoornaam,
                        Achternaam = GebruikerAchternaam
                    };
                    await _gebruikersRepository.AddGebruiker(gebruiker);
                });
            }
        }

        public GebruikersViewModel (IGebruikersRepository gebruikersrepository)
        {
            _gebruikersRepository = gebruikersrepository;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string properyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }
    }
}
