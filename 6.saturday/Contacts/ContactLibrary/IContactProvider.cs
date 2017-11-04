using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public interface IContactProvider
    {
    
        IEnumerable<ContactModel> GetAllContactModels();

        ContactModel GetContactModel(long id);

        void UpdateContactModel(long id, string newName, string newAddress, string newPhone);

        ContactModel AddContactModel(string name, string address, string phone);

        void RemoveContactModel(long id);

        void PersistenceSave();

        void ReloadFromPersistence();
    }
}
