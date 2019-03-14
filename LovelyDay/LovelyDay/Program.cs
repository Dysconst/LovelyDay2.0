using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LovelyDay
{
    class Program
    {
        private static bool isRunning = true;

        static void Main(string[] args)
        {
            while (isRunning)
            {
                Update(0f /*Send DeltaTime*/ );
            }
        }

        static void Update(float aDeltaTime)
        {
            
        }

        public static void Kill()
        {
            isRunning = false;
        }
    }
}
