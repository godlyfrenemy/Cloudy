using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudy
{
    class Weather
    {
        public string city { get; set; }
        public short day { get; set; }
        public string month { get; set; }
        public int temperature { get; set; }
        public string precipitation { get; set; }
        public uint pressure { get; set; }

        public Weather(string city, short day, string month, int temp, string prec, uint pres)
        {
            this.city = city;
            this.day = day;
            this.month = month;
            this.temperature = temp;
            this.precipitation = prec;
            this.pressure = pres;
        }
    }
}
