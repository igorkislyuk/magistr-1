using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{
    public sealed class ContactModel
    {
        public int ID { get; set; }
    
        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public ContactModel(int id)
        {
            ID = id;
        }

        private ContactModel() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ContactModel);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode()
                ^ Address.GetHashCode()
                ^ Phone.GetHashCode();
        }

        public bool Equals(ContactModel other)
        {
            if (other == null)
                return false;

            return this.Name == other.Name
                && this.Address == other.Address
                && this.Phone == other.Phone;
        }
    }
}
