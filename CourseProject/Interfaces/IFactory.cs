using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject.Interfaces
{
    public interface IFactory
    {
        string Name { get; set; }

        List<Product> products { get; set; }

        //Account account { get; set; }

        void GetBankAccount(Account account);

        void OnStart(TextBox textBox);
        
        void OnStop(TextBox textBox);
        
        void OnFirstEvent(TextBox textBox);

        void OnSecondEvent(TextBox textBox);

        void OnThirdEvent(TextBox textBox);

        void OnFourthEvent(TextBox textBox);

        void Save(string filename);


    }
}
