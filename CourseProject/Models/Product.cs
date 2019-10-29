using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Product: IProduct
    {
        public int ID { get;  set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get;  set; }

        

        public Product()
        {
            
        }

        /// <summary>
        /// Sell some amount of product and returns how much it cost, return -1 if not enough quantity  
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public int SellProduct(int amount)
        { 
        if ((Quantity - amount) >= 0) { Quantity -= amount; return amount * Price; }
            else { return -1; }
        }
    }
}
