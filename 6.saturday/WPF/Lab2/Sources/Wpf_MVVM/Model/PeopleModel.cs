using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_MVVM.Model
{
    class PeopleModel: INotifyPropertyChanged
    {
        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Fields

        private string _firstName;
        private string _lastName;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set first name.
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value) return;

                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }


        /// <summary>
        /// Get or set last name.
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value) return;

                _lastName = value;
                OnPropertyChanged("FirstName");
            }
        }

        #endregion
    }
}
