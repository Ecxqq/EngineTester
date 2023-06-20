using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.Engines
{
    public interface IEngine
    {
        public double Temperature { get; set; }

        public List<double> Torque { get; set; }

        public double RotationSpeed { get; set; }
    }
}
