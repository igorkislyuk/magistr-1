using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

using ContactLibrary;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IContactProvider provider = new ContactModelProvider(AppContext.BaseDirectory);
            var models = provider.GetAllContactModels();
            foreach (var contactModel in models)
            {
                System.Console.WriteLine(contactModel.Name + " leaves here " + contactModel.Address);
                System.Console.ReadLine();
            }

        }
    }
}
