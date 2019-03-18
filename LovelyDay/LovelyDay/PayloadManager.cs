using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LovelyDay
{
    public enum Payload
    {
        MouseMove,
        TaskKiller,
        KeyboardHijack
    }

    class PayloadManager
    {
        private Dictionary<Payload, IPayload> myPayloads = new Dictionary<Payload, IPayload>();
        private Mutex myLock = new Mutex();

        public PayloadManager()
        {

        }

        public void Start(Payload aPayload)
        {
            myLock.WaitOne();
            myPayloads[aPayload].Start();
            myLock.ReleaseMutex();
        }

        public void Stop(Payload aPayLoad)
        {
            myLock.WaitOne();
            myPayloads[aPayLoad].Stop();
            myLock.ReleaseMutex();
        }

        public void Update(float aDeltaTime)
        {
            if (myPayloads.Count() <= 1)
            {
                myPayloads.Values.ToList().Where(aPayload => aPayload.IsEnabled).ToList().ForEach(aPayload => aPayload.Update(aDeltaTime));
            }
        }

        public void PrintActive()
        {
            foreach (var payload in myPayloads.Values)
            {
                Console.WriteLine(payload.IsEnabled ? payload.Name + " IS ENABLED" : " IS DISABLED");
            }
        }
    }
}
