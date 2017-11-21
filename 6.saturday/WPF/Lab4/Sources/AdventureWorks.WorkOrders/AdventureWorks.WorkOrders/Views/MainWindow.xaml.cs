using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace AdventureWorks.WorkOrders.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int Count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Properties

        public MainWindowViewModel ViewModel
        {
            get { return this.DataContext as MainWindowViewModel; }
        }

        #endregion

        #region Event Handlers

        private void about_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ShowAboutBox();
        }

        private void allProducts_Click(object sender, RoutedEventArgs e)
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
            Count++;
            Debug.Print(string.Format("{0}. {1}KeyUp", Count, sender.GetType().Name));
            this.searchButton.IsEnabled = (this.search.Text.Length > 0) ? true : false;
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.Print(string.Format("{0}. {1}KeyUp", ++Count,
                sender.GetType().Name));
        }

        #endregion
    }
}