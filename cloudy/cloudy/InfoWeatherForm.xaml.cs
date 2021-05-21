using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace cloudy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Authorization authorization = new Authorization();

        private List<Weather> weathers { get; set; }
        private List<Weather> selectXYList { get; set; }
        private List<Weather> rainDataList { get; set; }

        private SelectData selectData = new SelectData();
        private Weather selectedWeather { get; set; }
        private DataAccess dataAccess = new DataAccess();

        public static List<string> cityList = new List<string>();
        public static string selectedCity = String.Empty;
        public static string selectedMonth = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        public static void ErrorShow(string Message, string Header)
        {
            MessageBox.Show(Message, Header, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ToggleDisplay()
        {
            EditForm.Visibility = (EditForm.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
            UserForm.Visibility = (UserForm.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void ClearList()
        {
            weathers = new List<Weather> { };
            WeatherTable.Items.Clear();
        }

        private void ClearEditForm()
        {
            city_box.Text = String.Empty;
            day_box.Text = String.Empty;
            month_box.Text = String.Empty;
            precip_box.Text = String.Empty;
            pressure_box.Text = String.Empty;
            temp_box.Text = String.Empty;
        }

        private bool UserInputOk()
        {
            return !String.IsNullOrWhiteSpace(city_box.Text) && !String.IsNullOrWhiteSpace(day_box.Text) &&
                !String.IsNullOrWhiteSpace(month_box.Text) && !String.IsNullOrWhiteSpace(temp_box.Text) &&
                !String.IsNullOrWhiteSpace(precip_box.Text) && !String.IsNullOrWhiteSpace(pressure_box.Text) &&
                Convert.ToInt32(pressure_box.Text) > 650 && Convert.ToInt32(pressure_box.Text) < 800 &&
                Convert.ToInt32(temp_box.Text) > -60 && Convert.ToInt32(temp_box.Text) < 50;
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Show();
            LoadBase();

            for (int i = 1; i <= 31; i++)
            {
                day_box.Items.Add(Convert.ToString(i));
            }
        }

        private void DisplayList(List<Weather> list)
        {
            WeatherTable.Items.Clear();

            foreach(Weather element in list)
            {
                WeatherTable.Items.Add(element);
            }
        }

        public bool LoadBase()
        {
            try
            {
                List<Weather> result = dataAccess.GetWeathers();
                ClearList();
                ClearEditForm();
                city_x.Items.Clear();
                cityList.Clear();

                if (result == null)
                {
                    ErrorShow("База даних порожня", "Увага!");
                }
                else
                {
                    foreach (Weather element in result)
                    {
                        AddToList(element);
                        if (!city_x.Items.Contains(element.city))
                        {
                            city_x.Items.Add(element.city);
                            cityList.Add(element.city);
                        }
                    }
                }
                WeatherTable.SelectedItem = null;

                return true;
            }
            catch
            {
                ErrorShow("Не вдалось прочитати базу даних", "Помилка!");
                return false;
            }
        }

        private bool AddToList(Weather weather)
        {
            try
            {
                WeatherTable.Items.Add(weather);
                weathers.Add(weather);

                return true;
            }
            catch
            {
                ErrorShow("Не вдалось додати запис", "Помилка!");
                return false;
            }
        }

        private bool DeleteWeather(Weather weather)
        {
            try
            {
                if (dataAccess.DeleteFromBase(weather))
                {
                    return true;
                }
                else
                {
                    ErrorShow("Не вдалось видалити запис з бази даних", "Помилка!");
                    return false;
                }
            }
            catch
            {
                ErrorShow("Не вдалось видалити запис", "Помилка!");
                return false;
            }
        }

        private void AddWeather()
        {
            try
            {
                Weather weather = new Weather(city_box.Text, Convert.ToInt16(day_box.Text), month_box.Text, Convert.ToInt16(temp_box.Text), precip_box.Text, Convert.ToUInt32(pressure_box.Text));

                int result = dataAccess.AddToBase(weather);
                if (result == 1)
                {
                    LoadBase();
                    ClearEditForm();
                }
                else if(result == 0)
                {
                    throw new Exception("Не вдалось додати запис");
                }
                else
                {
                    throw new Exception("Записи на цю дату в даному місті вже існують");
                }
            }
            catch(Exception ex)
            {
                ErrorShow(ex.Message, "Помилка");
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!UserInputOk())
                {
                    throw new Exception("Неправильні вхідні дані");
                }
                if(WeatherTable.SelectedItem == null)
                {
                    AddWeather();
                }
                else
                {
                    if(DeleteWeather(selectedWeather))
                    {
                        AddWeather();
                    }
                    else
                    {
                        throw new Exception("Не вдалось відредагувати запис");
                    }
                }
                ClearEditForm();
                WeatherTable.SelectedItem = null;
            }
            catch (Exception ex)
            {
                ErrorShow(ex.Message, "Помилка");
            }
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedWeather = (Weather)WeatherTable.SelectedItem;
                if (selectedWeather == null)
                {
                    throw new Exception();
                }

                DeleteWeather(selectedWeather);

                LoadBase();
                ClearEditForm();
                WeatherTable.SelectedItem = null;
            }
            catch
            {
                ErrorShow("Ви не обрали запис", "Помилка!");
            }

        }

        public void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedCity = city_x.Text;
                selectedMonth = month_y.Text;

                if(String.IsNullOrEmpty(selectedCity) || String.IsNullOrEmpty(selectedMonth))
                {
                    throw new Exception("Неправильні вхідні дані");
                }
                selectXYList = dataAccess.SelectXY(selectedCity, selectedMonth);
                if(selectXYList == null)
                {
                    throw new Exception("Жодного запису не знайдено");
                }
                else
                {
                    ClearList();
                    city_x.Text = String.Empty;
                    month_y.Text = String.Empty;

                    DisplayList(selectXYList);
                }
            }
            catch(Exception ex)
            {
                ErrorShow(ex.Message, "Помилка");
            }
        }

        private void SearchRainButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rainDataList = dataAccess.GetRainData();

                if (rainDataList == null)
                {
                    throw new Exception("Жодного запису не знайдено");
                }
                else
                {
                    DisplayList(rainDataList);
                }
            }
            catch (Exception ex)
            {
                ErrorShow(ex.Message, "Помилка");
            }
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectXYList == null)
                {
                    throw new Exception("Здійсніть спочатку пошук записів за містом та місяцем, або оберіть потрібні місто та місяць");
                }
                if (rainDataList == null)
                {
                    rainDataList = dataAccess.GetRainData();
                }
                if(selectData.WriteData(selectXYList, rainDataList))
                {
                    MessageBox.Show("Інформація була успішно записана");
                }
            }
            catch (Exception ex)
            {
                ErrorShow(ex.Message, "Помилка");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadBase();      
        }

        private void WeatherTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedWeather = (Weather)WeatherTable.SelectedItem;

                if (selectedWeather == null)
                {
                    ClearEditForm();
                    return;
                }

                city_box.Text = selectedWeather.city.Trim();
                day_box.Text = Convert.ToString(selectedWeather.day).Trim();
                month_box.Text = selectedWeather.month;
                temp_box.Text = Convert.ToString(selectedWeather.temperature).Trim();
                precip_box.Text = selectedWeather.precipitation.Trim();
                pressure_box.Text = Convert.ToString(selectedWeather.pressure).Trim();
            }
            catch
            {
                ErrorShow("Ви не обрали запис", "Помилка!");
            }
        }

        private void ChartButton_Click(object sender, RoutedEventArgs e)
        {
            Chart chart = new Chart(weathers);
            chart.Show();
        }
    }
}
