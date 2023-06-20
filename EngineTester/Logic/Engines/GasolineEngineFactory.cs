using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.Engines
{
    class GasolineEngineFactory : EngineFactory
    {
        public GasolineEngineFactory(int engineTemperature, List<double> torque)
        {
            _temperature = engineTemperature;
            _torque = torque;
        }

        private double _temperature;

        private List<double> _torque;

        public override IEngine GetEngine()
        {
            GasolineEngine gasolineEngine = new(_temperature, _torque);
            return gasolineEngine;
        }
    }
}
