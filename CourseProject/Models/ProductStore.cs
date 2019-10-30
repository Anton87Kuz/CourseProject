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
    public class ProductStore:IFactory
    {
        //name of product store
        public string Name { get; set; }
        
        //contains list of products the store selling is
        public List<Product> products { get;  set; }

        //reference on bank account for providing operations with finance
        private Account Account { get; set; }

        //need for serialization
        public ProductStore()
        { }

        //setting bank account
        public void GetBankAccount(Account account)
        {
            Account = account;
        }

        public void Start()
        {
           
        }

        public void GetCash(int sum)
        {
            //bank.GetMoney(sum);
        }

        public void PutCash(int sum)
        {
            //bank.SetMoney(sum);
        }

        public string Work()
        {
            return "Working";
        }

        public void OnFirstEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "First event with " + Name + Work()+"\r" + "\n"; });
        }

        public void OnSecondEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "Second event with " + Name + "\r" + "\n"; });
        }
        public void OnThirdEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "Third event with " + Name + "\r" + "\n"; });
        }
        public void OnFourthEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += "Fourth event with " + Name + "\r" + "\n"; });
        }


        public void Save(string filename)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(ProductStore));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSer.Serialize(fs,this);
            }
        }

               
    }
}
