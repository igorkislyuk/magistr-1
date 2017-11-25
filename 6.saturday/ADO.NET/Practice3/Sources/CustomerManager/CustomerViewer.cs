using CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManager
{
    public partial class CustomerViewer : Form
    {
        private SampleContext context = new SampleContext();


        byte[] Ph;

        public CustomerViewer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void CustomerViewer_Load(object sender, EventArgs e)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleContext>());

            context.Orders.Add(new Order
            {
                ProductName = "Audio",
                Quantity = 12,
                PurchaseDate = DateTime.Parse("12.01.2016")
            });
            context.Orders.Add(new Order
            {
                ProductName = "Video",
                Quantity = 22,
                PurchaseDate = DateTime.Parse("10.01.2016")
            });

            context.VipOrders.Add(new VipOrder
            {
                ProductName = "Auto",
                Quantity = 1488,
                PurchaseDate = DateTime.Parse("10.01.2016"),
                status = "High"
            });

            context.SaveChanges();
            orderlistBox.DataSource = context.Orders.ToList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    FirstName = this.textBoxname.Text,
                    LastName = this.textBoxlastname.Text,
                    Email = this.textBoxmail.Text,
                    Age = Int32.Parse(this.textBoxage.Text),
                    Photo = Ph
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                Output();

                textBoxname.Text = string.Empty;
                textBoxmail.Text = string.Empty;
                textBoxage.Text = string.Empty;
                textBoxlastname.Text = string.Empty;

                Orders = orderlistBox.SelectedItems.OfType<Order>().ToList();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        public List<Order> Orders { get; set; }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                Image bm = new Bitmap(diag.OpenFile());
                ImageConverter converter = new ImageConverter();
                Ph = (byte[]) converter.ConvertTo(bm, typeof(byte[]));
            }
        }

        private void Output()
        {
            if (CustomerradioButton.Checked)
            {
                GridView.DataSource = context.Customers.ToList();
            }
            else if (OrderradioButton.Checked)
            {
                GridView.DataSource = context.Orders.ToList();
            }
            else if (ViporderradioButton.Checked)
            {
                GridView.DataSource = context.VipOrders.ToList();
            }
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            var query = context.Customers.OrderBy(b => b.FirstName);
            customerList.DataSource = query.ToList();

            Output();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (labelid.Text == String.Empty) return;
            var id = Convert.ToInt32(labelid.Text);
            var customer = context.Customers.Find(id);
            if (customer == null) return;
            customer.FirstName = this.textBoxname.Text;
            customer.LastName = this.textBoxlastname.Text;
            customer.Email = this.textBoxmail.Text;
            customer.Age = Int32.Parse(this.textBoxage.Text);

            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
            Output();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (labelid.Text == String.Empty) return;
            var id = Convert.ToInt32(labelid.Text);
            var customer = context.Customers.Find(id);
            context.Entry(customer).State = EntityState.Deleted;
            context.SaveChanges();

            Output();
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView.CurrentRow == null) return;
            if (!(GridView.CurrentRow.DataBoundItem is Customer customer)) return;

            labelid.Text = Convert.ToString(customer.CustomerId);
            textBoxCustomer.Text = customer.ToString();
            textBoxname.Text = customer.FirstName;
            textBoxlastname.Text = customer.LastName;
            textBoxmail.Text = customer.Email;
            textBoxage.Text = Convert.ToString(customer.Age);
        }
    }
}