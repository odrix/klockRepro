using klockRepro.Business;
using klockRepro.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public sealed partial class ChronoPage : LayoutAwarePage, INotifyPropertyChanged
    {
        DispatcherTimer chrono;
        ChronoControler controler;

        public ChronoPage()
        {
            this.InitializeComponent();

            controler = new ChronoControler();

            chrono = new DispatcherTimer();
            chrono.Interval = TimeSpan.FromSeconds(1);
            chrono.Tick += chrono_Tick;
        }

        void chrono_Tick(object sender, object e)
        {
            controler.IncrementeSeconde();
        }

        protected override void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        {
            controler.Reinit();
            GrdChrono.DataContext = controler;
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if(!chrono.IsEnabled)
                chrono.Start();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            chrono.Stop();
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            controler.Reinit();
            chrono.Stop();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
