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
            //Name = "Factory";
            //products = new List<Product>();
            //products.Add(new Product { ID = 212134, Name = "Fproduct_1", Price = 10, Quantity = 1000 });
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

        public void Work()
        {
            throw new NotImplementedException();
        }

        public void OnFirstEvent(TextBox textBox)
        {
            throw new NotImplementedException();
        }

        public void OnSecondEvent(TextBox textBox)
        {
            throw new NotImplementedException();
        }

        public void OnThirdEvent(TextBox textBox)
        {
            throw new NotImplementedException();
        }

        public void OnFourthEvent(TextBox textBox)
        {
            throw new NotImplementedException();
        }
    }
}
