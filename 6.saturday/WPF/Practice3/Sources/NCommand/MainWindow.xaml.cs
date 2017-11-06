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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NCommand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var binding = new CommandBinding {Command = CustomCommands.Launch};
            binding.Executed += Launch_Handler;
            binding.CanExecute += new CanExecuteRoutedEventHandler(LaunchEnabled_Handler);

            CommandBindings.Add(binding);
        }

        private void Launch_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Launch invoked");
        }

        private void LaunchEnabled_Handler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = checkBox1.IsChecked ?? false;
        }
    }
}
