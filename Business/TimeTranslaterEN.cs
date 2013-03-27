using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class TimeTranslaterEN : TimeTranslaterBase,  ITimeTranslater
    {
        public string ClockLetters
        {
            get { return "ITLISBFAMPMACQUARTERDCTWENTYFIVEXHALFBTENFTOPASTERUNINEONESIXTHREEFOURFIVETWOEIGHTELEVENSEVENTWELVETENSEOCLOCK"; }
        }

        Word am = new Word(7, 2);
        Word pm = new Word(9, 2);

        Word quarter = new Word(13, 7);
        Word twenty = new Word(22, 6);
        Word fivem = new Word(28, 4);
        Word tenm = new Word(38, 3);
        Word half = new Word(33, 4);

        Word to = new Word(42, 2);
        Word past = new Word(44, 4);

        Word one = new Word(55, 3);
        Word two = new Word(74, 3);
        Word three = new Word(61, 5);
        Word four = new Word(66, 4);
        Word fiveh = new Word(70, 4);
        Word six = new Word(58, 3);
        Word seven = new Word(88, 5);
        Word eight = new Word(77, 5);
        Word nine = new Word(51, 4);
        Word tenh = new Word(99, 3);
        Word eleven = new Word(82, 6);
        Word twelve = new Word(93, 6);

        Word oclock = new Word(104, 6);

        protected Word[] _ChiffresHeures;
        protected List<Word[]> _ChiffresMinute;

        public TimeTranslaterEN()
        {
            _ChiffresHeures = new Word[] { twelve, one, two, three, four, fiveh, six, seven, eight, nine, tenh, eleven, twelve, one, two, three, four, fiveh, six, seven, eight, nine, tenh, eleven };

            _ChiffresMinute = new List<Word[]>();
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { fivem, past });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { tenm, past });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { quarter, past });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { twenty, past });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { twenty , fivem, past});
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { half, past });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { twenty, fivem, to});
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { twenty, to });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { quarter, to });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { tenm, to });
            for (int i = 0; i < 5; i++) _ChiffresMinute.Add(new Word[] { fivem, to });
        }

        public Word[] Translate(DateTime time)
        {
            List<Word> result = new List<Word>();
            result.Add(new Word(0, 2));    // it
            result.Add(new Word(3, 2));    // is

            if (time.IsSuperiorHalfAnHour()) time = time.AddHours(1);

            if (time.IsAm()) result.Add(am); else result.Add(pm);

            if (_ChiffresMinute[time.Minute].Length > 0)
                result.AddRange(_ChiffresMinute[time.Minute]);

            result.Add(_ChiffresHeures[time.Hour]);

            if (_ChiffresMinute[time.Minute].Length > 0)
                result.Add(oclock);

            return result.ToArray();
        }
    }
}
