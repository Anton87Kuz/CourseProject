using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class IDGenerator
    {
        int Number;

        public IDGenerator()
        {
            Number = 999999;
        }

        public int NewID()
        {
            Number++;
            return Number;
        }
    }
}
