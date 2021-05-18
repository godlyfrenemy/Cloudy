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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace cloudy
{
    /// <summary>
    /// Логика взаимодействия для Chart.xaml
    /// </summary>

    public partial class Chart : Window
    {
        public List<Weather> weathers { get; set; } = new List<Weather>();
        public List<Weather> current { get; set; } = new List<Weather>();

        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection() { };
        public List<string> Labels { get; set; } = new List<string>();
        public Func<double, string> Formatter { get; set; }
        public ChartValues<int> values { get; set; } = new ChartValues<int>();

        public Chart(List<Weather> weathers)
        {
            InitializeComponent();
            this.weathers = weathers;
            SeriesCollection.Add(new LineSeries() { Title = "", Values = values });
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        private void ChartForm_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < weathers.Count; i++)
            {
                if (!cityList.Items.Contains(weathers[i].city))
                {
                    cityList.Items.Add(weathers[i].city);
                }
            }
        }

        private void cityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            current = weathers.FindAll(x => x.city == cityList.SelectedItem.ToString());
            current.Sort();

            ChangeChart();
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(cityList.SelectedItem != null)
            {
                ChangeChart();
            }
        }

        private void ChangeChart()
        {
            SeriesCollection.Clear();
            Labels.Clear();
            values.Clear();

            foreach (Weather element in current)
            {
                values.Add(temperature.IsChecked == true ? element.temperature : Convert.ToInt32(element.pressure));
                Labels.Add(Convert.ToString(element.day) + " " + element.month.Substring(0, 3));
            }

            SeriesCollection.Add(new LineSeries() { Title = current[0].city, Values = values });
            Formatter = value => value.ToString("N");

            DataContext = this;
        }
    }
}
