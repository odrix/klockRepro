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
        string[] ChiffresMinute = new string[] { "", "", "", "cinq", "cinq", "cinq", "cinq", "cinq", "huit", "neuf", "dix", "onze", "midi", "une", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze" };

        public string Translate(DateTime time)
        {
            string result = "";
            string nbHourInLetter = ChiffresHeures[time.Hour];
            string plurielHeure = time.Hour > 1 ? "s" : "";
            if (time.Hour == 12 || time.Hour == 0)
            {
                result = string.Format("il est {0}", nbHourInLetter);
            }
            else
            {
                result = string.Format("il est {0} heure{1}", nbHourInLetter, plurielHeure);
            }

            if(ChiffresMinute[time.Minute] != "")
                result += " " + ChiffresMinute[time.Minute];

            return result;
        }
    }
}
