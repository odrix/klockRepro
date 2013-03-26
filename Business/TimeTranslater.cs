using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class TimeTranslater : ITimeTranslater
    {
        public IndexLengthWord minuit = new IndexLengthWord() { Index = 49, Length = 6 };
        public IndexLengthWord une = new IndexLengthWord() { Index = 26, Length = 3 };
        public IndexLengthWord deux = new IndexLengthWord() { Index = 7, Length = 4 };
        public IndexLengthWord trois = new IndexLengthWord() { Index = 17, Length = 5 };
        public IndexLengthWord quatre = new IndexLengthWord() { Index = 11, Length = 6 };
        public IndexLengthWord cinqh = new IndexLengthWord() { Index = 40, Length = 4 };
        public IndexLengthWord six = new IndexLengthWord() { Index = 37, Length = 3 };
        public IndexLengthWord sept = new IndexLengthWord() { Index = 29, Length = 4 };
        public IndexLengthWord huit = new IndexLengthWord() { Index = 33, Length = 4 };
        public IndexLengthWord neuf = new IndexLengthWord() { Index = 22, Length = 4 };
        public IndexLengthWord dixh = new IndexLengthWord() { Index = 46, Length = 3 };
        public IndexLengthWord onze = new IndexLengthWord() { Index = 55, Length = 4 };
        public IndexLengthWord midi = new IndexLengthWord() { Index = 44, Length = 4 };

        public IndexLengthWord cinqm = new IndexLengthWord() { Index = 95, Length = 4 };
        public IndexLengthWord dixm = new IndexLengthWord() { Index = 74, Length = 3 };
        public IndexLengthWord etq = new IndexLengthWord() { Index = 77, Length = 2 };
        public IndexLengthWord etd = new IndexLengthWord() { Index = 99, Length = 2 };
        public IndexLengthWord quart = new IndexLengthWord() { Index = 80, Length = 5 };
        public IndexLengthWord demi = new IndexLengthWord() { Index = 102, Length = 4 };
        public IndexLengthWord vingt = new IndexLengthWord() { Index = 88, Length = 5 };
        public IndexLengthWord le = new IndexLengthWord() { Index = 72, Length = 2 };
        public IndexLengthWord moins = new IndexLengthWord() { Index = 66, Length = 5 };

        public IndexLengthWord heure = new IndexLengthWord() { Index = 60, Length = 5 };
        public IndexLengthWord heures = new IndexLengthWord() { Index = 60, Length = 6 };

        string[] ChiffresHeures = new string[] { "minuit", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "midi", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze" };
        List<string> ChiffresMinute;

        IndexLengthWord[] _ChiffresHeures;
        List<IndexLengthWord[]> _ChiffresMinute;

        public TimeTranslater()
        {
            ChiffresMinute = new List<string>();
            _ChiffresMinute = new List<IndexLengthWord[]>();

            for (int i = 0; i < 3; i++) ChiffresMinute.Add("");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("cinq");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("dix");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("et quart");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("vingt");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("vingt cinq");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("et demi");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins vingt cinq");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins vingt");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins le quart");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins dix");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins cinq");
            for (int i = 0; i < 2; i++) ChiffresMinute.Add("");

            _ChiffresHeures = new IndexLengthWord[] { minuit, une, deux, trois, quatre, cinqh, six, sept, huit, neuf, dixh, onze, midi, une, deux, trois, quatre, cinqh, six, sept, huit, neuf, dixh, onze };
            for (int i = 0; i < 3; i++) _ChiffresMinute.Add(new IndexLengthWord[] { });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { cinqm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { dixm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { etq, quart });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { vingt });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { vingt, cinqm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { etd, demi });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { moins, vingt, cinqm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { moins, vingt });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { moins, le, quart });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { moins, dixm });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new IndexLengthWord[] { moins, cinqm });
            for (int i = 0; i < 2; i++) _ChiffresMinute.Add(new IndexLengthWord[] { });
        }

        public string Translate(DateTime time)
        {
            StringBuilder result = new StringBuilder("il est");

            if (IsSuperiorHalf(time)) time = time.AddHours(1);

            result.AppendFormat(" {0}", ChiffresHeures[time.Hour]);
            if (IsHourNeedHourLabel(time))
            {
                result.Append(" heure");
                if (time.Hour > 1) result.Append("s");
            }

            if (ChiffresMinute[time.Minute] != "")
                result.AppendFormat(" {0}", ChiffresMinute[time.Minute]);

            return result.ToString();
        }

        public IndexLengthWord[] TranslateToIndex(DateTime time)
        {
            List<IndexLengthWord> result = new List<IndexLengthWord>();
            result.Add(new IndexLengthWord() { Index = 0, Length = 2 });    // il
            result.Add(new IndexLengthWord() { Index = 3, Length = 3 });    // est

            if (IsSuperiorHalf(time)) time = time.AddHours(1);

            result.Add(_ChiffresHeures[time.Hour]);
            if (IsHourNeedHourLabel(time))
            {
                if (time.Hour > 1)
                    result.Add(heures);
                else
                    result.Add(heure);
            }

            if (ChiffresMinute[time.Minute] != "")
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
