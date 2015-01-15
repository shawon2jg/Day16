using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchStudentApp
{
    public partial class StudentEntryUI : Form
    {
        public StudentEntryUI()
        {
            InitializeComponent();
        }

        
       
        private void saveButton_Click(object sender, EventArgs e)
        {
            
            string name = studentNameTextBox.Text;
            string regNo = studentRegNoTextBox.Text;
            string email = studentEmailTextBox.Text;
            Department selecteDepartment = (Department)departmentComboBox.SelectedItem;
            int departmentId = selecteDepartment.DeptId;


            string connectionString = @"Data Source = LICT-PC\SQLEXPRESS; Database = StudentDB; Integrated Security = true";

          
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = "INSERT INTO Student VALUES('" + name + "','" + email + "','" + regNo + "','" + departmentId + "')";

            SqlCommand command = new SqlCommand(query,connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            if (rowAffected > 0)
            {
                MessageBox.Show("Successfully Saved!");
            }
            else
            {
                MessageBox.Show("Couldn't saved data!");
            }

            testClear();
        }

        private void testClear()
        {
            studentNameTextBox.Text = string.Empty;
            studentRegNoTextBox.Text = string.Empty;
            studentEmailTextBox.Text = string.Empty;
        }

        private void StudentEntryUI_Load(object sender, EventArgs e)
        {
            List<Department> departmentList = new List<Department>();

            string connectionString = @"Data Source = LICT-PC\SQLEXPRESS; Database = StudentDB; Integrated Security = true";
            SqlConnection aConnection = new SqlConnection(connectionString);
            aConnection.Open();

            string query = "SELECT * FROM department";
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            while (aReader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.DeptId = (int)aReader["dept_id"];
                aDepartment.DeptName = aReader["dept_name"].ToString();
                
                departmentList.Add(aDepartment);
            }

            aReader.Close();
            aConnection.Close();

            departmentComboBox.Items.Clear();

            foreach (Department aDepartment in departmentList)
            {
                departmentComboBox.Items.Add(aDepartment);
            }

            departmentComboBox.DisplayMember = "DeptName";
            departmentComboBox.ValueMember = "DeptId";
        }
    }
}

