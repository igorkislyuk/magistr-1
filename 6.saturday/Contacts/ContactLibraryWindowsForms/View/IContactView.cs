using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibraryWindowsForms
{
    public interface IContactView
    {
        IList<string> ContactList { get; set; }

        int SelectedContact { get; set; }

        string ContactName { get; set; }

        string Address { get; set; }

        string Phone { get; set; }

        ContactPresenter Presenter { set; }

    }
}
