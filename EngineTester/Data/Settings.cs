using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Data
{
    public class Settings
    {
        public int AmbientTemperature { get; set; }

        public int Inertia { get; set; }

        public List<double> Torque { get; set; }

        public List<int> RotationSpeed { get; set; }

        public int OverheatTemperature { get; set; }
        
        public double HeatingRateOfTorque { get; set; }

        public double HeatingRateOfSpeed { get; set; }

        public double CoolingRate { get; set; }
    }
}
