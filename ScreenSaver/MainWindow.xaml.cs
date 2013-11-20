using klockRepro.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ScreenSaver
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        public MainWindow()
        {
            this.InitializeComponent();
            ((App)App.Current).MainClockControler.PropertyChanged += MainClockControler_PropertyChanged;

            this.DataContext = ((App)App.Current).MainClockControler;
            ((App)App.Current).MainClockControler.CurrentTimeToDisplay(true);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += timer_Tick;
            timer.Start();
            this.Focus();
        }


        void MainClockControler_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ClockLetters")
                Refresh();
        }


        void timer_Tick(object sender, object e)
        {
            ((App)App.Current).MainClockControler.CurrentTimeToDisplay(true);
        }

        private void Refresh()
        {
            foreach (DisplayLetter l in ((App)App.Current).MainClockControler.ClockLetters)
            {
                // le gridview pour la vue normal
                DisplayLetter selectItem = null;
                foreach (DisplayLetter s in GrdClock.SelectedItems)
                {
                    if(s==l)
                    {
                        selectItem = s;
                        break;
                    }
                }
                if (selectItem == null && l.Active) GrdClock.SelectedItems.Add(l);
                else if (selectItem != null && !l.Active) GrdClock.SelectedItems.Remove(l);
            }
        }

        private void Key_Close(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void Touch_Close(object sender, TouchEventArgs e)
        {
            this.Close();
        }

        //protected override void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        //{
        //    timer.Start();
        //}
    }
}
