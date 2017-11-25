using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINQ_SQL_SProc
{
    public partial class Form1 : Form
    {
        NORTHWND db =
                new NORTHWND(
                    @"Y:\Documents\study\magistr-2017-2018\6.saturday\ADO.NET\Practice2\Sources\LINQ_SQL_SProc\NORTHWND.MDF")
            ;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            string param = codeTextField.Text;

            var custquery = db.CustOrdersDetail(Convert.ToInt32(param));

            string msg = "";
            foreach (CustOrdersDetailResult custOrdersDetail in custquery)
            {
                msg = msg + custOrdersDetail.ProductName + "\n";
            }
            if (msg == "")
                msg = "No results.";
            MessageBox.Show(msg);

            param = "";
            codeTextField.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string param = clientTextField.Text;
            var custquery = db.CustOrderHist(param);
            string msg = "";
            foreach (CustOrderHistResult custOrdHist in custquery)
            {
                msg = msg + custOrdHist.ProductName + "\n";
            }
            MessageBox.Show(msg);
            param = "";
            clientTextField.Text = "";
        }
    }
}