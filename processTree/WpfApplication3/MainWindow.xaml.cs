using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread = null;
        Process proc = new Process();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void processesTree_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(delegate() { Dispatcher.Invoke(delegate() { Method(sender); }); });
            thread.IsBackground = true;
            thread.Start();
        }
        static void Method(object sender)
        {
            Process[] pt = Process.GetProcesses();
            for (int i = 0; i < pt.Length - 1; i++)
            {
                Process p = Process.GetProcessById(pt[i].Id);
                ProcessTree t = new ProcessTree(p);
                TreeViewItem item = new TreeViewItem();

                item.Header = t.ProcessName;
                List<string> ct = new List<string>();
                foreach (var v in t.ChildProcesses)
                {
                    ct.Add(v.ProcessName);
                }
                item.ItemsSource = ct;
                var tree = sender as TreeView;
                tree.Items.Add(item);
            }
        }
    }
}
