using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PRG262_Project
{
    public partial class Login : Form
    {
        
        static DataHandler handler = new DataHandler();
        static TextFileHandler text = new TextFileHandler();
        static List<User> UserInfo = handler.ReadToList(text.FileRead());
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach (User person in UserInfo)
            {
                if(person.UserName == txtNameLogin.Text && person.Password == txtPasswordLogin.Text)
                {
                    MessageBox.Show("Login Successful");
                    found = true;
                    MainForm main = new MainForm(this);

                    main.Show();
                    this.Hide();
                    
                    break;
                }
                
            }
            if(found == false)
            {
                DialogResult result = MessageBox.Show("Do you want to register?", "Question", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        UserInfo.Add(new User(txtNameLogin.Text, txtPasswordLogin.Text));
                        text.FileWrite(handler.WriteToFile(UserInfo));

                        break;
                    case DialogResult.No:
                        txtNameLogin.Clear();
                        txtPasswordLogin.Clear();

                        break;
                }
            }
        }
    }
}