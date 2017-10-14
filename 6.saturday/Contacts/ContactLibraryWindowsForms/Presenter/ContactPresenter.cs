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
        private readonly IContactView view;
        private readonly IContactProvider repository;

        public ContactPresenter(IContactView view, IContactProvider repository)
        {
            this.view = view;
            view.Presenter = this;

            this.repository = repository;

            UpdateContactList();
        }

        private void UpdateContactList()
        {
            var contactNames = from contact in repository.GetAllContactModels() select contact.Name;
            
            // zero or selected from view
            int selectedCustomer = view.SelectedContact >= 0 ? view.SelectedContact : 0;

            // update view
            view.ContactList = contactNames.ToList();
            view.SelectedContact = selectedCustomer;
        }

        public void UpdateContactView(int p)
        {
            var contact = repository.ContactModel(p);

            if (contact != null)
            {
                // update view
                view.ContactName = contact.Name;
                view.Address = contact.Address;
                view.Phone = contact.Phone;
            }
        }

        public void UpdateCustomer()
        {
            var currentSelectedContact = repository.ContactModel(view.SelectedContact);

            if (currentSelectedContact != null)
            {
                currentSelectedContact.Name = view.ContactName;
                currentSelectedContact.Address = view.Address;
                currentSelectedContact.Phone = view.Phone;

                repository.UpdateContact(currentSelectedContact.ID, currentSelectedContact);
            }
            
            UpdateContactList();
        }

        public void AddCustomer()
        {
            repository.AddContact(view.ContactName, view.Address, view.Phone);

            UpdateContactList();
        }

        //public void Remove
    }
}
