using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLibrary;

namespace ContactLibraryWindowsForms
{
    public class ContactPresenter
    {
        private readonly IContactView _view;
        private readonly IContactProvider _repository;

        public ContactPresenter(IContactView view, IContactProvider repository)
        {
            this._view = view;
            view.Presenter = this;

            this._repository = repository;

            UpdateContactList();
        }

        private void UpdateContactList()
        {
            var contactNames = _repository.GetAllContactModels().Select(contact => contact.Name);

            // zero or selected from view
            var selectedCustomer = 0;

            if (_view.SelectedContact >= 0 && _view.SelectedContact < _repository.GetAllContactModels().Count())
            {
                selectedCustomer = _view.SelectedContact;
            }
            else
            {
                selectedCustomer = 0;
            }

            // update view
            _view.ContactList = contactNames.ToList();
            _view.SelectedContact = selectedCustomer;
        }

        public void UpdateContactView(int p)
        {
            var contact = _repository.ContactModel(p);

            if (contact != null)
            {
                // update view
                _view.ContactName = contact.Name;
                _view.Address = contact.Address;
                _view.Phone = contact.Phone;
            }
        }

        public void UpdateCustomer()
        {
            var currentSelectedContact = _repository.ContactModel(_view.SelectedContact);

            if (currentSelectedContact != null)
            {
                currentSelectedContact.Name = _view.ContactName;
                currentSelectedContact.Address = _view.Address;
                currentSelectedContact.Phone = _view.Phone;

                _repository.UpdateContact(currentSelectedContact.ID, currentSelectedContact);
            }

            UpdateContactList();
        }

        public void AddCustomer()
        {
            _repository.AddContact(_view.ContactName, _view.Address, _view.Phone);

            UpdateContactList();
        }

        internal void RemoveSelected()
        {
            _repository.RemoveModel(_view.SelectedContact);

            UpdateContactList();
        }
    }
}