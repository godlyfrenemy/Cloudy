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
        private List<Weather> selectXYList { get; set; }
        private List<Weather> rainDataList { get; set; }

        private Weather selectedWeather { get; set; }
        private DataAccess dataAccess = new DataAccess();
        private string buttonPressed;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadBase();
        }

        private void DisplayList(List<Weather> list)
        {
            WeatherTable.Items.Clear();

            foreach(Weather element in list)
            {
                WeatherTable.Items.Add(element);
            }
        }

        private bool LoadBase()
        {
            try
            {
                List<Weather> result = dataAccess.GetWeathers();
                ClearList();

                if (result == null)
                {
                    MessageBox.Show("База даних порожня", "Увага!");
                }
                else
                {
                    foreach (Weather element in result)
                    {
                        AddToList(element);
                    }
                }
                WeatherTable.SelectedItem = null;

                return true;
            }
            catch
            {
                MessageBox.Show("Не вдалось прочитати базу даних", "Помилка!");
                return false;
            }
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

        private void ClearBoxes()
        {
            city_box.Text = String.Empty;
            day_box.Text = String.Empty;
            month_box.Text = String.Empty;
            precip_box.Text = String.Empty;
            pressure_box.Text = String.Empty;
            temp_box.Text = String.Empty;
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
                MessageBox.Show("Не вдалось додати запис", "Помилка!");
                return false;
            }
        }

        private bool DeleteFromList(Weather weather)
        {
            try
            {
                if (dataAccess.DeleteFromBase(weather))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Не вдалось видалити запис з бази даних", "Помилка!");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Не вдалось видалити запис", "Помилка!");
                return false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(buttonPressed == (string)EditButton.Content)
                {
                    throw new Exception("Увімкнутий режим редагування");
                }
                Weather weather = new Weather(city_box.Text, Convert.ToInt16(day_box.Text), month_box.Text, Convert.ToInt16(temp_box.Text), precip_box.Text, Convert.ToUInt32(pressure_box.Text));

                int result = dataAccess.AddToBase(weather);
                if (result == 1)
                {
                    LoadBase();
                    ClearBoxes();
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
                MessageBox.Show(ex.Message, "Помилка");
            }
               
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (buttonPressed == (string)EditButton.Content)
                {
                    buttonPressed = String.Empty;
                    DeleteFromList(selectedWeather); 
                    AddButton_Click(sender, e);
                }
                else
                {
                    AddButton_Click(sender, e);
                }
                ClearBoxes();
                WeatherTable.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Не вдалось зберегти запис", "Помилка!");
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buttonPressed = (string)EditButton.Content;

                selectedWeather = (Weather)WeatherTable.SelectedItem;

                if(selectedWeather == null)
                {
                    throw new Exception();
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
                MessageBox.Show("Ви не обрали запис", "Помилка!");
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

                DeleteFromList(selectedWeather);

                LoadBase();
                ClearBoxes();
                WeatherTable.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("Ви не обрали запис", "Помилка!");
            }

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectXYList = dataAccess.SelectXY(city_x.Text, month_y.Text);
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
                MessageBox.Show(ex.Message, "Помилка!");
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
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
    }
}
