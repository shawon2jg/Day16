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
    public partial class SearchStudentUI : Form
    {
        public SearchStudentUI()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string inputId = studentIdTextBox.Text;
            string connectionString =
              @"Data Source = LICT-PC\SQLEXPRESS ; Database = StudentDB; Integrated Security = true";
            
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string query = "";
           
            if (String.IsNullOrEmpty(inputId))
            {
                query = "SELECT * FROM Student LEFT OUTER JOIN Department ON Student.dept_id = Department.dept_id";
            }
            else if(departmentComboBox.Text!= string.Empty)
            {
                Department selecteDepartment = (Department)departmentComboBox.SelectedItem;
                int inputDept = selecteDepartment.DeptId;
                query = "SELECT Student.std_id, Student.std_reg_no, Student.std_name, Student.std_email, Department.dept_name FROM Student LEFT OUTER JOIN Department ON Student.dept_id = Department.dept_id WHERE std.dept_id='" + inputDept + "'";
            }
            else
            {
                query = "SELECT Student.std_id, Student.std_reg_no, Student.std_name, Student.std_email, Department.dept_name FROM Student LEFT OUTER JOIN Department ON Student.dept_id = Department.dept_id WHERE Student.std_id ='" + inputId + "'";
            }
            
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Student> studentList = new List<Student>();
            while (reader.Read())
            {
                Student aStudent = new Student();
                aStudent.id = (int) reader["std_id"];
                aStudent.regNo = reader["std_reg_no"].ToString();
                aStudent.name = reader["std_name"].ToString();
                aStudent.email = reader["std_email"].ToString();
                aStudent.dept_name = reader["dept_name"].ToString();
                studentList.Add(aStudent);
            }
            searchListView.Items.Clear();
           
            foreach (var astudent in studentList)
            {
                ListViewItem aListViewItem = new ListViewItem();
                aListViewItem.Text = astudent.id.ToString();
                aListViewItem.SubItems.Add(astudent.regNo);
                aListViewItem.SubItems.Add(astudent.name);
                aListViewItem.SubItems.Add(astudent.email);
                aListViewItem.SubItems.Add(astudent.dept_name);

                aListViewItem.Tag = astudent; 

                searchListView.Items.Add(aListViewItem);
            }
        }

        private void SearchStudentUI_Load(object sender, EventArgs e)
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
