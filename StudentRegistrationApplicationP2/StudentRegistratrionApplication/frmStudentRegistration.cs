using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistratrionApplication
{
    public partial class frmStudentRegistration : Form
    {
        public frmStudentRegistration()
        {
            InitializeComponent();

        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            for(int days = 1; days <= 31; days++)
            {
                dayCombo.Items.Add(days.ToString());
            }

            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            foreach (string month in months)
            {
                monthCombo.Items.Add(month);
            }

            for (int year = 1900;  year <= 2024; year++)
            {
                yearCombo.Items.Add(year.ToString());
            }

            string[] programList = new string[] {"Bachelor of Science in Computer Science", "Bachelor of Science in Information Technology", "Bachelor of Science in Information Systems", "Bachelor of Science in Computer Engineering"};

            foreach(string program in programList)
            {
                listPrograms.Items.Add(program);
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string lastName = textBox3.Text;
            string firstName = textBox1.Text;
            string middleName = textBox2.Text;

            string studentName = "Student Name: " +  firstName + " " + middleName + " " + lastName + "\n";
            string gender = "None";
            string birthMonth = "Date of Birth: " + dayCombo.Text + "/" + monthCombo.Text + "/" + yearCombo.Text + "\n";
            string programShow = "Program: " + listPrograms.Text;

            if (maleRadio.Checked)
            {
                gender = "Gender: " + maleRadio.Text + "\n";
            }
            else if (femaleRadio.Checked)
            {
                gender = femaleRadio.Text + "\n";
            }

            if ((lastName != null && firstName != null && middleName != null) && (gender != "None") && (birthMonth != null) && (programShow != null))
            {
                showInfo(studentName, gender, birthMonth, programShow);
            }else if ((lastName != null && firstName != null && middleName != null) && (programShow != null))
            {
                showInfo(studentName, programShow);
            }else if((lastName != null && firstName != null) && (middleName == null) && (programShow != null))
            {
                showInfo(firstName, lastName, programShow);
            }
        }

        private void browseButton_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Picture";
            openFileDialog.Filter = "JPEG|*.jpeg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string picName = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(picName);

            }
            else
            {
                MessageBox.Show("You did not select a picture!");
            }
        }

        public void showInfo(string studentName, string gender, string birthDate, string program)
        {
            string lastName = textBox3.Text;
            string firstName = textBox1.Text;
            string middleName = textBox2.Text;

            string nameStudent = "Student Name: " + firstName + " " + middleName + " " + lastName + "\n";
            string genderStu = "None";

            if (maleRadio.Checked)
            {
                genderStu = "Gender: " + maleRadio.Text + "\n";
            }
            else if (femaleRadio.Checked)
            {
                genderStu = femaleRadio.Text + "\n";
            }



            string birthMonth = "Date of Birth: " + dayCombo.Text + "/" + monthCombo.Text + "/" + yearCombo.Text + "\n";
            string programShow = "Program: " + listPrograms.Text;

            MessageBox.Show(nameStudent + genderStu + birthMonth + programShow);
        }

        public void showInfo(string studentName, string program)
        {
            string lastName = textBox3.Text;
            string firstName = textBox1.Text;
            string middleName = textBox2.Text;

            string nameStudent = "Student Name: " + firstName + " " + middleName + " " + lastName + "\n";
            string programShow = "Program: " + listPrograms.Text;

            MessageBox.Show(nameStudent + programShow);
        }

        public void showInfo(string nameFirst, string nameLast, string program)
        {
            string lastName = textBox3.Text;
            string firstName = textBox1.Text;
            string programShow = "Program: " + listPrograms.Text;

            MessageBox.Show("Student Name: " + firstName + " " + lastName + "\n" + programShow);
        }
    }
}
