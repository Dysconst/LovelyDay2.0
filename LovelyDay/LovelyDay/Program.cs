using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace LovelyDay
{
    class Program
    {
        private static bool isRunning = true;

        [DllImport("kernel32.dll")]
        static extern void Sleep(uint dwMilliseconds);
        
        static void Main(string[] args)
        {
            while (isRunning)
            {
                Update();
            }
        }

        static void Update()
        {
            Timer.Update();


        }

        public static void Kill()
        {
            isRunning = false;
        }
    }
}
