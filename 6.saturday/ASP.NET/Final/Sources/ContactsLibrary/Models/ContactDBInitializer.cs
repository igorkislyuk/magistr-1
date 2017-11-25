using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactsLibrary.Models
{
    public class ContactDBInitializer: DropCreateDatabaseIfModelChanges<ContactContext>
    {
        protected override void Seed(ContactContext context)
        {
            // enabled only once
            context.Contacts.Add(new ContactModel()
            {
                Id = 1,
                Name = "Igor",
                Address = "SPb, Russia",
                Phone = "+ 7 911 748-60-02"
            });

            context.Contacts.Add(new ContactModel()
            {
                Id = 2,
                Name = "Egor",
                Address = "SPb, Russia",
                Phone = "+7 964 368-81-80"
            });

            base.Seed(context);
        }
    }
}