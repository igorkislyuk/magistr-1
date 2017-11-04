using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ContactLibrary;

namespace ContactLibraryWindowsForms
{
    public partial class ContactLibraryMainForm : Form, IContactView
    {
        #region Initializer

        public ContactLibraryMainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Public 

        public ContactPresenter Presenter { private get; set; }

        public IList<string> ContactList
        {
            get { return (IList<string>)this.contactListBox.DataSource; }
            set { this.contactListBox.DataSource = value; }
        }

        public int SelectedContact
        {
            get { return this.contactListBox.SelectedIndex; }
            set { contactListBox.SelectedIndex = value; }
        }

        public string Address
        {
            get { return this.addressTextBox.Text; }
            set { this.addressTextBox.Text = value; }
        }

        public string ContactName
        {
            get { return this.nameTextBox.Text; }
            set { this.nameTextBox.Text = value; }
        }

        public string Phone
        {
            get { return this.phoneTextBox.Text; }
            set { this.phoneTextBox.Text = value; }
        }

        #endregion

        #region Private

        private bool _isEditMode = false;

        #endregion

        private void addButton_Click(object sender, EventArgs e)
        {
            Presenter.AddCustomer();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.addressTextBox.ReadOnly = _isEditMode;
            this.nameTextBox.ReadOnly = _isEditMode;
            this.phoneTextBox.ReadOnly = _isEditMode;

            _isEditMode = !_isEditMode;

            this.button1.Text = _isEditMode ? "Save" : "Edit";

            if (!_isEditMode)
            {
                Presenter.UpdateContactModel();
            }
        }

        private void contactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.UpdateContactView(contactListBox.SelectedIndex);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Presenter.RemoveSelected();
        }

        private void ContactLibraryMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Presenter.Save();
        }
    }
}
