using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG262_Project
{
    public partial class SearchForm : Form
    {
        Form Main;
        DataHandler handler = new DataHandler();
        public SearchForm(Form form)
        {
            Main = form;
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable table = handler.Search(int.Parse(txtSearchID.Text));
            dgvSearch.DataSource = "";
            dgvSearch.DataSource = table;
            
                
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Main.Show();
            this.Hide();
            
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.Show();
            this.Hide();
        }
        
    }
    
}
