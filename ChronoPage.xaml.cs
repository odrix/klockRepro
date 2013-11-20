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
        ChronoControlerBis controler;

        public ChronoPage()
        {
            this.InitializeComponent();

            controler = new ChronoControlerBis();

            chrono = new DispatcherTimer();
            chrono.Interval = TimeSpan.FromMilliseconds(200);
            chrono.Tick += chrono_Tick;
        }

        void chrono_Tick(object sender, object e)
        {
            controler.TryIncrementeSeconde();
        }

        protected override void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        {
            controler.Stop(true);
            GridContent.DataContext = controler;
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            if (chrono.IsEnabled)
            {
                controler.Stop();
                chrono.Stop();
            }
            GoBack();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!chrono.IsEnabled)
            {
                controler.Start();
                chrono.Start();
            }
            this.BottomAppBar.IsOpen = false;
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            chrono.Stop();
            controler.Pause();
            this.BottomAppBar.IsOpen = false;
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            chrono.Stop();
            controler.Stop();
            this.BottomAppBar.IsOpen = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
