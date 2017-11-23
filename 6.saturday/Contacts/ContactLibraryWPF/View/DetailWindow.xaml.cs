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
using ContactLibrary;
using ContactLibraryWPF.ViewModel;

namespace ContactLibraryWPF.View
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        public delegate void Updater();

        public event Updater OnUpdated;

        public DetailWindowViewModel ViewModel => DataContext as DetailWindowViewModel;

        public DetailWindow(ContactModel model)
        {
            InitializeComponent();

            DataContext = new DetailWindowViewModel(model);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveCurrentValues();
            OnUpdated?.Invoke();
            Close();
        }
    }
}
