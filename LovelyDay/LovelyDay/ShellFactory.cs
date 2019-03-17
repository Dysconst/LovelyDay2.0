using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovelyDay
{
    static class ShellFactory
    {
        public static IShell Create(ShellType aShellType)
        {

            switch (aShellType)
            {
                case ShellType.CMD:
                    {
                        return new Shell_CMD();
                    }
                case ShellType.PowerShell:
                    {
                        return new Shell_Powershell();
                    }
                default:
                    {
                        return new Shell_CMD();
                    }
            }
        }
    }
    
    class Shell_LovelyDay : IShell
    {
        public Shell_LovelyDay()
        {

        }

        public void RunCommand(string aCommand)
        {
            throw new NotImplementedException();
        }
    }

    class Shell_CMD : IShell
    {
        private Process myProcess;
        private ProcessStartInfo myStartInfo;

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

        public void RunCommand(string aCommand)
        {
            myProcess.StandardInput.WriteLine(aCommand);
        }
    }

    class Shell_Powershell : IShell
    {
        private Process myProcess;
        private ProcessStartInfo myStartInfo;

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

        public void RunCommand(string aCommand)
        {
            myProcess.StandardInput.WriteLine(aCommand);
        }
    }

}
