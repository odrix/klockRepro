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

        protected override void OnStartup(StartupEventArgs e)
        {
            //e.Args is the string[] of command line argruments
            string firstArgs = e.Args[0];
            switch (firstArgs.ToLower())
            {
                case "p" :
                    MainClockControler.DisplayProperties.MinutesSize = 4;
                    MainClockControler.DisplayProperties.MinutesMargin = 6;
                    MainClockControler.DisplayProperties.LetterSize = 12;
                    MainClockControler.DisplayProperties.LetterFontSize = 10;
                    MainClockControler.DisplayProperties.Width = 170;
                    MainClockControler.DisplayProperties.MainMargin = 3;
                    break;
                case "c":
                case "s":
                    MainClockControler.DisplayProperties.MinutesSize = 20;
                    MainClockControler.DisplayProperties.MinutesMargin = 25;
                    MainClockControler.DisplayProperties.LetterSize = 50;
                    MainClockControler.DisplayProperties.LetterFontSize = 45;
                    MainClockControler.DisplayProperties.Width = 760;
                    MainClockControler.DisplayProperties.MainMargin = 30;
                    break;
            }
        }

    }
}
