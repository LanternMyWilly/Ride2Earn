using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ride2Earn.Helpers
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}