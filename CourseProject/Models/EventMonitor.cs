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
    public class EventMonitor
    {
        private const string storePath = "C:/Users/kuzan/Desktop/C# Projects/CourseProject/ProductStore.xml";
        private const string bankPath = "C:/Users/kuzan/Desktop/C# Projects/CourseProject/Bank.xml";
        private const string factoryPath = "C:/Users/kuzan/Desktop/C# Projects/CourseProject/Factory.xml";

        public BankAccount bank;
        public ProductStore store;
        public Factory factory;
        public EventGenerator generator;

        public EventMonitor(System.Windows.Forms.TextBox textbox)
        {
            bank = new BankAccount();
            store = new ProductStore();
            factory = new Factory();
            generator = new EventGenerator(textbox);

            store = (ProductStore) LoadData(storePath, store.GetType());
            bank = (BankAccount) LoadData(bankPath, bank.GetType());
            factory = (Factory) LoadData(factoryPath, factory.GetType());

            generator.FirstEvent += store.OnFirstEvent;
        }

        private void Generator_FirstEvent(System.Windows.Forms.TextBox textBox)
        {
            throw new NotImplementedException();
        }

        public object LoadData(string filename, Type T)
        {
            XmlSerializer xmlSer = new XmlSerializer(T);
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                return xmlSer.Deserialize(fs);
            }
        }

        public void Start()
        {
            generator.Start();
        }

        public string Show()
        {
            string result;
            result = store.Name;
            foreach (var item in store.products)
            {
                result = result + " " + item.Name;
            }
            result += bank.BankID;
            return result;
        }

        public void Dispose()
        {
            store.Save(storePath);
            bank.Save(bankPath);
            factory.Save(factoryPath);
            generator.Dispose();
        }

    }
}
