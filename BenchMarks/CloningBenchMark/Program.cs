using BenchmarkDotNet.Running;
using CloningBenchMark.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloningBenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CloneTester>();
        }      
      
    }
}
