using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride2Earn.Models
{
    public interface IGebruikersRepository
    {
        Task<IEnumerable<Gebruiker>> GetGebruiker();

        Task<Gebruiker> GetGebruikerByID(int id);

        Task<bool> AddGebruiker(Gebruiker a);

        Task<bool> UpdateGebruiker(Gebruiker a);

        Task<bool> RemoveGebruiker(int id);

        Task<IEnumerable<Gebruiker>> QueryGebruiker(Func<Gebruiker, bool> predicate);
    }
}
