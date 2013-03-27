using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class ClockControler : INotifyPropertyChanged
    {
        
        //""
        private DateTime? _lastTime = null;
        public ObservableCollection<DisplayLetter> ClockLetters { get; set; }
        public int MinutesRestantes { get; private set; }

        ITimeTranslater _translater;

        public ClockControler()
            : this(new TimeTranslaterFR())
        { }

        public ClockControler(ITimeTranslater translater)
        {
            _translater = translater;
            InitClockLetters();
        }

        private void InitClockLetters()
        {
            ClockLetters = new ObservableCollection<DisplayLetter>();
            foreach (char c in  _translater.ClockLetters.ToCharArray())
            {
                DisplayLetter l = new DisplayLetter() { Name = c.ToString(), Active = false };
                ClockLetters.Add(l);
            }
        }


        public void CurrentTimeToDisplay()
        {
            DateTime currentTime = DateTime.Now;

            MinutesRestantes = currentTime.Minute % 5;
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MinutesRestantes"));

            if (MinutesRestantes == 0 || !_lastTime.HasValue) // ça n'a pas changé depuis le dernier passage
            {
                Word[] words = _translater.Translate(currentTime);
                foreach (DisplayLetter l in ClockLetters) l.Active = false;
                foreach (Word r in words)
                {
                    for (int i = r.Index; i < r.Index + r.Length; i++)
                    {
                        ClockLetters[i].Active = true;
                    }
                }
            }

            _lastTime = currentTime;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
