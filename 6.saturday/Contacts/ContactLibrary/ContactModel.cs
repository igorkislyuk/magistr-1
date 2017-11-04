using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary
{

    public sealed class ContactModel
    {
        public Int64 Id { get; }
    
        public string Name { get; }

        public string Address { get; }

        public string Phone { get; }

        internal ContactModel(Int64 id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        private ContactModel() { }

        public override bool Equals(object obj)
        {
            return Equals(obj as ContactModel);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(ContactModel other)
        {
            return Id == other?.Id;
        }

    }
}

