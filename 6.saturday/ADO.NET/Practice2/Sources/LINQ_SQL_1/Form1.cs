using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_SQL_1
{
    public partial class Form1 : Form
    {
        DataContext db = new DataContext(@"Data Source=.\SQLExpress;Initial Catalog=NORTHWND;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var custQuery =
                from cust in db.GetTable<Customer>()
                where cust.Orders.Any()
                select cust;

            foreach (var custObj in custQuery)
            {
                ListViewItem item = listView1.Items.Add(custObj.CustomerID.ToString());
                item.SubItems.Add(custObj.City.ToString());
                item.SubItems.Add(custObj.Orders.Count.ToString());
            }
        }
    }
}