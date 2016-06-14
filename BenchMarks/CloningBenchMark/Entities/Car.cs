using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloningBenchMark.Entities
{
    [Serializable]
    public class Car: Vehicle
    {       

        public Car()
        {
            Seats = 5;
        }
    }
}
