using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AdventureWorks.WorkOrders.Utilities;

namespace AdventureWorks.WorkOrders.Views
{
    /// <summary>
    /// Interaction logic for WorkOrderWindow.xaml
    /// </summary>
    public partial class WorkOrderWindow : Window
    {
        public WorkOrderWindow()
        {
            this.ViewModel = new WorkOrderWindowViewModel();
            InitializeComponent();
        }

        public WorkOrderWindowViewModel ViewModel
        {
            get { return this.DataContext as WorkOrderWindowViewModel; }
            set { this.DataContext = value; }
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (UserInterfaceUtilities.ValidateVisualTree(this) == true)
            {
                this.DialogResult = true;
            }
        }
    }


}
