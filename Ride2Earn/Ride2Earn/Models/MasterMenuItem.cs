using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ride2Earn.Models
{
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color Backgroundcolor { get; set; }
        public Type TargetType { get; set; }

        public MasterMenuItem(string Title, string IconSoure, Color ColorA, Type Target)
        {
            this.Title = Title;
            this.IconSource = IconSource;
            this.Backgroundcolor = ColorA;
            this.TargetType = Target;
        }
    }
}
