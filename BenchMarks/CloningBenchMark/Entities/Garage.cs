using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloningBenchMark.Entities
{
    [Serializable]
    public class Garage
    {
        public Garage()
        {
            VehicleList = new List<Vehicle>();
        }
        public List<Vehicle> VehicleList { get; set; }
    }
}
