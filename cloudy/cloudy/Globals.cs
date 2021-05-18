using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cloudy
{
    public class Weather : IComparable<Weather>
    {
        public string city { get; set; }
        public short day { get; set; }
        public string month { get; set; }
        public int temperature { get; set; }
        public string precipitation { get; set; }
        public uint pressure { get; set; }

        Dictionary<string, int> months = new Dictionary<string, int>()
        {
            { "", 0 },
            { "Січень", 1 },
            {"Лютий", 2 },
            { "Березень", 3 },
            { "Квітень", 4 },
            { "Травень", 5 },
            { "Червень", 6 },
            { "Липень", 7 },
            { "Серпень", 8 },
            { "Вересень", 9 },
            { "Жовтень", 10 },
            { "Листопад", 11 },
            { "Грудень", 12 }
        };

        public Weather(string city, short day, string month, int temp, string prec, uint pres)
        {
            this.city = city;
            this.day = day;
            this.month = month;
            this.temperature = temp;
            this.precipitation = prec;
            this.pressure = pres;
        }

        public int CompareTo(Weather other)
        {
            months.TryGetValue(this.month, out int f);
            months.TryGetValue(other.month, out int s);
            return (f - s) * 30 + (this.day - other.day);
        }
    }
}
