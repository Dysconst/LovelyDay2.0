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

		private float timeToCount;
		private float startTime;

		public TimeCounter (float usrTime)
		{
			timeToCount = usrTime;
			startTime = Timer.GetTotalTime ();
		}

		public bool blockingUpdateChecker () {
			while (!noBlockCheck()) {
				Timer.Update ();
				continue;
			}
			return true;
		}

		public bool noBlockCheck() {
			if (Timer.GetTotalTime() - startTime >= timeToCount) {
				return true;
			}
			return false;
		}
	}
}

