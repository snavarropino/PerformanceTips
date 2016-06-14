using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CloningBenchMark.Cloners
{
    public abstract class BaseCloner
    {
        protected Stopwatch _sw;

        public BaseCloner()
        {
            _sw=new Stopwatch();
        }

        public abstract T Clone<T>(T source);        

        protected void StartTime()
        {
            if(!_sw.IsRunning)
                _sw.Start();
        }

        protected void TraceTime()
        {
            _sw.Stop();
            Trace.TraceInformation("Cloning in {0} ms",_sw.ElapsedMilliseconds);

        }


    }
}
