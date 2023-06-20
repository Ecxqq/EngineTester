using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.Engines
{
    class GasolineEngine : IEngine
    {
        public GasolineEngine(double temperature, List<double> torque)
        {
            Temperature = temperature;
            Torque = torque;
            RotationSpeed = 0;
        }

        public double Temperature { get; set; }

        public List<double> Torque { get; set; }

        public double RotationSpeed { get; set; }

    }
}
