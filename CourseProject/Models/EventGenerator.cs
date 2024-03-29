﻿using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject.Models
{
    public class EventGenerator
    {
        // delegate type of events
        public delegate void GeneralEvent(TextBox textBox);
       

        //generated events
        public event GeneralEvent FirstEvent;
        public event GeneralEvent SecondEvent;
        public event GeneralEvent ThirdEvent;
        public event GeneralEvent FourthEvent;

        // events on start and stop of generating
        public event GeneralEvent StartWork;
        public event GeneralEvent StopWork;

        //textbox from main form where displayed events
        public TextBox textBox;
       

        //random value for generating events
        Random rnd;
        
        //true if stop button on main form was press on
        public bool IsClicked;

        //set it true after event StopWork take place
        public bool StopCalled;

              
        public EventGenerator(TextBox textbox)
        {
            rnd = new Random();
            textBox = textbox;
            IsClicked = false;
            StopCalled = false;
        }


        /// <summary>
        /// generate events asyncronously with random delay
        /// </summary>
        public void Working()
        {
            int n = rnd.Next(5, 10);      //adding more randomness

            StartWork?.Invoke(textBox);
            Thread.Sleep(rnd.Next(30-n, 40+n)*100);

            int m = rnd.Next(20, 50);
            while (!IsClicked)
            {
                switch (rnd.Next(1,5))
                {
                        case 1: { FirstEvent?.Invoke(textBox); break; }
                        case 2: { SecondEvent?.Invoke(textBox); break; }
                        case 3: { ThirdEvent?.Invoke(textBox); break; }
                        case 4: { FourthEvent?.Invoke(textBox); break; }
                        default: break;
                }
                Thread.Sleep(rnd.Next(100-n, 100+m) * 100);
            }
            //StopWork?.Invoke(textBox);
            StopCalled = true;
        }

        /// <summary>
        /// Starts task that async generate events
        /// </summary>
        public async void Start()
        {
            StopCalled = false;
            await Task.Factory.StartNew(Working);
            StopWork?.Invoke(textBox);
        }

        /// <summary>
        /// Stops async generating method that ends task 
        /// </summary>
        public void Dispose()
        {
            IsClicked = true;
            
        }

    }
}
