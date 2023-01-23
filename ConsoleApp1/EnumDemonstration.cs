using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class EnumDemonstration
    {
        enum TrafficLight
        {
            Red,
            RedAmber,
            Green,
            Amber
        }

        static void Main(string[] args)
        {
            TrafficLight light;
            light = TrafficLight.Red;
            Console.WriteLine(light);
            string x;
            x = Console.ReadLine();
        }
    }
}
