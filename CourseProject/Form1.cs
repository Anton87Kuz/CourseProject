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
        

        public Form1()
        {
            InitializeComponent();
            eventMonitor = new EventMonitor(textBox1, button1);
        }

        
        private  void button1_Click(object sender, EventArgs e)
        {
            
            eventMonitor.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            button1.Enabled = false;
            
            eventMonitor.Stop();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            eventMonitor.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = new Random().Next(1000, 10000);
            eventMonitor.UsePrivateAccount(sum);
        }
    }
}
