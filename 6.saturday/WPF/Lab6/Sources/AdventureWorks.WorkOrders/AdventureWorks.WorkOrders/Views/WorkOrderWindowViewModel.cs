using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using AdventureWorks.Model;

namespace AdventureWorks.WorkOrders.Views
{
    public sealed class WorkOrderWindowViewModel: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private WorkOrder _order;
        public WorkOrder Order
        {
            get => this._order;
            set
            {
                if (_order == value) return;

                _order = value;
                OnPropertyChanged("Order");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
