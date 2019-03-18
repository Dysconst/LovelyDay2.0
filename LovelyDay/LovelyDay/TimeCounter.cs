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
	class TimeCounter
	{
		//Should this class be re-written to be a thread instead?
        //Just needs to be thread friendly, the idea is to run all payloads on one single thread so we can't freeze the software up

		private float timeToCount;

		public TimeCounter (float usrTime)
		{
			timeToCount = usrTime;
		}

		public bool BlockCheck()
        {
            return (timeToCount -= Timer.GetDeltaTime()) <= timeToCount;
        }
	}
}

