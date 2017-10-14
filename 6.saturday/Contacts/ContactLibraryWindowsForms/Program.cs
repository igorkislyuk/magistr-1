using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactLibraryWindowsForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = new ContactLibrary.ContactModelProvider(Application.StartupPath);
            var view = new ContactLibraryMainForm();

            var presenter = new ContactPresenter(view, repository);

            Application.Run(view);
        }
    }
}
