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

namespace UniversityApp
{
    public partial class StudentEntryUI : Form
    {
        public StudentEntryUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Department> deparmentList= new List<Department>();
            string connectionString = @"Data Source=(local)\sqlexpress; Database=UniversityDB; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);

            var query = "SELECT * FROM tDepartment";
            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Department department = new Department();
                department.Id = (int) reader["Id"];
                department.Name = reader["Name"].ToString();
                department.Location = reader["Location"].ToString();
                deparmentList.Add(department);
            }

            reader.Close();
            connection.Close();

          
            departmentComboBox.DisplayMember = "Name";
            departmentComboBox.ValueMember = "Id";
            departmentComboBox.DataSource = null;
            departmentComboBox.DataSource = deparmentList;

            //foreach (var department in deparmentList)
            //{
            //    departmentComboBox.Items.Add(department);
            //}


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // take user input
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string email = emailTextBox.Text;
            string phone = phoneTextBox.Text;
            Department selectedDepartment = (Department) departmentComboBox.SelectedItem;

            int departmentId = selectedDepartment.Id;
            // connect with database
            //1. ConnectionString
            string connectionString = @"Data Source=(local)\sqlexpress; Database=UniversityDB; Integrated Security=true";
            //2. Build a connection with connection string
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            //insert data into database 
            //1. Write down query
            string query = "INSERT INTO tStudent VALUES('" + name + "','" + address + "','" + email + "','" + phone + "','" + departmentId + "')";

            //string query = String.Format("INSERT INTO tStudents VALUES('{0}','{1}','{2}','{3}'", name, email, address,phone);

            // 2. Execute query throught connection
            SqlCommand commmand = new SqlCommand(query,connection);

            int rowAffected = commmand.ExecuteNonQuery();

            connection.Close();

            if (rowAffected>0)
            {
                MessageBox.Show("Successfully Saved!");
            }
            else
            {
                MessageBox.Show("Couldn't save the data", "Error");
            }




        }
    }
}
