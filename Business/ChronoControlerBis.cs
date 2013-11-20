using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    class ChronoControlerBis
    {
        string[] alphabet = {
        "  00000       11      2222222   3333333  44         55555555  6666666  77777777   8888888   9999999             ",
        " 00   00    1111     22     22 33     33 44    44   55       66     66 77    77  88     88 99     99  **        ",
        "00     00  11 11            22        33 44    44   55       66            77    88     88 99     99 ****       ",
        "00     00     11            22        33 44    44   55       66           77     88     88 99     99  **        ",
        "00     00     11      2222222   3333333  444444444  5555555  66666666    77       8888888   99999999            ",
        "00     00     11     22               33       44         55 66     66   77      88     88        99  **    **  ",
        "00     00     11     22               33       44         55 66     66   77      88     88        99 ****  **** ",
        " 00   00      11     22      2 33     33       44   55    55 66     66   77      88     88 99     99  **    **  ",
        "  00000     111111    2222222   3333333        44    555555   6666666    77       8888888   9999999             "};

        public ObservableCollection<char> HourToDisplay { get; private set; }
        public ObservableCollection<char> SecondeToDisplay { get; private set; }
        public ObservableCollection<char> MinuteToDisplay { get; private set; }
        public ObservableCollection<char> SepToDisplay { get; private set; }

        public ObservableCollection<List<Char>> DurationToDisplay {get; private set;}

        private TimeSpan Duration;
        private DateTime LastTime;


        public ChronoControlerBis()
        {
            HourToDisplay = new ObservableCollection<char>();
            MinuteToDisplay = new ObservableCollection<char>();
            SecondeToDisplay = new ObservableCollection<char>();
            SepToDisplay = new ObservableCollection<char>();

            CreateDisplayLettersAsync("00", HourToDisplay);
            CreateDisplayLettersAsync("00", MinuteToDisplay);
            CreateDisplayLettersAsync("00", SecondeToDisplay);
            CreateDisplayLettersAsync(":", SepToDisplay);
        }

        public async void IncrementeSeconde()
        {
            Duration = Duration.Add(TimeSpan.FromSeconds(1));
            await UpdateDisplayLettersAsync(Duration.ToString("ss"), SecondeToDisplay);
        }

        public async void TryIncrementeSeconde()
        {
            if (DateTime.Now.Subtract(LastTime).TotalMilliseconds > 850)
            {
                IncrementeSeconde();
                LastTime = DateTime.Now;
            }
        }

        private async Task CreateDisplayLettersAsync(string Duration, ObservableCollection<char> toDisplay)
        {
            toDisplay.Clear();

            int j = 0;
            for (int l = 0; l < 9; l++)
            {
                foreach (char c in Duration)
                {
                    int nbItem = 10;
                    int startIndex = c - 48;
                    startIndex *= 10;
                    if (c == ':')
                    {
                        startIndex = 100;
                        nbItem = 6;
                    }
                    for (int i = startIndex; i < startIndex + nbItem; i++)
                    {
                        toDisplay.Add(alphabet[l][i]);
                    }
                }
            }
        }


        private async Task UpdateDisplayLettersAsync(string Duration, ObservableCollection<char> toDisplay)
        {
            //toDisplay.Clear();

            int j = 0;
            for (int l = 0; l < 9; l++)
            {
                foreach (char c in Duration)
                {
                    int nbItem = 10;
                    int startIndex = c-48;
                    if (startIndex > 9 || startIndex < 0) nbItem = 6;
                    if (startIndex < 0) startIndex = 11;
                    startIndex *= 10;
                    for (int i = startIndex; i < startIndex + nbItem; i++)
                    {
                        toDisplay[j] = alphabet[l][i];
                        j++;
                    }
                }
            }
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            if (Duration == TimeSpan.FromSeconds(0))
            {
                Duration = TimeSpan.FromSeconds(0);
                //await UpdateDisplayLettersSecondeAsync(Duration);
            }
            LastTime = DateTime.Now;
        }

        public void Stop(bool andDisplay = false)
        {
            //LastDuration = Duration;
            Duration = TimeSpan.FromSeconds(0);

        }

    }
}
