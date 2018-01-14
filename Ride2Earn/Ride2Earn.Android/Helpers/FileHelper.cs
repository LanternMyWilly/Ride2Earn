using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ride2Earn.Droid.Helpers;
using Ride2Earn.Helpers;
using Xamarin.Forms;

[assembly : Xamarin.Forms.Dependency(typeof(FileHelper))]
namespace Ride2Earn.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string libfolder = Path.Combine(path, "..", "Library", "Databases");
            if(!Directory.Exists(libfolder))
            {
                Directory.CreateDirectory(libfolder);
            }
            return Path.Combine(libfolder, filename);
        }
    }
}