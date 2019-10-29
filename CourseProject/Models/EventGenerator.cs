using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class EventGenerator
    {
        public delegate void GeneralEvent(System.Windows.Forms.TextBox textBox);

        public event GeneralEvent FirstEvent;
        public event GeneralEvent SecondEvent;
        public event GeneralEvent ThirdEvent;
        public event GeneralEvent FourthEvent;

        Random rnd;

        public EventGenerator()
        {
            rnd = new Random();
        }

        public async void Start(System.Windows.Forms.TextBox textBox, bool stop)
        {
            
            while (!stop)
            {
                await Task.Delay(1000);
                switch(rnd.Next(1,4))
                {
                    case 1: { FirstEvent?.Invoke(textBox);   break; }
                   // case 2: { SecondEvent?.Invoke(textBox);  break; }
                   // case 3: { ThirdEvent?.Invoke(textBox);   break; }
                    //case 4: { FourthEvent?.Invoke(textBox);  break; }
                    default: break;
                }
            }

        }

        //public void FirstEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        //public void SecondEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        //public void ThirdEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        //public void FourthEvent(System.Windows.Forms.TextBox textBox)
        //{ }



    }
}
