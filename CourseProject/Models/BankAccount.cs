using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourseProject.Models
{
    public class BankAccount : IBankAccount
    {
        public string BankID { get; set; }

        public Account OperationalAcc { get; set; }

        public Account PrivateAcc { get; set; }


        public BankAccount()
        {
            BankID = "B"+Convert.ToString(new Random().Next(1000000, 9999999))+"ID";
        }

        public void GetCurrentSum()
        {
            throw new NotImplementedException();
        }

        public void GetMoney( int sum)
        {
            
        }

        public void SetMoney(int sum)
        {
           
        }

        public void OnGetMoney(System.Windows.Forms.TextBox textBox)
        {
            textBox.Text += "Get some money from " + BankID + "\r" + "\n";
        }

        public void Save(string filename)
        {
            OperationalAcc = new Account { AccId = 1212324, Summa = 10000000 };
            PrivateAcc = new Account { AccId = 2324241, Summa = 1000000 };
            XmlSerializer xmlSer = new XmlSerializer(typeof(BankAccount));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSer.Serialize(fs, this);
            }
        }
    }
}
