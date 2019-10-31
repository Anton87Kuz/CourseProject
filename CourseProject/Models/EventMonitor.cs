using CourseProject.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CourseProject.Models
{
    /// <summary>
    /// Class that contains all factories, banks, generates events and show them on textbox on main form
    /// </summary>
    public class EventMonitor:IDisposable
    {
        //contains paths to xml-files where saved all producable factories of the owner
        private List<string> paths = new List<string>(5)
        { 
          "C:/Users/kuzan/Desktop/C# Projects/CourseProject/ProductStore1.xml", 
          "C:/Users/kuzan/Desktop/C# Projects/CourseProject/Factory1.xml",
          "C:/Users/kuzan/Desktop/C# Projects/CourseProject/Airport1.xml",
          "C:/Users/kuzan/Desktop/C# Projects/CourseProject/Factory2.xml",
          "C:/Users/kuzan/Desktop/C# Projects/CourseProject/NewsPaper1.xml",
        };
        //contains path to the bank of the owner
        private string bankPath = "C:/Users/kuzan/Desktop/C# Projects/CourseProject/Bank.xml";

        //lists of factories and generators of events for them
        private List<IFactory> factories;
        private List<EventGenerator> generators;
        private List<Type> types;
        
        //instance of the bank of the owner
        private BankAccount bank;

        private Button StartButton;
        private TextBox textBox;

        

        public EventMonitor(TextBox textbox, Button button1)
        {
            
            factories = new List<IFactory>();
            generators = new List<EventGenerator>();
            bank = new BankAccount();
            types = new List<Type>() { typeof(ProductStore), typeof(Factory), typeof(Airport), typeof(NewsPaper)};

            StartButton = button1;
            textBox = textbox;
            
            //loading bank from corresponding file
            bank = (BankAccount)LoadData(bankPath, bank.GetType());
            bank.PrivateAcc.SetPrivacy();

            //loading all factories from files and creating generator of events for each of them (using reflection)
            foreach (string item in paths)
            {
                foreach (Type t in types)
                {
                    if (item.Contains(t.Name))
                    {
                        factories.Add((IFactory)LoadData(item, t));
                        generators.Add(new EventGenerator(textbox));
                    }
                }
            }

            
            
            //subscribing on events and addng bank acount for finance operations
            foreach (EventGenerator item in generators)
            {
                factories[generators.IndexOf(item)].GetBankAccount(bank.OperationalAcc);
               
                item.StopWork+= factories[generators.IndexOf(item)].OnStop;
                item.StartWork += factories[generators.IndexOf(item)].OnStart;
                item.FirstEvent += factories[generators.IndexOf(item)].OnFirstEvent;
                item.SecondEvent += factories[generators.IndexOf(item)].OnSecondEvent;
                item.ThirdEvent += factories[generators.IndexOf(item)].OnThirdEvent;
                item.FourthEvent += factories[generators.IndexOf(item)].OnFourthEvent;
            }
        }

       
        /// <summary>
        /// Loads data from xml-file, returns object, need cast to correct type
        /// </summary>
        /// <param name="filename">path to xml-file</param>
        /// <param name="T">type what are contained in file</param>
        /// <returns></returns>
        public object LoadData(string filename, Type T)
        {
            XmlSerializer xmlSer = new XmlSerializer(T);
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                return xmlSer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Starting events generators
        /// </summary>
        public void Start()
        {
            foreach (EventGenerator item in generators)
            {
                item.IsClicked = false;
                item.Start();
            }
                                 
        }

        /// <summary>
        /// Stops events generators
        /// </summary>
        public async void Stop()
        {
            int n=0;
            do
            {
                n = 0;
                foreach (EventGenerator item in generators)
                {
                    item.IsClicked = true;
                    if (item.StopCalled) { n++; } else { continue; }
                }
                await Task.Delay(300);
            }
            while (n != generators.Count);
            StartButton.Invoke((MethodInvoker)delegate { StartButton.Enabled = true; });
        }


        /// <summary>
        /// Stoprs all tasks and save all current data of factories to xml files
        /// </summary>
        public void Dispose()
        {
            foreach (EventGenerator item in generators)
            {
                item.IsClicked = true;
            }

            foreach (IFactory item in factories)
            {
                item.Save(paths[factories.IndexOf(item)]);
            }

            bank.Save(bankPath);
        }

        public async void UsePrivateAccount(int sum)
        {
            if (await bank.PrivateAcc.GetCash(sum))
            {
                textBox?.Invoke((MethodInvoker)delegate { textBox.Text += "Owner take " + sum + "$ from his private account"+"\r"+"\n"; });
            }
        }
    }
}
