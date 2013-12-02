using klockRepro.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;
using System.Windows.Media;

namespace ScreenSaver
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ClockControler MainClockControler { get; private set; }
        private MainWindow winSaverPreview;

        public App()
        {
            MainClockControler = new ClockControler();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            string firstArgs = "s";
            Int32 previewHandle = 0;

            if (e.Args.Length > 0)
                firstArgs = e.Args[0].Substring(1,1);

            if (e.Args.Length > 1)
                previewHandle = Convert.ToInt32(e.Args[1]);

            switch (firstArgs.ToLower())
            {
                case "c":
                    SettingsWindow noSettings = new SettingsWindow();
                    noSettings.Show();
                    break;
                case "p":
                    MainClockControler.DisplayProperties.MinutesSize = 4;
                    MainClockControler.DisplayProperties.MinutesMargin = 6;
                    MainClockControler.DisplayProperties.LetterSize = 5;
                    MainClockControler.DisplayProperties.LetterFontSize = 5;
                    MainClockControler.DisplayProperties.Width = 145;
                    MainClockControler.DisplayProperties.WidthWithMarge = 150;
                    MainClockControler.DisplayProperties.MainMargin = 8;
            
                    winSaverPreview = new MainWindow();
                    winSaverPreview.WindowState = System.Windows.WindowState.Normal;
                    winSaverPreview.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

                    //WindowInteropHelper interopWin1 = new WindowInteropHelper(win);
                    //interopWin1.Owner = new IntPtr(previewHandle);

                    IntPtr pPreviewHnd = new IntPtr(previewHandle);
                    HwndSource winWPFContent;

                    RECT lpRect = new RECT();
                    bool bGetRect = Win32API.GetClientRect(pPreviewHnd, ref lpRect);

                    HwndSourceParameters sourceParams = new HwndSourceParameters("sourceParams");

                    sourceParams.PositionX = 0;
                    sourceParams.PositionY = 0;
                    sourceParams.Height = lpRect.Bottom - lpRect.Top;
                    sourceParams.Width = lpRect.Right - lpRect.Left;
                    sourceParams.ParentWindow = pPreviewHnd;
                    sourceParams.WindowStyle = (int)(WindowStyles.WS_VISIBLE | WindowStyles.WS_CHILD | WindowStyles.WS_CLIPCHILDREN);

                    winWPFContent = new HwndSource(sourceParams);
                    winWPFContent.Disposed += new EventHandler(winWPFContent_Disposed);
                    winWPFContent.RootVisual = winSaverPreview.gridMain;
                    break;
                case "s":
                    MainClockControler.DisplayProperties.MinutesSize = 20;
                    MainClockControler.DisplayProperties.MinutesMargin = 25;
                    MainClockControler.DisplayProperties.LetterSize = 50;
                    MainClockControler.DisplayProperties.LetterFontSize = 45;
                    MainClockControler.DisplayProperties.LetterMargin = new Thickness(6, 4, 6, 4);
                    MainClockControler.DisplayProperties.Width = 780;
                    MainClockControler.DisplayProperties.WidthWithMarge = 790;
                    MainClockControler.DisplayProperties.MainMargin = 30;

                    MainWindow win = new MainWindow();
                    win.WindowState = WindowState.Maximized;
                    win.Show();
                    break;
            }
        }

        void winWPFContent_Disposed(object sender, EventArgs e)
        {
            winSaverPreview.Close();
        }

    }
}
