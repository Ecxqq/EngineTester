using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Data
{
    static class Setter
    {
        public static void SetParameters(Settings settings)
        {
            settings.Torque = new();
            settings.Torque.Add(20);
            settings.Torque.Add(75);
            settings.Torque.Add(100);
            settings.Torque.Add(105);
            settings.Torque.Add(75);
            settings.Torque.Add(1);

            settings.RotationSpeed = new();
            settings.RotationSpeed.Add(0);
            settings.RotationSpeed.Add(75);
            settings.RotationSpeed.Add(150);
            settings.RotationSpeed.Add(200);
            settings.RotationSpeed.Add(250);
            settings.RotationSpeed.Add(300);

            settings.OverheatTemperature = 110;
            settings.Inertia = 10;
            settings.HeatingRateOfSpeed = 0.0001;
            settings.HeatingRateOfTorque = 0.01;
            settings.CoolingRate = 0.1;
        }
    }
}
