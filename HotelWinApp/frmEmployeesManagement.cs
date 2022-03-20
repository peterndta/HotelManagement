using BusinessObject;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelWinApp
{
    public partial class frmEmployeesManagement : Form
    {
        public frmEmployeesManagement()
        {
            InitializeComponent();
        }
        public IEmployeeRepository employeeRepository = new EmployeeRepository();
        BindingSource source;
        private IEnumerable<EmployeeObject> EmployeeList;

        private void ClearText()
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtPathImage.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmEmployeeInfo frmEmployeeInfo = new frmEmployeeInfo
            {
                Text = "Add New Employee",
                InsertOrUpdate = false,
                EmployeeRepository = employeeRepository,
            };
            if (frmEmployeeInfo.ShowDialog() == DialogResult.OK)
            {
                LoadEmployeeList();
            }
        }
        public void LoadEmployeeList()
        {
            List<EmployeeObject> listEmployee = null;

            listEmployee = employeeRepository.GetEmployees().ToList<EmployeeObject>();
            if(listEmployee != null)
            { 
                try
                {
                    source = new BindingSource();
                    source.DataSource = listEmployee;

                    // Clear binding data
                    txtEmployeeID.DataBindings.Clear();
                    txtEmployeeName.DataBindings.Clear();
                    txtPathImage.DataBindings.Clear();
                    txtUsername.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();
         

                    txtEmployeeID.DataBindings.Add("Text", source, "EmployeeID");
                    txtEmployeeName.DataBindings.Add("Text", source, "EmployeeName");
                    txtPathImage.DataBindings.Add("Text", source, "PathImage");
                    txtUsername.DataBindings.Add("Text", source, "Username");
                    txtPassword.DataBindings.Add("Text", source, "Password");


                    dvgEmployees.DataSource = null;  // Clear grid data
                    dvgEmployees.DataSource = source;


                    if (listEmployee.Count() == 0)
                    {
                        ClearText();
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                    
                        btnDelete.Enabled = true;
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load employee list");
                }
            }
            else
            {
                MessageBox.Show("Empty Data", "Alert");
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadEmployeeList();
        }
        private EmployeeObject GetEmployeeObject()
        {
            EmployeeObject employee = null;
            try
            {
                employee = new EmployeeObject
                {
                    EmployeeID = int.Parse(txtEmployeeID.Text),
                    EmployeeName = txtEmployeeName.Text,
                    PathImage = txtPathImage.Text,
                    username = txtUsername.Text,
                    password = txtPassword.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get employee information");
            }
            return employee;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult alert = MessageBox.Show("Are you sure?", "Delete Employee", MessageBoxButtons.OKCancel);
                if (alert == DialogResult.OK)
                {
                    EmployeeObject Employee = GetEmployeeObject();
                    employeeRepository.DeleteEmployee(Employee.EmployeeID);
                    LoadEmployeeList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Employee");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSearchBy.Text == "ID")
                {
                    int employeeID = int.Parse(txtSearch.Text);
                    EmployeeList = employeeRepository.GetEmployeesByID(employeeID);
                }
                else if (cbSearchBy.Text == "Name")
                {
                    string employeeName = txtSearch.Text;
                    EmployeeList = employeeRepository.GetEmployees().Where(s => s.EmployeeName.Contains(employeeName));
                }

                if (EmployeeList != null)
                {
                    source = new BindingSource();
                    source.DataSource = EmployeeList;

                    txtEmployeeID.DataBindings.Clear();
                    txtEmployeeName.DataBindings.Clear();
                    txtPathImage.DataBindings.Clear();
                    txtUsername.DataBindings.Clear();
                    txtPassword.DataBindings.Clear();


                    txtEmployeeID.DataBindings.Add("Text", source, "EmployeeID");
                    txtEmployeeName.DataBindings.Add("Text", source, "EmployeeName");
                    txtPathImage.DataBindings.Add("Text", source, "PathImage");
                    txtUsername.DataBindings.Add("Text", source, "Username");
                    txtPassword.DataBindings.Add("Text", source, "Password");

                    dvgEmployees.DataSource = null; 
                    dvgEmployees.DataSource = source;

                    btnDelete.Enabled = true;

                }
                else
                {
                    ClearText();
                    btnDelete.Enabled = false;
                    MessageBox.Show("This Employee does not exist!", "Search Employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("This Employee does not exist!", "Search Employee");
            }
        }

        private void frmEmployeesManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;

            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void dvgEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);

            }
        }

        private void dvgEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEmployeeInfo frmEmployeeInfo = new frmEmployeeInfo
            {
                Text = "Employee Info",
                InsertOrUpdate = true,
                EmployeeInfo = GetEmployeeObject(),
                EmployeeRepository = employeeRepository,
            };
            if (frmEmployeeInfo.ShowDialog() == DialogResult.Cancel)
            {
                LoadEmployeeList();
                source.Position = source.Count - 1;
            }
        }

    }
}
