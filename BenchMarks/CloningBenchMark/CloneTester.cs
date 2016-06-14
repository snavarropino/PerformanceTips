using BenchmarkDotNet.Attributes;
using CloningBenchMark.Cloners;
using CloningBenchMark.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloningBenchMark
{
    public class CloneTester
    {
        [Params(100, 200, 2000)]
        public int NumTimes { get; set; }

        [Params(2, 5, 15)]
        public int NumVehicles { get; set; }


        [Benchmark]
        public void CloneByReflection()
        {
            var cloner = new ReflectionCloner();
            var garage = CreateGarage(numberOfVehicles: NumVehicles);
            for (var i = 0; i < NumTimes; i++)
            {
                var res = cloner.Clone<Garage>(garage);
            }
        }

        [Benchmark]
        public void CloneBySerialization()
        {
            var cloner = new SerializationCloner();
            var garage = CreateGarage(numberOfVehicles: NumVehicles);
            for (var i = 0; i < NumTimes; i++)
            {
                var res = cloner.Clone<Garage>(garage);
            }
        }



        protected static Garage CreateGarage(int numberOfVehicles)
        {
            var list = new List<Vehicle>();

            for (var i = 0; i < numberOfVehicles; i++)
            {
                //Create car
                var car = new Car();
                car.Owner = "Sergio";
                car.Trademark = "Opel";
                car.Model = "Astra";

                car.MainEngine = new Engine();
                car.MainEngine.HorsePower = 220;

                var wheel1 = new Wheel();
                wheel1.Width = 225;
                wheel1.Height = 45;
                wheel1.Letter = 'R';
                wheel1.Radius = 14;
                wheel1.Trademark = "Michelin";
                wheel1.Model = "XF555";
                car.Wheels.Add(wheel1);

                var wheel2 = new Wheel();
                wheel2.Width = 225;
                wheel2.Height = 45;
                wheel2.Letter = 'R';
                wheel2.Radius = 14;
                wheel2.Trademark = "Michelin";
                wheel2.Model = "XF555";
                car.Wheels.Add(wheel2);

                var wheel3 = new Wheel();
                wheel3.Width = 225;
                wheel3.Height = 45;
                wheel3.Letter = 'R';
                wheel3.Radius = 14;
                wheel3.Trademark = "Michelin";
                wheel3.Model = "XF555";
                car.Wheels.Add(wheel3);

                var wheel4 = new Wheel();
                wheel4.Width = 225;
                wheel4.Height = 45;
                wheel4.Letter = 'R';
                wheel4.Radius = 14;
                wheel4.Trademark = "Michelin";
                wheel4.Model = "XF555";
                car.Wheels.Add(wheel4);

                list.Add(car);
            }

            var garage = new Garage();
            garage.VehicleList.AddRange(list);
            return garage;
        }

    }
}
