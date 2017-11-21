using System;
using System.Collections.Generic;
using AdventureWorks.Model;

namespace AdventureWorks.Tests.Mocks
{
    public class MockDataAccessService : IDataAccessService
    {
        #region Member Data

        private List<Product> products;
        private bool wasGetProductsCalled;

        #endregion

        #region Constructor

        public MockDataAccessService()
        {
            this.products = new List<Product>();
            this.CreateProducts();
        }

        #endregion

        #region Properties

        public bool WasGetProductsCalled
        {
            get
            {
                return this.wasGetProductsCalled;
            }
        }

        #endregion

        #region Data Creation

        private void CreateProducts()
        {
            Product product1 = new Product()
            {
                ProductID = 1,
                Name = "Adjustable Race",
                ProductNumber = "AR-5381",
                MakeFlag = false,
                FinishedGoodsFlag = false,
                Color = null,
                SafetyStockLevel = 1000,
                ReorderPoint = 750,
                StandardCost = 0.00M,
                ListPrice = 0.00M,
                Size = null,
                SizeUnitMeasureCode = null,
                WeightUnitMeasureCode = null,
                Weight = null,
                DaysToManufacture = 0,
                ProductLine = null,
                Class = null,
                Style = null,
                ProductSubcategoryID = null,
                ProductModelID = null,
                SellStartDate = DateTime.Parse("1998-06-01 00:00:00.000"),
                SellEndDate = null,
                DiscontinuedDate = null,
                rowguid = Guid.Parse("694215B7-08F7-4C0D-ACB1-D734BA44C0C8"),
                ModifiedDate = DateTime.Parse("2004-03-11 10:01:36.827")
            };
            this.products.Add(product1);

            Product product2 = new Product()
            {
                ProductID = 1,
                Name = "Bearing Ball",
                ProductNumber = "BA-8327",
                MakeFlag = false,
                FinishedGoodsFlag = false,
                Color = null,
                SafetyStockLevel = 1000,
                ReorderPoint = 750,
                StandardCost = 0.00M,
                ListPrice = 0.00M,
                Size = null,
                SizeUnitMeasureCode = null,
                WeightUnitMeasureCode = null,
                Weight = null,
                DaysToManufacture = 0,
                ProductLine = null,
                Class = null,
                Style = null,
                ProductSubcategoryID = null,
                ProductModelID = null,
                SellStartDate = DateTime.Parse("1998-06-01 00:00:00.000"),
                SellEndDate = null,
                DiscontinuedDate = null,
                rowguid = Guid.Parse("58AE3C20-4F3A-4749-A7D4-D568806CC537"),
                ModifiedDate = DateTime.Parse("2004-03-11 10:01:36.827")
            };
            this.products.Add(product2);

            Product product3 = new Product()
            {
                ProductID = 1,
                Name = "BB Ball Bearing",
                ProductNumber = "BE-2349",
                MakeFlag = true,
                FinishedGoodsFlag = false,
                Color = null,
                SafetyStockLevel = 800,
                ReorderPoint = 600,
                StandardCost = 0.00M,
                ListPrice = 0.00M,
                Size = null,
                SizeUnitMeasureCode = null,
                WeightUnitMeasureCode = null,
                Weight = null,
                DaysToManufacture = 1,
                ProductLine = null,
                Class = null,
                Style = null,
                ProductSubcategoryID = null,
                ProductModelID = null,
                SellStartDate = DateTime.Parse("1998-06-01 00:00:00.000"),
                SellEndDate = null,
                DiscontinuedDate = null,
                rowguid = Guid.Parse("9C21AED2-5BFA-4F18-BCB8-F11638DC2E4E"),
                ModifiedDate = DateTime.Parse("2004-03-11 10:01:36.827")
            };
            this.products.Add(product3);
        }

        #endregion

        #region IDataAccessService Members

        public IEnumerable<Product> GetProductList()
        {
            this.wasGetProductsCalled = true;
            return this.products;
        }

        public IEnumerable<Product> GetProductList(string name)
        {
            this.wasGetProductsCalled = true;
            return this.products;
        }

        public IEnumerable<Product> GetProductList(decimal price)
        {
            this.wasGetProductsCalled = true;
            return this.products;
        }

        public IEnumerable<Product> GetProductList(int level)
        {
            this.wasGetProductsCalled = true;
            return this.products;
        }

        public IEnumerable<WorkOrder> GetWorkOrders(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrderRouting> GetWorkOrderRouting(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrder> CreateWorkOrder(WorkOrder record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrder> UpdateWorkOrder(WorkOrder record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkOrder> DeleteWorkOrder(WorkOrder record)
        {
            throw new NotImplementedException();
        }

        public void ServiceDispose()
        {
            this.products = null;
        }

        #endregion
    }
}
