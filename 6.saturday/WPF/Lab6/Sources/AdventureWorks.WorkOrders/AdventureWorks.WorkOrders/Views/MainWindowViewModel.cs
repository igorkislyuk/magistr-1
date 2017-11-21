using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using AdventureWorks.Model;
using AdventureWorks.WorkOrders.Commands;

namespace AdventureWorks.WorkOrders.Views
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Member Data

        private IDataAccessService das = null;
        private bool isBusy;
        private bool isCreateWorkOrderEnabled = true;
        private bool isDeleteWorkOrderEnabled = false;
        private bool isEditWorkOrderEnabled = false;
        private bool isSearchButtonEnabled;
        private Cursor mouseCursor;
        private IEnumerable<Product> products;
        private MainWindow view;
        private IEnumerable<WorkOrderRouting> workOrderRoutings;

        private RelayCommand aboutBoxCommand;
        private RelayCommand allProductsCommand;
        private RelayCommand closeCommand;
        private RelayCommand changeSkinCommand;
        private RelayCommand createWorkOrderCommand;
        private RelayCommand searchProductsCommand;

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
        {
            this.das = dataService;
            this.view = view;
        }

        #endregion

        #region Properties

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            private set
            {
                this.isBusy = value;
                this.OnPropertyChanged("IsBusy");
            }
        }

        public bool IsCreateWorkOrderEnabled
        {
            get
            {
                return this.isCreateWorkOrderEnabled;
            }
        }

        public bool IsDeleteWorkOrderEnabled
        {
            get
            {
                return this.isDeleteWorkOrderEnabled;
            }
        }

        public bool IsEditWorkOrderEnabled
        {
            get
            {
                return this.isEditWorkOrderEnabled;
            }
        }

        public bool IsSearchButtonEnabled
        {
            get
            {
                return this.isSearchButtonEnabled;
            }
            set
            {
                this.isSearchButtonEnabled = value;
                this.OnPropertyChanged("IsSearchButtonEnabled");
            }
        }

        public Cursor MouseCursor
        {
            get
            {
                return this.mouseCursor;
            }
            private set
            {
                this.mouseCursor = value;
                this.OnPropertyChanged("MouseCursor");
            }
        }

        public IEnumerable<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public IEnumerable<WorkOrderRouting> WorkOrderRoutings
        {
            get
            {
                return this.workOrderRoutings;
            }
        }

        #endregion

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (this.das != null)
            {
                this.das.ServiceDispose();
            }
        }

        #endregion

        #region Commands

        public ICommand AboutBoxCommand
        {
            get
            {
                if (this.aboutBoxCommand == null)
                {
                    this.aboutBoxCommand = new RelayCommand(param => this.ShowAboutBox());
                }
                return this.aboutBoxCommand;
            }
        }

        public ICommand AllProductsCommand
        {
            get
            {
                if (this.allProductsCommand == null)
                {
                    this.allProductsCommand = new RelayCommand(param => this.GetAllProducts());
                }
                return this.allProductsCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                {
                    this.closeCommand = new RelayCommand(param => Application.Current.Shutdown());
                }
                return this.closeCommand;
            }
        }

        public ICommand ChangeSkinCommand
        {
            get
            {
                if (this.changeSkinCommand == null)
                {
                    this.changeSkinCommand = new RelayCommand(param => this.ChangeSkin(param));
                }
                return this.changeSkinCommand;
            }
        }

        public ICommand CreateWorkOrderCommand
        {
            get
            {
                if (this.createWorkOrderCommand == null)
                {
                    this.createWorkOrderCommand = new RelayCommand(param => this.CreateWorkOrder(param));
                }
                return this.createWorkOrderCommand;
            }
        }

        public ICommand SearchProductsCommand
        {
            get
            {
                if (this.searchProductsCommand == null)
                {
                    this.searchProductsCommand = new RelayCommand(param => this.SearchProducts(param));
                }
                return this.searchProductsCommand;
            }
        }

        #endregion

        #region Helper Methods

        protected virtual void ChangeSkin(object param)
        {
            ResourceDictionary dict = Application.Current.Resources.MergedDictionaries[0];

            if (param.Equals("Shiny"))
            {
                dict.Source = new Uri("pack://application:,,,/AdventureWorks.Resources;component/Themes/ShinyBlue.xaml");
            }
            else
            {
                dict.Source = new Uri("pack://application:,,,/AdventureWorks.Resources;component/Themes/BureauBlue.xaml");
            }
        }

        private void CreateWorkOrder(object param)
        {
            WorkOrder workOrder = new WorkOrder()
            {
                OrderQty = 1,
                StockedQty = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                DueDate = DateTime.Now
            };
            WorkOrderWindow order = new WorkOrderWindow(); order.Owner = Application.Current.MainWindow; order.ViewModel.Order = workOrder; order.ShowDialog();
        }

        protected void GetAllProducts()
        {
            this.MouseCursor = Cursors.Wait;
            this.IsBusy = true;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                this.products = das.GetProductList();
                this.workOrderRoutings = das.GetWorkOrderRouting(13);
            };
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetAllProductsWorker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        protected virtual void GetAllProductsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.IsBusy = false;
            this.MouseCursor = null;
            this.OnPropertyChanged("Products");
            this.OnPropertyChanged("WorkOrderRoutings");
        }

        protected void GetWorkOrderRoutings(int id)
        {
            this.MouseCursor = Cursors.Wait;
            this.IsBusy = true;

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                this.workOrderRoutings = das.GetWorkOrderRouting(id);
            };
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GetWorkOrderRoutingsWorker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        protected virtual void GetWorkOrderRoutingsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.IsBusy = false;
            this.MouseCursor = null;
            this.OnPropertyChanged("WorkOrderRoutings");
        }

        protected void SearchProducts(object param)
        {
            this.MouseCursor = Cursors.Wait;
            this.IsBusy = true;

            string[] parameters = ((string)param).Split(':');
            string searchField = parameters[2].Trim();
            BackgroundWorker worker = new BackgroundWorker();

            switch (searchField)
            {
                case "Maximum List Price":
                    decimal maxListPrice = Convert.ToDecimal(parameters[0]);
                    worker.DoWork += (object sender, DoWorkEventArgs e) =>
                    {
                        this.products = das.GetProductList(maxListPrice);
                    };
                    break;
                case "Stock Level":
                    int stockLevel = Convert.ToInt32(parameters[0]);
                    worker.DoWork += (object sender, DoWorkEventArgs e) =>
                    {
                        this.products = das.GetProductList(stockLevel);
                    };
                    break;
                case "Name:":
                default:
                    string productName = parameters[0];
                    worker.DoWork += (object sender, DoWorkEventArgs e) =>
                    {
                        this.products = das.GetProductList(productName);
                    };

                    break;
            }

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(SearchProductsWorker_RunWorkerCompleted);
            worker.RunWorkerAsync();
        }

        protected virtual void SearchProductsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.IsBusy = false;
            this.MouseCursor = null;
            this.OnPropertyChanged("Products");
        }

        protected virtual void ShowAboutBox()
        {
            AboutWindow about = new AboutWindow();
            about.Owner = Application.Current.MainWindow;
            about.ShowDialog();
        }

        #endregion

    }
}
