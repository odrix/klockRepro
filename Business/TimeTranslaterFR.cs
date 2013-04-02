using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class TimeTranslaterFR : ITimeTranslater
    {
        public string ClockLetters { get {return "ILNESTODEUXQUATRETROISNEUFUNESEPTHUITSIXCINQMIDIXMINUITONZERHEURESMOINSOLEDIXETRQUARTPMDVINGT-CINQUETSDEMIEPAM"; }}

        public Word minuit = new Word(49, 6 );
        public Word une = new Word(26, 3 );
        public Word deux = new Word(7, 4 );
        public Word trois = new Word(17, 5 );
        public Word quatre = new Word(11, 6 );
        public Word cinqh = new Word(40, 4 );
        public Word six = new Word(37, 3 );
        public Word sept = new Word(29, 4 );
        public Word huit = new Word(33, 4 );
        public Word neuf = new Word(22, 4 );
        public Word dixh = new Word(46, 3 );
        public Word onze = new Word(55, 4 );
        public Word midi = new Word(44, 4 );

        public Word cinqm = new Word(94, 4 );
        public Word dixm = new Word(74, 3 );
        public Word etq = new Word(77, 2 );
        public Word etd = new Word(99, 2 );
        public Word quart = new Word(80, 5 );
        public Word demi = new Word(102, 4 );
        public Word vingt = new Word(88, 5 );
        public Word le = new Word(72, 2 );
        public Word moins = new Word(66, 5 );

        public Word heure = new Word(60, 5 );
        public Word heures = new Word(60, 6 );

        protected Word[] _ChiffresHeures;
        protected List<Word[]> _ChiffresMinute;

        public TimeTranslaterFR()
        {
            _ChiffresMinute = new List<Word[]>();
            _ChiffresHeures = new Word[] { minuit, une, deux, trois, quatre, cinqh, six, sept, huit, neuf, dixh, onze, midi, une, deux, trois, quatre, cinqh, six, sept, huit, neuf, dixh, onze };
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { cinqm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { dixm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { etq, quart });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { vingt });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { vingt, cinqm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { etd, demi });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { moins, vingt, cinqm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { moins, vingt });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { moins, le, quart });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { moins, dixm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { moins, cinqm });
        }

        public Word[] Translate(DateTime time)
        {
            List<Word> result = new List<Word>();
            result.Add(new Word(0, 2));    // il
            result.Add(new Word(3, 3));    // est

            if (time.IsSuperiorHalfAnHour()) time = time.AddHours(1);

            result.Add(_ChiffresHeures[time.Hour]);
            if (time.IsMidnigthOrMidday())
            {
                if (time.Hour > 1)
                    result.Add(heures);
                else
                    result.Add(heure);
            }

            if (_ChiffresMinute[time.Minute].Length > 0)
                result.AddRange(_ChiffresMinute[time.Minute]);

            return result.ToArray();
        }
        
    }
}
