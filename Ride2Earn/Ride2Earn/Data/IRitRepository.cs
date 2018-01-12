using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ride2Earn.Klassen;

namespace Ride2Earn.Data
{
    public interface IRitRepository
    {
        Task<bool> AddRit(Rit a);
    }
}
