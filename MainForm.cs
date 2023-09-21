using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG262_Project
{
    public partial class MainForm : Form
    {
        Form Login;

        DataHandler handler = new DataHandler();
        public MainForm(Form form)
        {
            Login = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtUID.Text);
            string FirstName = txtUFirstName.Text, LastName = txtULastName.Text,
                Gender = cbxUGender.Text, Phone = txtUPhone.Text, Address = rtxUAddress.Text,
                CourseCode = cbxUCode.Text;
            DateTime DOB = dtpUDOB.Value;
            handler.ExecuteQuery(handler.UpdateInfo(ID, FirstName, LastName, DOB,
                Gender, Phone, Address, CourseCode));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtIDDelete.Text);
            handler.ExecuteQuery(handler.Delete(ID));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(textID.Text);
            string FirstName = txtAddName.Text, LastName = txtAddSurname.Text, 
                Gender = cbxGender.Text, Phone = textPhone.Text, Address = rtxAddress.Text,
                CourseCode = cbxCode.Text;
            DateTime DOB = dtpDOB.Value;
            byte[] ProfilePic = {0, 1};
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "Images|*.jpg;*.png;*.jpeg";
            openImage.Multiselect = false;
            
            if(openImage.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openImage.FileName, FileMode.Open, FileAccess.Read);
                
                ProfilePic = new byte[fs.Length];
                fs.Read(ProfilePic, 0, ProfilePic.Length);
            }
            handler.AddInfo(ID, FirstName, LastName, DOB,
                Gender, Phone, Address, CourseCode, ProfilePic);
           
           
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(this);
            searchForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bye bye");
        }
    }
}
