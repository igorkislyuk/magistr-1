using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ContactLibrary;

namespace ContactLibraryWPF.ViewModel
{
    public class MainWindowViewModel
    {
        private IContactProvider _provider;

        public ObservableCollection<ContactModel> Contacts { get; private set; }

        public ContactModel SelectedContact { get; set; }

        public MainWindowViewModel()
        {
            Debug.Print(AppDomain.CurrentDomain.BaseDirectory);
            _provider = new ContactModelProvider(System.AppDomain.CurrentDomain.BaseDirectory);

            Contacts = new ObservableCollection<ContactModel>(_provider.GetAllContactModels());
        }

        public void AddContact()
        {
            var generatedName = $"Name #{Contacts.Count}";
            var model = _provider.AddContactModel(generatedName, "No address", "No phone");
            Contacts.Add(model);
            Contacts.OrderBy(m => m.Id);

            Save();
        }

        public void DeleteContact()
        {
            if (SelectedContact != null)
            {
                _provider.RemoveContactModel(SelectedContact.Id);

                Save();

                var contact = Contacts.First(c => c.Id == SelectedContact.Id);

                if (contact != null)
                {
                    Contacts.Remove(contact);
                }
                else
                {
                    Debug.Print("No contact to delete. Null");
                }
            }
            else
            {
                Debug.Print("Failed to delete");
            }
        }

        private void Save()
        {
            _provider.PersistenceSave();
        }

        public void Reload()
        {
            _provider.ReloadFromPersistence();
            Contacts.Clear();
            foreach (var model in _provider.GetAllContactModels())
            {
                Debug.Print(model.Name);
                Contacts.Add(model);
            }
            Contacts.OrderBy(m => m.Id);
        }
    }
}