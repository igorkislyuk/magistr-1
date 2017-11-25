using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactsLibrary.Models
{
    public class ContactContext: DbContext
    {
        public ContactContext() : base("ContactContext")
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}