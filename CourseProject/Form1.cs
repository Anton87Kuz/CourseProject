using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class Form1 : Form
    {
        


        EventMonitor eventMonitor;
        bool Stop = false;

        public Form1()
        {
            InitializeComponent();
            eventMonitor = new EventMonitor();
            

        }

        
        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Delay(100);
            // eventMonitor.
            textBox1.Text = eventMonitor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stop = true;
            eventMonitor.Dispose();
        }
    }
}
