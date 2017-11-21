using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AdventureWorks.Model
{
    public class DataAccessService : IDataAccessService
    {
        #region Member Data

        private AdventureWorksEntities entities = null;

        #endregion

        #region Constructor

        public DataAccessService()
            : this(null)
        {
        }

        public DataAccessService(AdventureWorksEntities repository)
        {
            this.entities = repository ?? new AdventureWorksEntities();
        }

        #endregion

        #region IDataAccessService Members

        public IEnumerable<Product> GetProductList()
        {
            var query = from p in entities.Products
                        select p;

            return query.ToList<Product>();
        }

        public IEnumerable<Product> GetProductList(string name)
        {
            var query = from p in entities.Products
                        where p.Name == name
                        select p;
            return query.ToList<Product>();
        }

        public IEnumerable<Product> GetProductList(decimal price)
        {
            var query = from p in entities.Products
                        where p.ListPrice <= price
                        select p;
            return query.ToList<Product>();
        }

        public IEnumerable<Product> GetProductList(int level)
        {
            var query = from p in entities.Products
                        where p.SafetyStockLevel <= level
                        select p;
            return query.ToList<Product>();
        }

        public IEnumerable<WorkOrder> GetWorkOrders(int id)
        {
            var query = from w in entities.WorkOrders
                        where w.ProductID == id
                        select w;
            return query.ToList<WorkOrder>();
        }

        public IEnumerable<WorkOrderRouting> GetWorkOrderRouting(int id)
        {
            var query = from r in entities.WorkOrderRoutings
                        where r.WorkOrderID == id
                        select r;
            return query.ToList<WorkOrderRouting>();
        }

        public IEnumerable<WorkOrder> CreateWorkOrder(WorkOrder record)
        {
            WorkOrder order = new WorkOrder()
            {
                WorkOrderID = this.GetNextWorkOrderId(),
                ProductID = record.ProductID,
                OrderQty = record.OrderQty,
                StockedQty = record.StockedQty,
                ScrappedQty = record.ScrappedQty,
                StartDate = record.StartDate,
                EndDate = record.EndDate,
                DueDate = record.DueDate,
                ModifiedDate = DateTime.Now
            };
            entities.AddToWorkOrders(order);

            try
            {
                entities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return GetWorkOrders(order.ProductID);
        }

        public IEnumerable<WorkOrder> UpdateWorkOrder(WorkOrder record)
        {
            // Find the work order.
            WorkOrder order = entities.WorkOrders.Single(o => o.WorkOrderID == record.WorkOrderID);

            // Update the work order.
            order.OrderQty = record.OrderQty;
            order.StockedQty = record.StockedQty;
            order.StartDate = record.StartDate;
            order.EndDate = record.EndDate;
            order.DueDate = record.DueDate;
            order.ModifiedDate = DateTime.Now;

            // Save changes.
            try
            {
                entities.SaveChanges();
            }
            catch (UpdateException ex)
            {
                // Report on referential integrity violations.
                string message = "Update Error";
                if (ex.InnerException != null)
                {
                    message += ": " + ex.InnerException.Message;
                }
                throw new InvalidOperationException(message);
            }
            catch (Exception)
            {
                throw;
            }
            return GetWorkOrders(record.ProductID);
        }

        public IEnumerable<WorkOrder> DeleteWorkOrder(WorkOrder record)
        {
            try
            {
                // Delete the work order.
                entities.DeleteObject(record);
                entities.SaveChanges();
            }
            catch (UpdateException ex)
            {
                // Report on referential integrity violations.
                string message = "Delete Error";
                if (ex.InnerException != null)
                {
                    message += ": " + ex.InnerException.Message;
                }
                throw new InvalidOperationException(message);
            }
            catch (Exception)
            {
                throw;
            }
            return GetWorkOrders(record.ProductID);
        }

        public void ServiceDispose()
        {
            this.entities.Dispose();
        }

        #endregion

        #region Private Methods

        private int GetNextWorkOrderId()
        {
            var query = from o in entities.WorkOrders
                        select o.WorkOrderID;
            int max = query.Max();
            return ++max;
        }

        #endregion
    }
}


