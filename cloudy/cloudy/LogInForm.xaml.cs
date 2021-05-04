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

namespace cloudy
{
    /// <summary>
    /// Логика взаимодействия для LogInForm.xaml
    /// </summary>
    public partial class LogInForm : Window
    {

        public LogInForm()
        {
            InitializeComponent();  
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.authorization.loged_in = MainWindow.authorization.CheckLogIn(login.Text.Trim(), password.Password.Trim());
            if (MainWindow.authorization.loged_in)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль", "Помилка!");
            }
        }
    }
}
