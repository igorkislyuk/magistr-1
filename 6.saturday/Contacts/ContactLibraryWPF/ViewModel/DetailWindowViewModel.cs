using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLibrary;

namespace ContactLibraryWPF.ViewModel
{
    public class DetailWindowViewModel
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        private ContactModel _model;

        private IContactProvider _provider = new ContactModelProvider(AppDomain.CurrentDomain.BaseDirectory);

        public DetailWindowViewModel(ContactModel model)
        {
            _model = model;
            Name = model.Name;
            Phone = model.Phone;
            Address = model.Address;
        }

        public void SaveCurrentValues()
        {
            _provider.UpdateContactModel(_model.Id, Name, Address, Phone);
            _provider.PersistenceSave();
        }
    }
}