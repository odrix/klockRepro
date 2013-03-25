using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public class TimeTranslater
    {
        string[] ChiffresHeures = new string[] { "minuit", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "midi", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze"};
        List<string> ChiffresMinute;

        public TimeTranslater()
        {
            ChiffresMinute = new List<string>();
            
            for(int i=0;i<3;i++) ChiffresMinute.Add("");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("cinq");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("dix");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("et quart");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("vingt");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("vingt-cinq");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("et demi");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins vingt-cinq");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins vingt");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins le quart");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins dix");
            for (int i = 0; i < 5; i++) ChiffresMinute.Add("moins cinq");
            for (int i = 0; i < 2; i++) ChiffresMinute.Add("");
        }

        public string Translate(DateTime time)
        {
            StringBuilder result = new StringBuilder("il est");

            if (IsSuperiorHalf(time)) time = time.AddHours(1);

            result.AppendFormat(" {0}", ChiffresHeures[time.Hour]);
            if (IsHourNeedHourLabel(time))
            {
                result.Append(" heure");
                if(time.Hour > 1) result.Append("s");
            }

            if(ChiffresMinute[time.Minute] != "")
                result.AppendFormat(" {0}", ChiffresMinute[time.Minute]);

            return result.ToString();
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
