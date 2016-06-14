using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloningBenchMark.Entities
{
    [Serializable]
    public class Wheel
    {
        public string Trademark { get; set; }
        public string Model { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public char Letter { get; set; }
        public short Radius { get; set; }
    }
}
