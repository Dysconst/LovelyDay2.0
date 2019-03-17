using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovelyDay
{
    interface IPayload
    {
        string Name { get; }
        bool IsEnabled { get; }
        void Start();   
        void Stop();
        void Update(float aDeltaTime);
    }
}