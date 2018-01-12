using Ride2Earn.Data;
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
    public class RitViewModel : INotifyPropertyChanged
    {
        private readonly IRitRepository _ritRepository;
        private IEnumerable<Rit> _ritten;

        public IEnumerable<Rit> Ritten
        {
            get
            {
                return _ritten;
            }
            set
            {
                _ritten = value;
                OnPropertyChanged();
            }
        }

        public string RitStart { get; set; }
        public string RitEinde { get; set; }
        public double RitAfstand { get; set; }
        public double RitGereden { get; set; }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var Rit = new Rit
                    {
                        Start = RitStart,
                        Einde = RitEinde,
                        Afstand = RitAfstand,
                        Gereden = RitGereden
                    };
                    await _ritRepository.AddRit(Rit);
                });
            }
        }

        public RitViewModel (IRitRepository a)
        {
            _ritRepository = a;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
        
}
