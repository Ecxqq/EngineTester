using EngineTester.Data;
using EngineTester.Logic.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.TestStands
{
    public class PowerTester : TestStand
    {
        public PowerTester(IEngine engine)
        {
            _engine = engine;
        }

        private IEngine _engine;

        public override double Test(Settings settings)
        {
            double RotationSpeedForMaxPower = 0;
            double power = 0;
            while (_engine.RotationSpeed<_engine.Torque.Count-1)
            {
                double acceleration = CalculateAcceleration(settings);

                if (CalculatePower() > power)
                {
                    power = CalculatePower();
                    RotationSpeedForMaxPower = _engine.RotationSpeed;
                }

                UpdateEngineParameters(acceleration);
            }

            _engine.RotationSpeed = 0;

            return RotationSpeedForMaxPower;
        }

        private double CalculateAcceleration(Settings settings)
        {
            double acceleration = 0;

            if ((int)Math.Floor(_engine.RotationSpeed) < _engine.Torque.Count - 1)
            {
                acceleration = _engine.Torque[(int)Math.Round(_engine.RotationSpeed)] / settings.Inertia;
            }
            return acceleration;
        }

        private double CalculatePower()
        {
            double power = _engine.Torque[(int)Math.Round(_engine.RotationSpeed)] * _engine.RotationSpeed / 1000;

            return power;
        }

        private void UpdateEngineParameters(double acceleration)
        {
            _engine.RotationSpeed = _engine.RotationSpeed + acceleration;
        }
    }
}
