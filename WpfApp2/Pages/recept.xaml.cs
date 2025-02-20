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
    /// Логика взаимодействия для recept.xaml
    /// </summary>
    public partial class recept : Page
    {
       

        

        public recept()
        {
            InitializeComponent();
            Prod.ItemsSource = AppDate.AppConnect.model1.Recipes.ToList();
            filtr.Items.Add("Время");
            filtr.Items.Add("по возрастанию");
            filtr.Items.Add("по убыванию");
            filtr.SelectedIndex = 0;

            vidRecept.SelectedIndex = 0;
            var category = AppConnect.model1.Categories;
            vidRecept.Items.Add("Категория");
            foreach( var item in category )
            {
                vidRecept.Items.Add(item.CategoryName);
            }
                
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prod.ItemsSource = Findtime();
        }

        private void ComboFilterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Prod.ItemsSource = Findtime();
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Prod.ItemsSource = Findtime();
        }
        Recipes[] Findtime()
        {
            var time = AppConnect.model1.Recipes.ToList();
            var timeall = time;
            if (txttxt != null)
            {
                time = time.Where(x => x.RecipeName.ToLower().Contains(txttxt.Text.ToLower())).ToList();
            }
            if (vidRecept.SelectedIndex > 0)
            {
                
                        time = time.Where(x => x.CategoryID==vidRecept.SelectedIndex).ToList();
                        
                
            }
            if (filtr.SelectedIndex > 0)
            {
                switch (filtr.SelectedIndex)
                {
                    case 1:
                        time = time.OrderBy(x => x.CookingTime).ToList(); break;
                    case 2:
                        time = time.OrderByDescending(x => x.CookingTime).ToList();
                        break;
                }

            }
            return time.ToArray();
        }

        private void Prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
