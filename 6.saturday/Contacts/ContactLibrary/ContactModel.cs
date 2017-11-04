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
        // TODO: make set private and deal with serialization
        public Int64 Id { get; internal set; }
    
        public string Name { get; set; }

        public string Address { get; set;  }

        public string Phone { get; set;  }

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

