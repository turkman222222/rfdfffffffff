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
using WpfApp2.AppDate;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для autoriz.xaml
    /// </summary>
    public partial class autoriz : Page
    {
        public autoriz()
        {
            InitializeComponent();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            reg reg = new reg();
            NavigationService.Navigate(reg);
        }

        private void btnAutoriz_Click(object sender, RoutedEventArgs e)
        {
            var user_object = AppDate.AppConnect.model1.Authors.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == passBoxpassword.Password);
            if (user_object == null)
            {
                MessageBox.Show("Ошибка авторизации","не знаем", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Привет" + user_object.Authorname + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppConnect.AuthorID = user_object.AuthorID;
                recept regg = new recept();
                NavigationService.Navigate(regg);
            }
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
