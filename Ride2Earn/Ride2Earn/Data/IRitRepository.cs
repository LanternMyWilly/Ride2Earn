using Ride2Earn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride2Earn.Data
{
    public interface IRitRepository
    {
        Task<bool> AddRit(Rit a);
    }
}
