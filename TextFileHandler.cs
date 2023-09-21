using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG262_Project
{
    internal class TextFileHandler
    {
        public List<string> FileRead()
        {
            List<string> RawDataPeople = new List<string>();
            string path = "Files\\UserInfo.txt";
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Close();
                if (File.ReadAllLines(path) != null)
                {
                    RawDataPeople = File.ReadAllLines(path).ToList();
                    MessageBox.Show("File succesfully read");
                }
                else
                {
                    MessageBox.Show("File has no data stored");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            return RawDataPeople;
        }
        public void FileWrite(List<string> RawDataPeople)
        {
            string path = "Files\\UserInfo.txt";
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                fs.Close();
                File.WriteAllLines(path, RawDataPeople);
                MessageBox.Show("Successfully added user. Login with new infomation");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

