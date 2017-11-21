using System.Windows;
using AdventureWorks.Model;
using AdventureWorks.WorkOrders.Views;

namespace AdventureWorks.WorkOrders
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();
            var dataService = new DataAccessService();
            window.DataContext = new MainWindowViewModel(dataService, window);
            window.Show();
        }      
    }
}
