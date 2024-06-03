using Supermarket.Controls;
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

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UsersControl();
        }
        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
           // contentControl.Content = new CategoriesView(); // Aici poți utiliza un UserControl sau altă componentă specifică pentru Categories
        }
        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ProductControl(); 
        }
        private void ProducersButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ProducerControl();

        }
        private void StocksButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new StockControl();

        }
        private void ProducerProduct_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ProducerProductsReport();
        }
        private void CategoriesTotalAmount_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new CategoryProductsTotalAmount();
        }
        private void UserTotalAmount_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new UserTotalAmount();
        }
        private void LargestReceipt_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new LargestReceipt();
        }
    }
}
