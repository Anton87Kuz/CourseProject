using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourseProject.Models
{
    public class ProductStore:IFactory
    {
        public string Name { get; set; }

        public List<Product> products { get;  set; }

        

        //public Thread Working { get; }

        public ProductStore()
        {
           
        }

        public void Start()
        {
           // Working.Start();
        }

        public void GetCash(IBankAccount bank, int sum)
        {
            bank.GetMoney(sum);
        }

        public void PutCash(IBankAccount bank, int sum)
        {
            bank.SetMoney(sum);
        }

        public void Work()
        {
            throw new NotImplementedException();
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
