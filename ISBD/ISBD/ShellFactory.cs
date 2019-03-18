using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBD
{
    static class ShellFactory
    {
        public static IShell Create(ShellType aShellType)
        {

            switch (aShellType)
            {
                case ShellType.LovelyDay:
                {
                    return new Shell_LovelyDay();
                }
                case ShellType.Cmd:
                {
                    return new Shell_CMD();
                }
                case ShellType.PowerShell:
                {
                    return new Shell_Powershell();
                }
                default:
                {
                    return new Shell_LovelyDay();
                }
            }
        }
    }
    
    class Shell_LovelyDay : IShell
    {
        public ShellType myType => throw new NotImplementedException();

        public Shell_LovelyDay()
        {
            throw new NotImplementedException();
        }

        public void WriteStream(string someData)
        {
            throw new NotImplementedException();
        }
    }

    class Shell_CMD : IShell
    {
        private Process myProcess;
        private ProcessStartInfo myStartInfo;
        public ShellType myType => throw new NotImplementedException();

        public Shell_CMD()
        {
            myProcess = new Process();
            myStartInfo = new ProcessStartInfo();
            myStartInfo.CreateNoWindow = true;
            myStartInfo.UseShellExecute = false;
            myStartInfo.RedirectStandardOutput = true;
            myStartInfo.RedirectStandardInput = true;
            myStartInfo.RedirectStandardError = true;
            myProcess.StartInfo = myStartInfo;
            myProcess.OutputDataReceived += new DataReceivedEventHandler(ReverseManager.OutputHandler);
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.Start();
            myProcess.BeginOutputReadLine();
        }

        public void WriteStream(string aCommand)
        {
            myProcess.StandardInput.WriteLine(aCommand);
        }
    }

    class Shell_Powershell : IShell
    {
        private Process myProcess;
        private ProcessStartInfo myStartInfo;
        public ShellType myType => throw new NotImplementedException();

        public Shell_Powershell()
        {
            myProcess = new Process();
            myStartInfo = new ProcessStartInfo();
            myStartInfo.CreateNoWindow = true;
            myStartInfo.UseShellExecute = false;
            myStartInfo.RedirectStandardOutput = true;
            myStartInfo.RedirectStandardInput = true;
            myStartInfo.RedirectStandardError = true;
            myProcess.StartInfo = myStartInfo;
            myProcess.OutputDataReceived += new DataReceivedEventHandler(ReverseManager.OutputHandler);
            myProcess.StartInfo.FileName = "powershell.exe";
            myProcess.Start();
            myProcess.BeginOutputReadLine();
        }

        public void WriteStream(string aCommand)
        {
            myProcess.StandardInput.WriteLine(aCommand);
        }
    }

}
