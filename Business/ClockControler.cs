using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class ClockControler
    {
        private string _ClockLetters = "ILNESTODEUXQUATRETROISNEUFUNESEPTHUITSIXCINQMIDIXMINUITONZERHEURESMOINSOLEDIXETRQUARTPMDVINGT-CINQUETSDEMIEPAM";
        public ObservableCollection<DisplayLetter> ClockLetters { get; set; }
        ITimeTranslater _translater;

        public ClockControler()
            : this(new TimeTranslater())
        { }

        public ClockControler(ITimeTranslater translater)
        {
            _translater = translater;
            InitClockLetters();
        }

        private void InitClockLetters()
        {
            ClockLetters = new ObservableCollection<DisplayLetter>();
            foreach (char c in _ClockLetters.ToCharArray())
            {
                ClockLetters.Add(new DisplayLetter() { Name = c.ToString(), Active = false });
            }
        }

        public void CurrentTimeToDisplay()
        {
            DateTime currentTime = DateTime.Now;

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
    }
}
