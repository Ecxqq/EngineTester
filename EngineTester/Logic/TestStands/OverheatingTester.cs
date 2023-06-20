using EngineTester.Data;
using EngineTester.Logic.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.TestStands
{
    public class OverheatingTester : TestStand
    {
        public OverheatingTester(IEngine engine)
        {
            _engine = engine;
        }

        private IEngine _engine;

        public override double Test(Settings settings)
        {
            int time = 0;

            while(_engine.Temperature<settings.OverheatTemperature)
            {
                double acceleration = CalculateAcceleration(settings);
                double heatingSpeed = CalculateHeatingSpeed(settings);
                double coolingSpeed = CalculateCoolingSpeed(settings);

                time++;
                UpdateEngineParameters(acceleration, heatingSpeed, coolingSpeed);
            }
            _engine.RotationSpeed = 0;
            _engine.Temperature = settings.AmbientTemperature;
            return time;
        }

        private double CalculateHeatingSpeed(Settings settings)
        {
            double heatingOfSpeed = Math.Pow(_engine.RotationSpeed, 2) * settings.HeatingRateOfSpeed;
            double heatingOfTorque = _engine.Torque[(int)Math.Floor(_engine.RotationSpeed)] * settings.HeatingRateOfTorque;
            double heatingSpeed = heatingOfSpeed + heatingOfTorque;
                   
            return heatingSpeed;
        }

        private double CalculateCoolingSpeed(Settings settings)
        {
            double coolingSpeed = settings.CoolingRate * (settings.AmbientTemperature - _engine.Temperature);

            return coolingSpeed;
        }

        private double CalculateAcceleration(Settings settings)
        {
            double acceleration = 0;

            if ((int)Math.Floor(_engine.RotationSpeed) < _engine.Torque.Count - 1)
            {
                acceleration = _engine.Torque[(int)Math.Floor(_engine.RotationSpeed)] / settings.Inertia;
            }
            return acceleration;
        }

        private void UpdateEngineParameters(double acceleration, double heatingSpeed, double coolingSpeed)
        {
            _engine.RotationSpeed = _engine.RotationSpeed + acceleration;
            _engine.Temperature = _engine.Temperature + coolingSpeed + heatingSpeed;
        }
    }
}
