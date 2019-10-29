using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseProject.Interfaces
{
    public interface IFactory
    {
        string Name { get; set; }

        List<Product> products { get; set; }

        //Thread Working { get; }

        void Start();

        void Work();

        void GetCash(IBankAccount bank, int sum);

        void PutCash(IBankAccount bank, int sum);

        void Save(string filename);


    }
}
