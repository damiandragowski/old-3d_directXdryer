using System;
using System.Collections.Generic;
using System.Text;

namespace _DStudioMax._3DLib
{
    public class Clock
    {
        protected int tickCount;

        public Clock()
        {
            tickCount = System.Environment.TickCount;
        }

        public virtual float GetTime()
        {
            int t = System.Environment.TickCount;
            float tf = (t - tickCount) / 1000f;
            tickCount = t;
            return tf;
        }

        public virtual void Reset()
        {
            tickCount = System.Environment.TickCount;
        }
    }
}
