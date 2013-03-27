using klockRepro.Business;
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
    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer;
        ClockControler controler;

        public MainPage()
        {
            this.InitializeComponent();
            controler = new ClockControler();
            this.DataContext = controler;

            controler.CurrentTimeToDisplay();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, object e)
        {
            controler.CurrentTimeToDisplay();
            foreach (DisplayLetter l in controler.ClockLetters)
            {
                var selectItem = (from s in GrdClock.SelectedItems
                        where s == l
                        select s).FirstOrDefault();
                if (selectItem == null && l.Active) GrdClock.SelectedItems.Add(l);
                else if (selectItem != null && !l.Active) GrdClock.SelectedItems.Remove(l);
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
