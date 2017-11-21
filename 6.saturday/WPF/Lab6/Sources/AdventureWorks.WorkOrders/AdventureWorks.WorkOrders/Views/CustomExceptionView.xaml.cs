using System.Windows;

namespace AdventureWorks.WorkOrders.Views
{
    /// <summary>
    /// Interaction logic for CustomExceptionView.xaml
    /// </summary>
    public partial class CustomExceptionView : Window
    {
        public CustomExceptionView()
        {
            this.ViewModel = new CustomExceptionViewModel();
            InitializeComponent();
        }

        public CustomExceptionViewModel ViewModel
        {
            get { return this.DataContext as CustomExceptionViewModel; }
            set { this.DataContext = value;  }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
