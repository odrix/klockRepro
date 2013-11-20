using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klockRepro.Business
{
    public static class DateTimeExt
    {
        public static bool IsMidnigthOrMidday(this DateTime time)
        {
            return time.Hour != 12 && time.Hour != 0;
        }

        public static bool IsSuperiorHalfAnHour(this DateTime time)
        {
            return time.Minute > 30;
        }

        public static bool IsAm(this DateTime time)
        {
            return time.Hour <= 12;
        }

    }
}
