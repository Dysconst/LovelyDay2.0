using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace LovelyDay
{
    static class Timer
    {
        private static float myDeltaTime;
        private static float myTotalTime;
        private static Stopwatch myStopWatch;

        static Timer()
        {
            myStopWatch = new Stopwatch();
            myDeltaTime = 0;
            myTotalTime = 0;
        }

        public static void Update()
        {
            myStopWatch.Stop();
            myDeltaTime = ((float)myStopWatch.ElapsedTicks / (float)(TimeSpan.TicksPerMillisecond / 1000f)) / 1000000f; // Delta time down to nano seconds
            myTotalTime += myDeltaTime;
            myStopWatch.Reset();
            myStopWatch.Start();
        }

        public static float GetDeltaTime()
        {
            return myDeltaTime;
        }

        public static float GetTotalTime()
        {
            return myTotalTime;
        }
    }
}
