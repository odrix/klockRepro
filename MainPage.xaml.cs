using klockRepro.Business;
using klockRepro.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace klockRepro
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : LayoutAwarePage
    {
        DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();
            ((App)App.Current).MainClockControler.PropertyChanged += MainClockControler_PropertyChanged;

            this.DataContext = ((App)App.Current).MainClockControler;
            ((App)App.Current).MainClockControler.CurrentTimeToDisplay(true);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }


        void MainClockControler_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ClockLetters")
                Refresh();
        }


        void timer_Tick(object sender, object e)
        {
            ((App)App.Current).MainClockControler.CurrentTimeToDisplay();
        }

        private void Refresh()
        {
            foreach (DisplayLetter l in ((App)App.Current).MainClockControler.ClockLetters)
            {
                // le gridview pour la vue normal
                var selectItem = (from s in GrdClock.SelectedItems
                                  where s == l
                                  select s).FirstOrDefault();
                if (selectItem == null && l.Active) GrdClock.SelectedItems.Add(l);
                else if (selectItem != null && !l.Active) GrdClock.SelectedItems.Remove(l);

                // le gridview pour la vue Snap
                var selectItemSnap = (from s in GrdClockSnap.SelectedItems
                                      where s == l
                                      select s).FirstOrDefault();
                if (selectItemSnap == null && l.Active) GrdClockSnap.SelectedItems.Add(l);
                else if (selectItemSnap != null && !l.Active) GrdClockSnap.SelectedItems.Remove(l);
            }
        }

        /// <summary>
        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        /// </summary>
        /// <param name="e">Données d'événement décrivant la manière dont l'utilisateur a accédé à cette page. La propriété Parameter
        /// est généralement utilisée pour configurer la page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
