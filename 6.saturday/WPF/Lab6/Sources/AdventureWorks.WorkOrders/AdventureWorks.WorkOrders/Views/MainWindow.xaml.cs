using System.Windows;

namespace AdventureWorks.WorkOrders.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindowViewModel ViewModel
        {
            get { return this.DataContext as MainWindowViewModel; }
        }

        #region Protected Methods

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.ViewModel.Dispose();
        }

        #endregion

        #region Event Handlers

        private void search_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.ViewModel.IsSearchButtonEnabled = (this.search.Text.Length > 0) ? true : false;
        }

        private void workOrders_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        #endregion
    }
}
