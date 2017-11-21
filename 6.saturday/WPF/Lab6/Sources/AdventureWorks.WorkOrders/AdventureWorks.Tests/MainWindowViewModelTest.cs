using System.Threading;
using System.Windows.Input;
using AdventureWorks.Model;
using AdventureWorks.Tests.Mocks;
using AdventureWorks.WorkOrders.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventureWorks.Tests
{
    [TestClass]
    public class MainWindowViewModelTest
    {
        #region Member Data

        private MainWindowViewModel mainWindowViewModel;
        private MockDataAccessService mockService;
        private ManualResetEvent waitHandle;
        private TestableMainWindowViewModel tvm;

        #endregion

        #region Test Initialization and Cleanup

        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.mainWindowViewModel = new MainWindowViewModel();
            this.mockService = new MockDataAccessService();
            this.waitHandle = new ManualResetEvent(false);
            this.tvm = new TestableMainWindowViewModel(mockService, waitHandle);
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeShutdown();
            this.tvm.Dispose();
            this.mainWindowViewModel.Dispose();
        }

        #endregion

        #region Command Tests

        [TestMethod]
        public void AboutBoxCommandTest()
        {
            ICommand aboutBoxCommand = this.mainWindowViewModel.AboutBoxCommand;
            Assert.IsNotNull(aboutBoxCommand, "AboutBox command should not be null");
        }

        [TestMethod]
        public void AllProductsCommandTest()
        {
            ICommand allProductsCommand = this.mainWindowViewModel.AllProductsCommand;
            Assert.IsNotNull(allProductsCommand, "AllProducts command should not be null");
        }

        [TestMethod]
        public void ChangeSkinCommandTest()
        {
            ICommand changeSkinCommand = this.mainWindowViewModel.ChangeSkinCommand;
            Assert.IsNotNull(changeSkinCommand, "ChangeSkin command should not be null");
        }

        [TestMethod]
        public void CloseCommandTest()
        {
            ICommand closeCommand = this.mainWindowViewModel.CloseCommand;
            Assert.IsNotNull(closeCommand, "Close command should not be null");
        }

        [TestMethod]
        public void SearchProductsCommandTest()
        {
            ICommand searchProductsCommand = this.mainWindowViewModel.SearchProductsCommand;
            Assert.IsNotNull(searchProductsCommand, "SearchProducts command should not be null");
        }

        #endregion

        #region Helper Method Tests

        [TestMethod]
        public void AboutBoxTest()
        {
            tvm.CallShowAboutBox();
            Assert.AreEqual(tvm.WasShowAboutBoxCalled, true, "ShowAboutBox was not called");
        }

        [TestMethod]
        public void ChangeSkinTest()
        {
            tvm.CallChangeSkin("Shiny");
            Assert.AreEqual(tvm.WasChangeSkinCalled, true, "ChangeSkin was not called");
        }

        [TestMethod]
        public void GetProductsMouseCursorTest()
        {
            tvm.CallGetProducts();
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.IsNull(tvm.MouseCursor, "Mouse cursor should be null");
        }

        [TestMethod]
        public void GetSearchProductsWorkerCompletedTest()
        {
            tvm.CallSearchProducts("32.0:ComboBoxItem:Maximum List Price");
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.IsFalse(tvm.IsBusy, "IsBusy should be false");
        }

        [TestMethod]
        public void ProductsTest()
        {
            tvm.CallGetProducts();
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.AreEqual(mockService.WasGetProductsCalled, true, "GetProducts was not called");
        }

        [TestMethod]
        public void SearchButtonEnabledPropertyTest()
        {
            this.mainWindowViewModel.IsSearchButtonEnabled = true;
            Assert.AreEqual(true, this.mainWindowViewModel.IsSearchButtonEnabled, "Search button should be enabled");

            this.mainWindowViewModel.IsSearchButtonEnabled = false;
            Assert.AreEqual(false, this.mainWindowViewModel.IsSearchButtonEnabled, "Search button should be disabled");
        }

        [TestMethod]
        public void SearchProductsTest()
        {
            tvm.CallSearchProducts("32.0:ComboBoxItem:Maximum List Price");
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.IsNotNull(tvm.Products, "Products should not be null");
        }

        [TestMethod]
        public void SearchProductsByNameTest()
        {
            tvm.CallSearchProducts("Chain:ComboBoxItem:Name");
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.AreEqual(mockService.WasGetProductsCalled, true, "GetProducts was not called");
        }

        [TestMethod]
        public void SearchProductsByPriceTest()
        {
            tvm.CallSearchProducts("32.0:ComboBoxItem:Maximum List Price");
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.AreEqual(mockService.WasGetProductsCalled, true, "GetProducts was not called");
        }

        [TestMethod]
        public void SearchProductsByStockLevelTest()
        {
            tvm.CallSearchProducts("50:ComboBoxItem:Stock Level");
            Assert.IsTrue(waitHandle.WaitOne(1000));
            Assert.AreEqual(mockService.WasGetProductsCalled, true, "GetProducts was not called");
        }

        #endregion
    }

    internal class TestableMainWindowViewModel : MainWindowViewModel
    {
        #region Member Data

        private ManualResetEvent waitHandle;
        private bool wasChangeSkinCalled;
        private bool wasShowAboutBoxCalled;

        #endregion

        #region Constructor

        public TestableMainWindowViewModel(IDataAccessService dataService, ManualResetEvent waitHandle)
            : base(dataService)
        {
            this.waitHandle = waitHandle;
        }

        #endregion

        #region Properties

        public bool WasChangeSkinCalled
        {
            get
            {
                return this.wasChangeSkinCalled;
            }
        }

        public bool WasShowAboutBoxCalled
        {
            get
            {
                return this.wasShowAboutBoxCalled;
            }
        }

        #endregion

        #region Public Methods

        public void CallChangeSkin(object param)
        {
            this.ChangeSkin(param);
        }

        public void CallGetProducts()
        {
            base.GetAllProducts();
        }

        public void CallSearchProducts(object param)
        {
            base.SearchProducts(param);
        }

        public void CallShowAboutBox()
        {
            this.ShowAboutBox();
        }

        #endregion

        #region Protected Methods

        protected override void ChangeSkin(object param)
        {
            this.wasChangeSkinCalled = true;
        }

        protected override void GetAllProductsWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            base.GetAllProductsWorker_RunWorkerCompleted(sender, e);
            this.waitHandle.Set();
        }

        protected override void SearchProductsWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            base.SearchProductsWorker_RunWorkerCompleted(sender, e);
            this.waitHandle.Set();
        }

        protected override void ShowAboutBox()
        {
            this.wasShowAboutBoxCalled = true;
        }

        #endregion
    }
}
