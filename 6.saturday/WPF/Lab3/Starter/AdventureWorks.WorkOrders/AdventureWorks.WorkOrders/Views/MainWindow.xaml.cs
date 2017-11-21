using System.Windows;
using System.Windows.Input;
using AdventureWorks.Model;
using AdventureWorks.WorkOrders.Views;

namespace AdventureWorks.WorkOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var model = new DataAccessService();
            DataContext = new MainWindowViewModel(model);
        }

        public MainWindowViewModel ViewModel
        {
            get { return this.DataContext as MainWindowViewModel; }
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ShowAboutBox();
        }

        private void allButtons_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.MouseCursor = Cursors.Wait;
            this.products.ItemsSource = this.ViewModel.GetAllProducts();
            this.ViewModel.MouseCursor = null;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void search_KeyUp(object sender, KeyEventArgs e)
        {
            searchButton.IsEnabled = search.Text.Length > 0;
        }
    }
}
