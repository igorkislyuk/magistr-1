using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactsLibrary.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string Phone { get; set; }
    }
}