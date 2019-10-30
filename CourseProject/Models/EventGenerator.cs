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
        // delegate type of events
        public delegate void GeneralEvent(System.Windows.Forms.TextBox textBox);

        //generated events
        public event GeneralEvent FirstEvent;
        public event GeneralEvent SecondEvent;
        public event GeneralEvent ThirdEvent;
        public event GeneralEvent FourthEvent;

        //textbox from main form where displayed events
        System.Windows.Forms.TextBox textBox;

        //random value for generating events
        Random rnd;
        
        //true if stop button on main form was press on
        public bool IsClicked;

        
        public EventGenerator(System.Windows.Forms.TextBox textbox)
        {
            rnd = new Random();
            textBox = textbox;
            IsClicked = false;
        }

        //generate events asyncronously with random delay
        public async void Working()
        {

            while (!IsClicked)
            {
                await Task.Delay(rnd.Next(1, 5) * 100);
                switch (rnd.Next(1, 4))
                {
                    case 1: { FirstEvent?.Invoke(textBox);   break; }
                    case 2: { SecondEvent?.Invoke(textBox);  break; }
                    case 3: { ThirdEvent?.Invoke(textBox);   break; }
                    case 4: { FourthEvent?.Invoke(textBox);  break; }
                    default: break;
                }
            } 
        }

        /// <summary>
        /// Starts task that async generate events
        /// </summary>
        public void Start()
        {
            Task.Factory.StartNew(Working);
        }

        /// <summary>
        /// Stops async generating method and ends task 
        /// </summary>
        public void Dispose()
        {
            IsClicked = true;
            //Task.WaitAll();
        }

    }
}
