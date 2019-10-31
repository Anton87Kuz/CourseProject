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
        private Account OperAccount { get; set; }

        private Random rnd;

        public Factory()
        { }

        //setting bank account
        public void GetBankAccount(Account account)
        {
            OperAccount = account;
        }

        public void Save(string filename)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(Factory));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                xmlSer.Serialize(fs, this);
            }
        }

        private async Task<string> Sell()
        {
            string result = "*) ";
            rnd = new Random();
            int prodnum = rnd.Next(0, products.Count - 1);//number of product
            int prodcount = rnd.Next(1, 100);// amount of products
            products[prodnum].Quantity -= prodcount;
            if (products[prodnum].Quantity < 0) { products[prodnum].Quantity += prodcount; return Name + " trying to sell but product \"" + products[prodnum].Name + " \" ended" + "\r" + "\n"; }
            int profit = products[prodnum].Price * prodcount;
            result += string.Format("\"{0}\" sell product \"{1}\" in amount {2} and get {3}$", Name, products[prodnum].Name, prodcount, profit);
            if (await OperAccount.PutCash(profit))
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

        private string GetProduct()
        {
            string result = "*) ";
            rnd = new Random();
            int prodnum = rnd.Next(0, products.Count - 1);//number of product
            int prodcount = rnd.Next(1, 100);// amount of products
            products[prodnum].Quantity += prodcount;
            result += string.Format("\"{0}\" made amount {2} of product \"{1}\" and put it to the store", Name, products[prodnum].Name, prodcount);
            return result;
        }

        private async Task<string> BuyResources()
        {
            string result = "*) ";
            rnd = new Random();
            int prodnum = rnd.Next(0, products.Count - 1);//number of product
            int prodcount = rnd.Next(1, 100);// amount of products
            int amount = (products[prodnum].Price - 3) * prodcount;
            result += string.Format("\"{0}\"  buy resources for product \"{1}\" in amount {2} and pay {3}$", Name, products[prodnum].Name, prodcount,amount);
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
                result += "\"" + item.Name + "\", amount: " + item.Quantity.ToString() + "\r" + "\n";
            }
            return result;
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
            
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += GetProduct()+ "\r" + "\n"; });
        }

        public async void OnSecondEvent(TextBox textBox)
        {
            string x = await Sell();
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += x; });
        }

        public async void OnThirdEvent(TextBox textBox)
        {
            string x = await BuyResources();
            textBox.Invoke((MethodInvoker)delegate { textBox.Text += x; });
        }

        public void OnFourthEvent(TextBox textBox)
        {
            textBox.Invoke((MethodInvoker)delegate { textBox.Text +=  Inventarization()+ "\r" + "\n"; });
        }
    }
}
