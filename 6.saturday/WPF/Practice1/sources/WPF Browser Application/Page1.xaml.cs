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

namespace WPF_Browser_Application
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fs = new System.IO.IsolatedStorage.IsolatedStorageFileStream("username.txt", System.IO.FileMode.Create);
            var sw = new System.IO.StreamWriter(fs);
            sw.WriteLine(textBox1.Text);
            sw.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var fs = new System.IO.IsolatedStorage.IsolatedStorageFileStream("username.txt", System.IO.FileMode.OpenOrCreate);
            var sr = new System.IO.StreamReader(fs);
            label1.Content = "Приветствую Вас, уважаемый " + sr.ReadToEnd();
            sr.Close();
        }
    }
}
