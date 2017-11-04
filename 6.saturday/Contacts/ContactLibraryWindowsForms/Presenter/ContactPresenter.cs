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

        private IList<ContactModel> _contactModels;
        private IList<ContactModel> ContactModels
        {
            set
            {
                _contactModels = value;
                _view.ContactList = value.Select(model => model.Name).ToList();
            }
        }

        public ContactPresenter(IContactView view, IContactProvider repository)
        {
            this._view = view;
            view.Presenter = this;

            this._repository = repository;

            UpdateContactList(false);
        }

        private void UpdateContactList(bool incrementSelection)
        {
            var models = _repository.GetAllContactModels().ToArray();
            ContactModels = models;

            // zero or selected from view
            int selectedContact;

            if (_view.SelectedContact >= 0 && _view.SelectedContact < models.Length)
            {
                selectedContact = _view.SelectedContact;

                // proceed to next selection
                if (incrementSelection && selectedContact + 1 < models.Length)
                {
                    selectedContact += 1;
                }
            }
            else
            {
                selectedContact = 0;
            }

            // update view
            _view.SelectedContact = selectedContact;
        }

        public void UpdateContactView(int p)
        {
            var contactModel = _repository.GetContactModel(p + 1);

            if (contactModel == null) return;
            
            // update view
            _view.ContactName = contactModel.Name;
            _view.Address = contactModel.Address;
            _view.Phone = contactModel.Phone;
        }

        public void UpdateContactModel()
        {
            var currentSelectedContact = _repository.GetContactModel(_view.SelectedContact);

            if (currentSelectedContact != null)
            {
                _repository.UpdateContactModel(currentSelectedContact.Id, _view.ContactName, _view.Address, _view.Phone);
            }

            UpdateContactList(false);
        }

        public void AddCustomer()
        {
            _repository.AddContactModel("No name", "No address", "No phone");

            UpdateContactList(true);
        }

        internal void RemoveSelected()
        {
            _repository.RemoveContactModel(_view.SelectedContact + 1);

            UpdateContactList(false);
        }
    }
}