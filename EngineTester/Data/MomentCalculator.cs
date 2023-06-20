using EngineTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic
{
    public static class MomentCalculator
    {
        public static List<double> FindIntermediateTorques(Settings settings)
        {
            List<double> torque = new();

            for (int i = 0; i+1 <= settings.Torque.Count-1; i++)
            {
                double changePerUnit = SolveChangePerUnit(settings, i);

                double torqueNow = settings.Torque[i];
                for (int j = settings.RotationSpeed[i]; j< settings.RotationSpeed[i + 1]; j++)
                {
                    torque.Add(torqueNow);
                    torqueNow += changePerUnit;
                }
            }
            return torque;
        }

        private static double SolveChangePerUnit(Settings settings, int i)
        {
            double torqueDifference = settings.Torque[i + 1] - settings.Torque[i];
            int rotationSpeedDifference = settings.RotationSpeed[i + 1] - settings.RotationSpeed[i];

            return torqueDifference / rotationSpeedDifference;
        }
    }
}
