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
        public int day { get; set; }
        public string month { get; set; }
        public int temperature { get; set; }
        public string precipitation { get; set; }
        public uint pressure { get; set; }

        public Weather(string city, string day, string month, string temp, string prec, string pres)
        {
            this.city = city;
            this.day = Convert.ToInt32(day);
            this.month = month;
            this.temperature = Convert.ToInt32(temp);
            this.precipitation = prec;
            this.pressure = Convert.ToUInt32(pres);
        }

        public Weather(string city, int day, int month, int temp, string prec, uint pres)
        {
            this.city = city;
            this.day = day;
            this.month = new DateTime(2010, month, 1).ToString("MMMM");
            this.temperature = temp;
            this.precipitation = prec;
            this.pressure = pres;
        }
    }
}
