using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        }

        private void cboLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var langue = ((ComboBoxItem)e.AddedItems[0]).Name.Replace("cbi", "");
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(langue);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(langue);
            ((App)App.Current).MainClockControler.ChangeTranslater(langue);
            ((App)App.Current).MainClockControler.CurrentTimeToDisplay(true);
        }

    }
}
