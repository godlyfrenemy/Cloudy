using Microsoft.VisualStudio.TestTools.UnitTesting;
using cloudy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cloudy.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void SearchInfoTest()
        {
            List<Weather> expected = new List<Weather>()
            {
                new Weather("Суми", 4, "Січень", -8, "Є", 915),
                new Weather("Суми", 1, "Січень", -10, "Є", 920)
            };

            var target = new MainWindow();
            object sender = target;
            RoutedEventArgs e = null;

            target.MainWindow_Loaded(sender, e);

            DataAccess dataAccess = new DataAccess();
            List<Weather> actual = dataAccess.SelectXY("Суми", "Січень");

            for(int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].city, actual[i].city);
                Assert.AreEqual(expected[i].day, actual[i].day);
                Assert.AreEqual(expected[i].month, actual[i].month);
                Assert.AreEqual(expected[i].temperature, actual[i].temperature);
                Assert.AreEqual(expected[i].precipitation, actual[i].precipitation);
                Assert.AreEqual(expected[i].pressure, actual[i].pressure);
            }
        }

        [TestMethod()]
        public void CityListFillTest()
        {
            List<string> expected = new List<string>()
            {
                "Краснопілля",
                "Львів", 
                "Суми",
                "Київ"
            };

            var target = new MainWindow();
            object sender = target;
            RoutedEventArgs e = null;

            target.MainWindow_Loaded(sender, e);

            List<string> actual = MainWindow.cityList;
            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod()]
        public void SelectRainDataTest()
        {
            List<Weather> expected = new List<Weather>()
            {
                new Weather("Краснопілля", 8, "Січень", 1, "Є", 900),
                new Weather("Львів", 5, "Лютий", 1, "Є", 900)
            };

            var target = new MainWindow();
            object sender = target;
            RoutedEventArgs e = null;

            target.MainWindow_Loaded(sender, e);

            DataAccess dataAccess = new DataAccess();
            List<Weather> actual = dataAccess.GetRainData();

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i].city, actual[i].city);
                Assert.AreEqual(expected[i].day, actual[i].day);
                Assert.AreEqual(expected[i].month, actual[i].month);
                Assert.AreEqual(expected[i].temperature, actual[i].temperature);
                Assert.AreEqual(expected[i].precipitation, actual[i].precipitation);
                Assert.AreEqual(expected[i].pressure, actual[i].pressure);
            }
        }
    }
}