using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManager
{
    public partial class CourseViewer : Form
    {
        private SchoolEntities schoolContext = new SchoolEntities();

        public CourseViewer()
        {
            Text = "CourseViewer";
            InitializeComponent();
        }

        private void CourseViewer_Load(object sender, EventArgs e)
        {
            var departmentQuery = from d in schoolContext.Departments.Include("Courses")
                orderby d.Name
                select d;

            try
            {
                departmentList.ValueMember = "Name";
                departmentList.DataSource = ((DbQuery<Department>) departmentQuery).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void departmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var department = (Department) departmentList.SelectedItem;

                courseGridView.DataSource = department.Courses.ToList();

                courseGridView.AllowUserToDeleteRows = false;
                courseGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateClick(object sender, EventArgs e)
        {
            try
            {
                schoolContext.SaveChanges();
                MessageBox.Show("Changes saved to the database.");
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseClick(object sender, EventArgs e)
        {
            this.Close();
            schoolContext.Dispose();
        }
    }
}