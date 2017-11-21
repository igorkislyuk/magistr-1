using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AdventureWorks.Model
{
    public partial class WorkOrder : IDataErrorInfo
    {
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "OrderQty")
                {
                    if (this._OrderQty <= 0)
                    {
                        return "Order Quantity cannot be less than or equal to 0.";
                    }
                }
                if (columnName == "StockedQty")
                {
                    if (this._StockedQty <= 0)
                    {
                        return "Stock Quantity cannot be less than or equal to 0.";
                    }
                    if (this._StockedQty != this._OrderQty)
                    {
                        return "Stock Quantity must be the same value as " +
                               "Order Quantity.";
                    }
                }
                if (columnName == "StartDate")
                {
                    if (this._StartDate < DateTime.Today)
                    {
                        return string.Format(
                            "Start Date cannot be before {0:MM/dd/yyyy}.", DateTime.Today);
                    }
                }
                if (columnName == "EndDate")
                {
                    if (this._EndDate < this._StartDate)
                    {
                        return string.Format(
                            "End Date cannot be before {0:MM/dd/yyyy}.", this._StartDate);
                    }
                }
                if (columnName == "DueDate")
                {
                    if (this._DueDate < this._StartDate)
                    {
                        return string.Format(
                            "Due Date cannot be before {0:MM/dd/yyyy}.", this._StartDate);
                    }
                }
                return null;
            }
        }
    }
}