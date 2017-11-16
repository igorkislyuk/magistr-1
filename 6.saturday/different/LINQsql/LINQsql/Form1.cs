using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Windows.Forms;


namespace LINQsql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DataContext db = new DataContext
(fileOrServerOrConnection: @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;");


            var results = from c in db.GetTable<Program.Customer>()
                          where c.City == "London"
                          select c;
            foreach (var c in results)
                listBox1.Items.Add(c.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
   
}
