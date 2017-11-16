using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LINQsql
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        [Table(Name = "Customers")]
        public class Customer
        {
            private string _CustomerID;
            [Column(IsPrimaryKey = true, Storage = "_CustomerID")]
            public string CustomerID
            {
                get
                {
                    return this._CustomerID;
                }
                set
                {
                    this._CustomerID = value;
                }
            }
            private string _City;
            [Column(Storage = "_City")]
            public string City
            {
                get
                {
                    return this._City;
                }
                set
                {
                    this._City = value;
                }
            }
            public override string ToString()
            {
                return CustomerID + "\t" + City;
            }
        }
    }
}
