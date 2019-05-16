using ShopApp.DataAccess;
using System.Windows;
using System.Windows.Controls;

namespace ShopApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBoxSelected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem.Name == "Buyers")
            {
                var data = new BuyerTableDataService().GetAll();
                itemsGrid.ItemsSource = data;
            }
            else if (selectedItem.Name == "Sellers")
            {
                var data = new SellerTableDataService().GetAll();
                itemsGrid.ItemsSource = data;
            }
            else
            {
                var data = new SaleTableDataService().GetAll();
                itemsGrid.ItemsSource = data;
            }
        }
    }
}