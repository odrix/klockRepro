using klockRepro.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenSaver
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ClockControler MainClockControler { get; private set; }

        public App()
        {
            MainClockControler = new ClockControler();
 //           MainClockControler.ChangeTranslater(System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        }

    }
}
