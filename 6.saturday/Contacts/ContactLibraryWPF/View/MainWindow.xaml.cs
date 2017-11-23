using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ContactLibraryWPF.ViewModel;

namespace ContactLibraryWPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        public MainWindowViewModel ViewModel => DataContext as MainWindowViewModel;

        private void AddClick(object sender, RoutedEventArgs e)
        {
            ViewModel.AddContact();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteContact();
        }

        private void ContactDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.SelectedContact != null)
            {
                var detailWindow = new DetailWindow(ViewModel.SelectedContact);
                detailWindow.Show();
                detailWindow.OnUpdated += () => ViewModel.Reload();
            }
            else
            {
                Debug.Print("Cannot open null contact");
            }

            
        }
    }
}
