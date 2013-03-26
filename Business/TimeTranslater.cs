using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class TimeTranslater : ITimeTranslater
    {
        public Word minuit = new Word() { Index = 49, Length = 6 };
        public Word une = new Word() { Index = 26, Length = 3 };
        public Word deux = new Word() { Index = 7, Length = 4 };
        public Word trois = new Word() { Index = 17, Length = 5 };
        public Word quatre = new Word() { Index = 11, Length = 6 };
        public Word cinqh = new Word() { Index = 40, Length = 4 };
        public Word six = new Word() { Index = 37, Length = 3 };
        public Word sept = new Word() { Index = 29, Length = 4 };
        public Word huit = new Word() { Index = 33, Length = 4 };
        public Word neuf = new Word() { Index = 22, Length = 4 };
        public Word dixh = new Word() { Index = 46, Length = 3 };
        public Word onze = new Word() { Index = 55, Length = 4 };
        public Word midi = new Word() { Index = 44, Length = 4 };

        public Word cinqm = new Word() { Index = 95, Length = 4 };
        public Word dixm = new Word() { Index = 74, Length = 3 };
        public Word etq = new Word() { Index = 77, Length = 2 };
        public Word etd = new Word() { Index = 99, Length = 2 };
        public Word quart = new Word() { Index = 80, Length = 5 };
        public Word demi = new Word() { Index = 102, Length = 4 };
        public Word vingt = new Word() { Index = 88, Length = 5 };
        public Word le = new Word() { Index = 72, Length = 2 };
        public Word moins = new Word() { Index = 66, Length = 5 };

        public Word heure = new Word() { Index = 60, Length = 5 };
        public Word heures = new Word() { Index = 60, Length = 6 };

        Word[] _ChiffresHeures;
        List<Word[]> _ChiffresMinute;

        public TimeTranslater()
        {
            _ChiffresMinute = new List<Word[]>();
            _ChiffresHeures = new Word[] { minuit, une, deux, trois, quatre, cinqh, six, sept, huit, neuf, dixh, onze, midi, une, deux, trois, quatre, cinqh, six, sept, huit, neuf, dixh, onze };
            for (int i = 0; i < 3; i++) _ChiffresMinute.Add(new Word[] { });
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
            for (int i = 0; i < 2; i++) _ChiffresMinute.Add(new Word[] { });
        }

        public Word[] Translate(DateTime time)
        {
            List<Word> result = new List<Word>();
            result.Add(new Word() { Index = 0, Length = 2 });    // il
            result.Add(new Word() { Index = 3, Length = 3 });    // est

            if (IsSuperiorHalf(time)) time = time.AddHours(1);

            result.Add(_ChiffresHeures[time.Hour]);
            if (IsHourNeedHourLabel(time))
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

        private bool IsHourNeedHourLabel(DateTime time)
        {
            return time.Hour != 12 && time.Hour != 0;
        }

        private bool IsSuperiorHalf(DateTime time)
        {
            return time.Minute > 32;
        }

    }
}
