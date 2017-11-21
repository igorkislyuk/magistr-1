using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using AdventureWorks.Model;
using System.Windows;

namespace AdventureWorks.WorkOrders.Views
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Member Data

        private IDataAccessService das = null;
        private Cursor mouseCursor;
        private MainWindow view;

        #endregion

        #region Constructor

        public MainWindowViewModel()
            : this(null)
        {
        }

        public MainWindowViewModel(IDataAccessService dataService)
            : this(dataService, null)
        {
        }

        public MainWindowViewModel(IDataAccessService dataService, MainWindow view)
            : base()
        {
            this.das = dataService;
            this.view = view;
        }

        #endregion

        #region Properties

        public Cursor MouseCursor
        {
            get
            {
                return this.mouseCursor;
            }
            set
            {
                this.mouseCursor = value;
                this.OnPropertyChanged("MouseCursor");
            }
        }

        #endregion

        #region Public Methods

        public IEnumerable<Product> GetAllProducts()
        {
            return das.GetProductList();
        }

        public void ShowAboutBox()
        {
            AboutWindow about = new AboutWindow();
            about.Owner = Application.Current.MainWindow;
            about.ShowDialog();
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
