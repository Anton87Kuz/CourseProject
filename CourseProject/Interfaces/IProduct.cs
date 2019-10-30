using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Interfaces
{
    public interface IProduct
    {
        int ID { get; set; }

        string Name { get; set; }

        int Quantity { get; set; }

        int Price { get; set; }

        int SellProduct(int amount);

        void AddProduct(int amount);
    }
}
