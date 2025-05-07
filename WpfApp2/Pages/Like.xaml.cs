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
    /// Логика взаимодействия для Like.xaml
    /// </summary>
    public partial class Like : Page
    {
        public Like()
        {
            InitializeComponent();
            UpdateLikeRecipes();
        }

        private void UpdateLikeRecipes()
        {
            // Получение списка ID понравившихся рецептов текущего автора
            var likeRecipes = AppConnect.model1.LikeRecipes.Where(x =>
    x.authorID == AppConnect.AuthorID).Select(x => x.idRecipes).ToList();
            // Получение списка рецептов по найденным ID
            recept = AppConnect.model1.Recipes.Where(x =>
    likeRecipes.Contains(x.RecipeID)).ToList();
            // Установка источника данных для списка продуктов
            listProducts.ItemsSource = recept;
        }

    }
}
