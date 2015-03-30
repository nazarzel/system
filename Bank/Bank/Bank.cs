using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        int money;
        string name;
        int percent;
        protected void OnPropertyChanged()
        {
            writeData();
        }

        public int Percent
        {
            get { return percent; }
            set
            {
                if (value != percent)
                {
                    percent = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Money
        {
            get { return money; }
            set
            {
                if (value != money)
                {
                    money = value;
                    OnPropertyChanged();
                }
            }
        }

        private void writeData()
        {
            string[] data = {DateTime.Now+"\n\nmoney: " + money, "\nname: " + name , "\npercent: " + percent};
            System.IO.File.WriteAllLines(@"C:\Users\Назар\Desktop\test.txt", data);
        }
    }
}
