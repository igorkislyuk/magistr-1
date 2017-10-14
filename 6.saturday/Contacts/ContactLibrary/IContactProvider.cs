using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public interface IContactProvider
    {
        /// <summary>
        /// All current presented models
        /// </summary>
        /// <returns></returns>
        IEnumerable<ContactModel> GetAllContactModels();

        /// <summary>
        /// Retrieve contact model from repository
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ContactModel ContactModel(int id);

        /// <summary>
        /// Update element by id in repository
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedModel"></param>
        void UpdateContact(int id, ContactModel updatedModel);

        int AddContact(string name, string address, string phone);

        void RemoveModel(int id);
    }
}
