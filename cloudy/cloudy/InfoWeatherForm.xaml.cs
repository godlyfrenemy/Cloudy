using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cloudy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Authorization authorization = new Authorization();
        private List<Weather> weathers;

        public void ToggleDisplay()
        {
            EditForm.Visibility = (EditForm.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            LogInButton.Visibility = (LogInButton.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void AddToList(Weather weather)
        {
            WeatherTable.Items.Add(weather);
            weathers.Add(weather);
        }

        public MainWindow()
        {
            InitializeComponent();
            weathers = new List<Weather>
            {
                new Weather("Краснопілля", DateTime.Now.Day, DateTime.Now.Month, 15, "Есть", 920),
                new Weather("Суми", DateTime.Now.Day, DateTime.Now.Month, 16, "Есть", 900),
                new Weather("Бездрик", DateTime.Now.Day, DateTime.Now.Month, 17, "Есть", 910),
                new Weather("Київ", DateTime.Now.Day, DateTime.Now.Month, 10, "Нету", 920),
                new Weather("Харків", DateTime.Now.Day, DateTime.Now.Month, 15, "Есть", 920)
            };
            foreach(var element in weathers)
            {
                WeatherTable.Items.Add(element);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddToList(new Weather(city_box.Text, day_box.Text, month_box.Text, temp_box.Text, precip_box.Text, pressure_box.Text));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void WeatherTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            LogInForm logInForm = new LogInForm();
            logInForm.ShowDialog();
            if(MainWindow.authorization.loged_in)
            {
                ToggleDisplay();
            }
        }
    }
}
