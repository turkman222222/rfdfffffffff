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
    /// Логика взаимодействия для Addpage.xaml
    /// </summary>
    public partial class Addpage : Page
    {
        private Recipes _currentRecipes = new Recipes();
        public Addpage()
        {
            InitializeComponent();
            LoadAuthors();
            LoadCategories();
            DataContext = _currentRecipes;


        }
        public Addpage(Recipes currentRecipes)
        {
            InitializeComponent();

            if (_currentRecipes != null)
                this._currentRecipes = currentRecipes;

            LoadAuthors();
            LoadCategories();

            DataContext = currentRecipes;

            //txtAuthorName.ItemsSource = AppData.AppConnect.modelDB.Authors.ToList();
            //txtAuthorName.DisplayMemberPath = "AuthorName";

            //txtCategoriesName.ItemsSource = AppData.AppConnect.modelDB.Categories.ToList();
            //txtCategoriesName.DisplayMemberPath = "CategoryName";

        }
        private void LoadAuthors()
        {
            var authors = AppConnect.model1.Authors;
            txtAuthorName.Items.Add("Авторы");
            foreach (var auth in authors)
            {
                txtAuthorName.Items.Add(auth.Authorname);
            }
            //txtAuthorName.ItemsSource = authors;
            //txtAuthorName.DisplayMemberPath = "Authorname";
        }
        private void LoadCategories()
        {
            var categories = AppConnect.model1.Categories;
            txtCategoriesName.Items.Add("Категория");
            foreach (var auth in categories)
            {
                txtCategoriesName.Items.Add(auth.CategoryName);
            }
            //txtCategoriesName.ItemsSource = categories;
            //txtCategoriesName.DisplayMemberPath = "CategoryName";
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void text03_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (_currentRecipes.RecipeID == 0)
                {
                    _currentRecipes.CategoryID = AppConnect.model1.Categories.FirstOrDefault(x => x.CategoryName == txtCategoriesName.Text).CategoryID;
                    _currentRecipes.AuthorID = AppConnect.model1.Authors.FirstOrDefault(x => x.Authorname == txtAuthorName.Text).AuthorID;
                    AppConnect.model1.Recipes.Add(_currentRecipes);
                }

                AppConnect.model1.SaveChanges();
                //this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recept addpagerep = new recept();
            AppFrame.frmMane2.Navigate(addpagerep);
        }
    }
}
