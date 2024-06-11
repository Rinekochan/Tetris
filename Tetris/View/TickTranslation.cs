using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.View
{
    public static class TickTranslation // this static class translate ticks to hour:minute:second fortmat
    {
        public static string TickToString(int ticks)
        {
            int hour = ticks / 3600000 % 60;
            int minute = ticks / 60000 % 60;
            int second = ticks / 1000 % 60;

            string hourString = hour.ToString();
            string minuteString = minute.ToString();
            string secondString = second.ToString();

            if(hourString.Length == 1) hourString = "0" + hourString;
            if(minuteString.Length == 1) minuteString = "0" + minuteString;
            if(secondString.Length == 1) secondString = "0" + secondString;

            return $"{hourString}:{minuteString}:{secondString}";
        }

        public static string TickToString(uint ticks)
        {
            uint hour = ticks / 3600000 % 60;
            uint minute = ticks / 60000 % 60;
            uint second = ticks / 1000 % 60;

            string hourString = hour.ToString();
            string minuteString = minute.ToString();
            string secondString = second.ToString();

            if (hourString.Length == 1) hourString = "0" + hourString;
            if (minuteString.Length == 1) minuteString = "0" + minuteString;
            if (secondString.Length == 1) secondString = "0" + secondString;

            return $"{hourString}:{minuteString}:{secondString}";
        }
    }
}
