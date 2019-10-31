using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CourseProject.Models
{
    public class Factory : IFactory
    {
        public string Name { get; set; }
        public List<Product> products { get; set; }

        //reference on bank account for providing operations with finance
        private Account Account { get; set; }

        public Factory()
        { }

        //setting bank account
        public void GetBankAccount(Account account)
        {
            Account = account;
        }

        public void GetCash(IBankAccount bank, int sum)
        {
            throw new NotImplementedException();
        }

        public void PutCash(IBankAccount bank, int sum)
        {
            throw new NotImplementedException();
        }

        public void Save(string filename)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(Factory));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSer.Serialize(fs, this);
            }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public string Work()
        {
            return "working";
        }

        public void OnStart(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "Start working " + Name + "\r" + "\n"; });
        }

        public void OnStop(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "Stop working " + Name + "\r" + "\n"; });
                      
        }

        public void OnFirstEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "First event with " + Name + Work() + "\r" + "\n"; });
        }

        public void OnSecondEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "second event with " + Name + Work()  + "\r" + "\n"; });
        }

        public void OnThirdEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "third event with " + Name + Work()  + "\r" + "\n"; });
        }

        public void OnFourthEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "fourth event with " + Name + Work()  + "\r" + "\n"; });
        }
    }
}
