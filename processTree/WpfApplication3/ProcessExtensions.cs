using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
     public static class ProcessExtensions
    {
        public static List<Process> GetChildProcesses(this Process process)
        {
            var results = new List<Process>();

            string Text = string.Format("select processid from win32_process where parentprocessid = {0}", process.Id);
            using (var searcher = new ManagementObjectSearcher(Text))
            {
                foreach (var obj in searcher.Get())
                {
                    object data = obj.Properties["processid"].Value;
                    if (data != null)
                    {
                        var childProcess = Process.GetProcessById(Convert.ToInt32(data));
                        if (childProcess != null)
                            results.Add(childProcess);
                    }
                }
            }
            return results;
        }
        public static int GetParentId(this Process process)
        {
            string Text = string.Format("select parentprocessid from win32_process where processid = {0}", process.Id);
            using (var searcher = new ManagementObjectSearcher(Text))
            {
                foreach (var obj in searcher.Get())
                {
                    object data = obj.Properties["parentprocessid"].Value;
                    if (data != null)
                        return Convert.ToInt32(data);
                }
            }
            return 0;
        }
    }
}
