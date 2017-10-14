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

        ContactModel ContactModel(int id);

        void UpdateContact(int id, ContactModel updatedModel);

        int AddContact(string name, string address, string phone);

        void RemoveModel(int id);
    }
}
