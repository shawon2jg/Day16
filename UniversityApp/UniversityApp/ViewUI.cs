using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityApp
{
    public partial class ViewUI : Form
    {
        public ViewUI()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Student> studentList = new List<Student>();
            string inputId = searchIdTextBox.Text;
            string connectionString = @"Data Source=(local)\sqlexpress; Database=UniversityDB; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM tStudent";

            if (!String.IsNullOrEmpty(inputId))
            {
                query = "SELECT * FROM tStudent WHERE Id='"+inputId+"'";
            }

            

            SqlCommand command = new SqlCommand(query,connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student();
                student.id = (int)reader["Id"];
                student.name = reader["Name"].ToString();
                student.email = reader["Email"].ToString();
                student.address = reader["Address"].ToString();
                student.phone = reader["Phone"].ToString();
               studentList.Add(student);
            }

            // add students to list view...

            LoadListView(studentList);



        }

        private void LoadListView(List<Student> studentList)
        {
            studentListView.Items.Clear();
            if (studentList!=null && studentList.Any())
            {
                foreach (var student in studentList)
                {
                    ListViewItem item = new ListViewItem(student.id.ToString());
                    item.SubItems.Add(student.name);
                    item.SubItems.Add(student.email);
                    item.SubItems.Add(student.address);
                    item.SubItems.Add(student.phone);

                    item.Tag = student;

                    studentListView.Items.Add(item);
                }
            }
        }

        private void studentListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = studentListView.SelectedItems[0];

            Student selectedStudent = (Student) selectedItem.Tag;

            idLabel.Text = selectedStudent.id.ToString();
            nameTextBox.Text = selectedStudent.name;
            emailTextBox.Text = selectedStudent.email;
            addressTextBox.Text = selectedStudent.address;
            phoneTextBox.Text = selectedStudent.phone;

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            // take input to update 

            // connectionstring

            //connection

            // query

            //command
        }

       
    }
}
