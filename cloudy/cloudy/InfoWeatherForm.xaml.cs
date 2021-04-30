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
        private List<Weather> weathers { get; set; }

        private DataAccess dataAccess;

        public MainWindow()
        {
            InitializeComponent();
            dataAccess = new DataAccess();

            weathers = new List<Weather> { };
            List<Weather> result = dataAccess.GetWeathers();

            if(result == null)
            {
                MessageBox.Show("Empty");
            }
            else
            {
                foreach (Weather element in result)
                {
                    AddToList(element);
                }
            }
        }

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

        private void ClearBoxes()
        {
            city_box.Text = String.Empty;
            day_box.Text = String.Empty;
            month_box.Text = String.Empty;
            precip_box.Text = String.Empty;
            pressure_box.Text = String.Empty;
            temp_box.Text = String.Empty;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather(city_box.Text, Convert.ToInt16(day_box.Text), month_box.Text, Convert.ToInt16(temp_box.Text), precip_box.Text, Convert.ToUInt32(pressure_box.Text));
            if (!dataAccess.AddToBase(weather))
            {
                MessageBox.Show("Wasn't added");
            }
            else
            {
                AddToList(weather);

                ClearBoxes();
            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ClearBoxes();
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //List<Weather> result = dataAccess.GetWeathers("Суми", "Січень");
            //if(result == null)
            //{
            //    MessageBox.Show("Error");
            //}
            //else
            //{
            //    weathers.Clear();
            //    WeatherTable.Items.Clear();
            //    foreach (Weather element in result)
            //    {
            //        AddToList(element);
            //    }
            //}
        }
    }
}
