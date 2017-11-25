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

            var results = from c in db.GetTable<Customer>()
                where c.City == "London"
                select c;

            foreach (var c in results)
            {
                listBox1.Items.Add(c.ToString());
            }
        }
    }
}