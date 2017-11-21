using System.Windows;
using System.Windows.Automation;
using AdventureWorks.WorkOrders.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventureWorks.Tests
{
    [TestClass]
    public class MainWindowViewTest
    {
        #region Member Data

        private MainWindow mainWindow;
        private MainWindowViewModel mainWindowViewModel;
        private AutomationElement appWindow;

        #endregion

        #region Test Initialization and Cleanup

        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.mainWindow = new MainWindow();
            this.mainWindowViewModel = new MainWindowViewModel();
            this.mainWindow.DataContext = this.mainWindowViewModel;
            this.mainWindow.Show();

            // Retrieve the application window.
            System.Windows.Automation.Condition windowNameCond = new PropertyCondition(AutomationElement.NameProperty, "AdventureWorks Cycles Work Orders");
            appWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, windowNameCond);
            Assert.IsNotNull(appWindow, "An element with the name 'AdventureWorks Cycles Work Orders' could not be found.");
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.mainWindow.Close();
            System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeShutdown();
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void PasteMenuItemDisabledTest()
        {
            Clipboard.Clear();

            // Retrieve the Edit menu element.
            AutomationElement editMenu = appWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "EditMenu"));
            Assert.IsNotNull(editMenu, "An element with AutomationID 'EditMenu' could not be found.");

            // Expand the edit menu to generate menu items.
            ExpandCollapsePattern editMenuPattern = editMenu.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            editMenuPattern.Expand();

            // Retrieve the Paste menu item.
            AutomationElement pasteItem = editMenu.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "EditMenuPasteItem"));
            Assert.IsNotNull(pasteItem, "An element with AutomationID 'EditMenuPasteItem' could not be found.");

            // Collapse the edit menu.
            editMenuPattern.Collapse();

            // Verify that the paste menu item is disabled.
            Assert.AreEqual<bool>(false, (bool)pasteItem.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty), "PasteItem menu item should be disabled");
        }

        [TestMethod]
        public void PasteMenuItemEnabledTest()
        {
            Clipboard.SetText("Adventure Works");

            // Retrieve the Edit menu element.
            AutomationElement editMenu = appWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "EditMenu"));
            Assert.IsNotNull(editMenu, "An element with AutomationID 'EditMenu' could not be found.");

            // Expand the edit menu to generate menu items.
            ExpandCollapsePattern editMenuPattern = editMenu.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            editMenuPattern.Expand();

            // Retrieve the Paste menu item.
            AutomationElement pasteItem = editMenu.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "EditMenuPasteItem"));
            Assert.IsNotNull(pasteItem, "An element with AutomationID 'EditMenuPasteItem' could not be found.");

            // Collapse the edit menu.
            editMenuPattern.Collapse();

            // Verify that the paste menu item is enabled.
            Assert.AreEqual<bool>(true, (bool)pasteItem.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty), "PasteItem menu item should be enabled");
        }

        [TestMethod]
        public void SearchProductsDisabledTest()
        {
            // Retrieve the button.
            AutomationElement searchProductsButton = appWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "SearchProductsButton"));
            Assert.IsNotNull(searchProductsButton, "An element with AutomationID 'SearchProductsButton' could not be found.");

            // Verify that the button is disabled.
            Assert.AreEqual<bool>(false, (bool)searchProductsButton.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty), "SearchProducts button should be disabled");
        }

        [TestMethod]
        public void SearchProductsEnabledTest()
        {
            this.mainWindowViewModel.IsSearchButtonEnabled = true;

            // Retrieve the button.
            AutomationElement searchProductsButton = appWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "SearchProductsButton"));
            Assert.IsNotNull(searchProductsButton, "An element with AutomationID 'SearchProductsButton' could not be found.");

            // Verify that the button is enabled.
            Assert.AreEqual<bool>(true, (bool)searchProductsButton.GetCurrentPropertyValue(AutomationElement.IsEnabledProperty), "SearchProducts button should be enabled");
        }

        [TestMethod]
        public void TextEntryTest()
        {
            // Retrieve the textbox by AutomationID.
            AutomationElement textBox = appWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "SearchTextBox"));
            Assert.IsNotNull(textBox, "An element with AutomationID 'SearchTextBox' could not be found.");

            TextPattern textPattern = textBox.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
            ValuePattern valuePattern = textBox.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;

            valuePattern.SetValue("Adventure Works");

            Assert.AreEqual<string>(textPattern.DocumentRange.GetText(-1), "Adventure Works", "TextBox content is not equal to Adventure Works");
        }

        [TestMethod]
        public void WindowResizeTest()
        {
            TransformPattern transformPattern = appWindow.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
            transformPattern.Move(0, 0);
            transformPattern.Resize(400, 400);
            Assert.AreEqual<Rect>(new Rect(0, 0, 400, 400), appWindow.Current.BoundingRectangle, "Window has not been resized to 400 x 400");
        }

        #endregion
    }
}
