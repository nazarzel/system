using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    class ProcessTree
    {
        public ProcessTree(Process process)
        {
            this.Process = process;
            FillChildren();
        }

        void FillChildren()
        {
            this.ChildProcesses = new List<ProcessTree>();
            var childProcesses = this.Process.GetChildProcesses();
            foreach (var childProcess in childProcesses)
                this.ChildProcesses.Add(new ProcessTree(childProcess));
        }
        public Process Process { get; set; }

        public List<ProcessTree> ChildProcesses { get; set; }

        public string ProcessName { get { return Process.ProcessName; } }
    }
}
