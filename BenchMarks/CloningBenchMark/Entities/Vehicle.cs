using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CloningBenchMark.Entities
{
    [Serializable]
    public abstract class Vehicle
    {
        public string Owner { get; set; }
        public string Trademark { get; set; }
        public string Model { get; set; }
        public Engine MainEngine { get; set; }
        public List<Wheel> Wheels { get; set; }
        public int Seats { get; set; }

        public Vehicle()
        {
            Wheels = new List<Wheel>();
        }

    }
}
