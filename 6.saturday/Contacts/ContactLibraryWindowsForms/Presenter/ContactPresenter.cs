using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            get => _contactModels;
            set
            {
                _contactModels = value;

                // save and reupdate selected index
                var selectedContact = _view.SelectedContact;

                _view.ContactList = value.Select(model => model.Name).ToList();

                // does not provide selection for zero items
                if (value.Count == 0)
                {
                    return;
                }

                if (selectedContact < value.Count && selectedContact > 0)
                {
                    _view.SelectedContact = selectedContact;
                }
                else
                {
                    _view.SelectedContact = 0;
                }
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

            // update view for non zero selection
            if (models.Length != 0)
            {
                _view.SelectedContact = selectedContact;
            }
        }

        public void UpdateContactView(int p)
        {
            var id = GetIdFromSelectedIndex(p);

            if (id == null)
            {
                return;
            }

            var contactModel = _repository.GetContactModel(id.Value);

            if (contactModel == null)
            {
                return;
            }

            // update view
            _view.ContactName = contactModel.Name;
            _view.Address = contactModel.Address;
            _view.Phone = contactModel.Phone;
        }

        public void UpdateContactModel()
        {
            var id = GetIdFromSelectedIndex(_view.SelectedContact);

            if (id == null)
            {
                return;
            }

            var contactModel = _repository.GetContactModel(id.Value);

            if (contactModel == null)
            {
                return;
            }

            _repository.UpdateContactModel(contactModel.Id, _view.ContactName, _view.Address, _view.Phone);

            UpdateContactList(false);
        }

        public void AddCustomer()
        {
            _repository.AddContactModel("No name", "No address", "No phone");

            UpdateContactList(true);
        }

        internal void RemoveSelected()
        {
            var id = GetIdFromSelectedIndex(_view.SelectedContact);

            if (id == null) return;

            var contactModel = _repository.GetContactModel(id.Value);

            if (contactModel == null)
            {
                return;
            }

            _repository.RemoveContactModel(contactModel.Id);
            UpdateContactList(false);
        }

        private long? GetIdFromSelectedIndex(int index)
        {
            if (index < 0 || index >= ContactModels.Count)
            {
                return null;
            }

            var localContactModel = ContactModels[index];

            return localContactModel == null ? null : _repository.GetContactModel(localContactModel.Id)?.Id;
        }

        public void Save()
        {
            _repository.PersistenceSave();
        }

    }
}