using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ContactLibrary
{
    public sealed class ContactModelProvider : IContactProvider
    {
        private readonly string _xmlFilePath;
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(List<ContactModel>));
        private List<ContactModel> _contactModelsList;

        #region Public

        public ContactModelProvider(string path)
        {
            _xmlFilePath = path + @"\contacts-storage.xml";

            if (!File.Exists(_xmlFilePath))
            {
                _contactModelsList = CreateCustomerXmlStub();
                PersistenceSave();
            }
            else
            {
                // if file presented
                using (var reader = new StreamReader(_xmlFilePath))
                {
                    _contactModelsList = (List<ContactModel>)_serializer.Deserialize(reader);
                }
            }
        }

        public IEnumerable<ContactModel> GetAllContactModels()
        {
            return _contactModelsList.OrderBy(model => model.Id).ToList();
        }

        public ContactModel GetContactModel(long id)
        {
            return _contactModelsList.Find(model => model.Id == id);
        }

        public void UpdateContactModel(long id, string newName, string newAddress, string newPhone)
        {
            var contactModel = _contactModelsList.First(model => model.Id == id);
            if (contactModel != null)
            {
                _contactModelsList.Remove(contactModel);
                ContactModel newModel = new ContactModel(id, newName, newAddress, newPhone);
                _contactModelsList.Add(newModel);
            }
        }

        public ContactModel AddContactModel(string name, string address, string phone)
        {
            long maxId;
            if (_contactModelsList.Count == 0)
            {
                maxId = 0;
            }
            else
            {
                maxId = _contactModelsList.Max(model => model.Id) + 1;
            }

            var contactModel = new ContactModel(maxId, name, address, phone);
            _contactModelsList.Add(contactModel);

            return contactModel;
        }

        public void RemoveContactModel(long id)
        {
            var contactModel = _contactModelsList.Find(model => model.Id == id);
            if (contactModel != null)
            {
                _contactModelsList.Remove(contactModel);
            }
        }

        public void ReloadFromPersistence()
        {
            // if file presented
            using (var reader = new StreamReader(_xmlFilePath))
            {
                _contactModelsList = (List<ContactModel>)_serializer.Deserialize(reader);
            }
        }

        public void PersistenceSave()
        {
            using (var writer = new StreamWriter(_xmlFilePath, false))
            {
                _serializer.Serialize(writer, _contactModelsList);
            }
        }

        #endregion

        private List<ContactModel> CreateCustomerXmlStub()
        {
            var firstContactStub = new ContactModel(1, "Joe", "Nowhere, TX1023", "123-456");
            return new List<ContactModel> { firstContactStub };
        }

    }
}
