using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FYP_Common;

namespace FYP_GUI_v1
{
    public class Model_Automator : INotifyPropertyChanged
    {
        // static list
        public static BindingList<Model_Automator> list = null;

        public static void reset()
        {
            list = new BindingList<Model_Automator>();
            //slist.Add(new Model_Automator());
        }

        public static void save(string path, string file)
        {
            XMLHelper.ObjectToXML(list, path, file);
        }

        public static void load(string path)
        {
            list = (BindingList<Model_Automator>)XMLHelper.ObjectFromXML(path, typeof(BindingList<Model_Automator>));
        }

        // object
        public bool run = false;
        private string action;
        private string param1;
        private string param2;
        private string param3;
        private string param4;
        private string param5;
        private string param6;
        private string param7;
        private string param8;

        [Browsable(false)]
        public int recursionIdentifer = 0; // let you know the deepness of recursion

        [Browsable(false)]
        public int recursionPointer = 0; // let you know the end point of this recursive sub procedure

        [Browsable(false)]
        public string recursionPath = ""; // suggest the path suffix for this recursive sub procedure

        public Model_Automator()
        {
            this.action = "";
        }

        public Model_Automator(string action)
        {
            this.action = action;
        }

        public string Action
        {
            get { return action; }
            set { action = value; this.NotifyPropertyChanged("Action"); }
        }

        public string Param1
        {
            get { return param1; }
            set { param1 = value; this.NotifyPropertyChanged("Param1"); }
        }

        public string Param2
        {
            get { return param2; }
            set { param2 = value; this.NotifyPropertyChanged("Param2"); }
        }

        public string Param3
        {
            get { return param3; }
            set { param3 = value; this.NotifyPropertyChanged("Param3"); }
        }

        public string Param4
        {
            get { return param4; }
            set { param4 = value; this.NotifyPropertyChanged("Param4"); }
        }

        public string Param5
        {
            get { return param5; }
            set { param5 = value; this.NotifyPropertyChanged("Param5"); }
        }

        public string Param6
        {
            get { return param6; }
            set { param6 = value; this.NotifyPropertyChanged("Param6"); }
        }

        public string Param7
        {
            get { return param7; }
            set { param7 = value; this.NotifyPropertyChanged("Param7"); }
        }

        public string Param8
        {
            get { return param8; }
            set { param8 = value; this.NotifyPropertyChanged("Param8"); }
        }

        public void ResetRecursionParam()
        {
            this.recursionIdentifer = 0;
            this.recursionPointer = 0;
            this.recursionPath = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
