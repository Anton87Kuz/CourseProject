using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Interfaces

{
    public interface IBankAccount
    {
        string BankID { get; set; }

        Account OperationalAcc { get; set; }

        Account PrivateAcc { get; set; }

        void GetMoney(int sum);

        void SetMoney(int sum);

        void GetCurrentSum();
    }
}
