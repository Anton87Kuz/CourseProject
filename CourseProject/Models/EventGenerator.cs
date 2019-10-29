using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        System.Windows.Forms.TextBox textBox;
        Random rnd;
        
        public bool IsClicked;

        public EventGenerator(System.Windows.Forms.TextBox textbox)
        {
            rnd = new Random();
            textBox = textbox;
            IsClicked = false;
        }

        public async void Working()
        {

            while (!IsClicked)
            {
                await Task.Delay(rnd.Next(1, 5) * 10);
                switch (rnd.Next(1, 4))
                {
                    case 1: { FirstEvent?.Invoke(textBox); break; }
                    case 2: { SecondEvent?.Invoke(textBox);  break; }
                    // case 3: { ThirdEvent?.Invoke(textBox);   break; }
                    //case 4: { FourthEvent?.Invoke(textBox);  break; }
                    default: break;
                }
            } 
        }

        public void Start()
        {
            
            Task.Factory.StartNew(Working);

        }

        //public void FirstEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        //public void SecondEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        //public void ThirdEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        //public void FourthEvent(System.Windows.Forms.TextBox textBox)
        //{ }

        public void Dispose()
        {
            IsClicked = true;
            Task.WaitAll();
        }

    }
}
