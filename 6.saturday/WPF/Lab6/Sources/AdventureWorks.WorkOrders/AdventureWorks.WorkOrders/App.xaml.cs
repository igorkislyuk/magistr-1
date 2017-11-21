using System;
using System.Diagnostics;
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
        #region Member Data

        private EventLog log;
        private bool unhandledException = false;

        #endregion

        #region Constructor

        public App()
        {
            log = new EventLog();
            log.Source = "AdventureWorks";
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        #endregion

        #region Application Entry Point

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();
            var dataService = new DataAccessService();
            window.DataContext = new MainWindowViewModel(dataService, window);
            window.Show();
        }

        #endregion

        #region Private Methods

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            this.HandleUnhandledException(e.ExceptionObject as Exception);
            this.unhandledException = true;
        }

        private void HandleUnhandledException(Exception target)
        {
            log.WriteEntry(string.Format("{0}\n{1}", target.Message, target.StackTrace));

            if (false == unhandledException)
            {
                CustomExceptionView view = new CustomExceptionView();
                view.Owner = Application.Current.MainWindow;
                view.ViewModel.Message = target.Message;
                view.ShowDialog();
            }
        }

        #endregion
    }
}
