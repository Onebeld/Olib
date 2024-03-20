using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Olib.Core
{
    class Themes
    {
        public enum WindowsTheme
        {
            Dark,
            Light,
            SeaFoam,
            Bloody,
            Aurora
        }
        public void WatchTheme()
        {
            WindowsTheme initialTheme = GetWindowsTheme();
        }
        public static WindowsTheme GetWindowsTheme()
        {
            return Properties.Settings.Default.IsDarkTheme == true ? WindowsTheme.Dark : WindowsTheme.Light;
        }
    }
}
