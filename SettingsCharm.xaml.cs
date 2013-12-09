using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page http://go.microsoft.com/fwlink/?LinkId=234236

namespace klockRepro
{
    public sealed partial class SettingsCharm : UserControl
    {
        public SettingsCharm()
        {
            this.InitializeComponent();

            cboLanguage.SelectedIndex = CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower() == "fr" ? 1 : 0;

            SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
        }

        private void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("o", "Options", (p) => { cfoSettings.IsOpen = true; }));
            args.Request.ApplicationCommands.Add(new SettingsCommand("e", "Ecran de veille", (p) => { screensaver(); }));
        }

        private void cboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var langue = ((ComboBoxItem)e.AddedItems[0]).Name.Replace("cbi", "");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(langue);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(langue);
            ((App)App.Current).MainClockControler.ChangeTranslater(langue);
            ((App)App.Current).MainClockControler.CurrentTimeToDisplay(true);
        }

        private async void screensaver()
        {

            bool x = await Launcher.LaunchUriAsync(new Uri("http://www.mydrix.com/KlockRepro.scr"));

            //string screenSaverFile = "Assets\\KlockRepro.scr";
            //var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(screenSaverFile);
            
            //if (file != null)
            //{
            //    //// Set the option to show the picker
            //    var options = new Windows.System.LauncherOptions();
            //    options.TreatAsUntrusted = false;
            //    options.DisplayApplicationPicker = true;

            //    // Launch the retrieved file
            //    bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
            //}

            //Launcher.LaunchFileAsync(null);
            //var cmd = "rundll32.exe desk.cpl,InstallScreenSaver KlockRepro.scr";
        }

    }
}
