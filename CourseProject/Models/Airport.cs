using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CourseProject.Models
{
    public class Airport : IFactory
    {
        public string Name { get; set; }
        public List<Product> products { get; set; }

        //reference on bank account for providing operations with finance
        private Account OperAccount { get; set; }

        private Random rnd;

        //setting bank account
        public void GetBankAccount(Account account)
        {
            OperAccount = account;
        }

        private string Start()
        {
            string result = "*) ";
            rnd = new Random();
            int prodnum = rnd.Next(0, products.Count - 1);//number of product
            int prodcount = rnd.Next(1, 10);// amount of products
            if (products[prodnum].Quantity == 0)
            {
                result += string.Format("In airport \"{0}\" plane \"{1}\" start from line \"{2}\"", Name, products[prodnum].Name, prodcount);
                products[prodnum].Quantity = 1;
            }
            else { return ""; }
            return result + "\r" + "\n";
        }

        private string Arrived()
        {
            string result = "*) ";
            rnd = new Random();
            int prodnum = rnd.Next(0, products.Count - 1);//number of product
            int prodcount = rnd.Next(1, 10);// amount of products
            if (products[prodnum].Quantity == 1)
            {
                result += string.Format("In airport \"{0}\" plane \"{1}\" arrived on line \"{2}\"", Name, products[prodnum].Name, prodcount);
                products[prodnum].Quantity = 0;
            }
            else { return ""; }
            return result + "\r" + "\n";
        }

        private async Task<string> BuyResources()
        {
            string result = "*) ";
            
            rnd = new Random();
            int prodnum = rnd.Next(0, products.Count - 1);//number of product
            int prodcount = rnd.Next(10, 100);// amount of products
            int amount = 100* prodcount;
            result += string.Format("\"{0}\"  buy gas for plane \"{1}\" in amount {2} and pay {3}$", Name, products[prodnum].Name, prodcount, amount);
            if (await OperAccount.GetCash(amount))
            {
                result += " Operation succesfull" + "\r" + "\n";
                return result;
            }
            else 
            {
                result += " Bank Account locked";
                return result + "\r" + "\n";
            };
        }

        private string Inventarization()
        {
            string result = "*) ";
            result += "\"" + Name + "\" start inventarization:" + "\r" + "\n";
            foreach (Product item in products)
            {
                result += "\"" + item.Name + "\", is in flight: " + item.Quantity.ToString() + "\r" + "\n";
            }
            return result + "\r" + "\n";
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
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += Start(); });
        }

        public void OnFourthEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += Inventarization(); });
        }

        public void OnSecondEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += Arrived(); });
        }

        public async void OnThirdEvent(TextBox textBox)
        {
            string x = await BuyResources();
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += x; });
        }

        public void Save(string filename)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(Airport));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSer.Serialize(fs, this);
            }
        }
    }
}
