using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Enums;


namespace ISBDPayload
{
    class PayloadManager
    {
        private Dictionary<Payload, IPayload> myPayloads = new Dictionary<Payload, IPayload>();
        private Thread myPayloadThread;

        public PayloadManager()
        {
            myPayloads.Add(Payload.TaskKiller, new TaskKiller());
        }

        public void Start(Payload aPayload)
        {
            myPayloads[aPayload].Start();
        }

        public void Stop(Payload aPayLoad)
        {
            myPayloads[aPayLoad].Stop();
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
