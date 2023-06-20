using EngineTester.Data;
using EngineTester.Logic;
using EngineTester.Logic.Engines;
using EngineTester.Logic.TestStands;
using System;
using System.Collections.Generic;

namespace EngineTester.Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new();
            Console.Write(">>>Введите температуру окружающей среды: ");
            settings.AmbientTemperature = int.Parse(Console.ReadLine());
            Setter.SetParameters(settings);

            List<double> torque = MomentCalculator.FindIntermediateTorques(settings);
            EngineFactory gasolineEngineFactory = GetFactory(settings.AmbientTemperature,torque);

            IEngine gasolineEngine = gasolineEngineFactory.GetEngine();

            PrintTestResult("0", settings, gasolineEngine);
            PrintTestResult("1", settings, gasolineEngine);


        }

        private static EngineFactory GetFactory(int ambientTemperature,List<double> torque)
        {
            GasolineEngineFactory gasolineEngineFactory = new(ambientTemperature, torque);
            return gasolineEngineFactory;
        }

        private static double StartTest(TestStand testStand,Settings settings)
        {
            double result = testStand.Test(settings);

            return result;
        }

        private static void PrintTestResult(string n, Settings settings, IEngine engine)
        {
            switch (n.ToLower())
            {
                case "0":
                    {
                        PowerTester powerTester = new(engine);
                        var rotationSpeedForMaxPower = StartTest(powerTester, settings);
                        var power = engine.Torque[(int)Math.Floor(rotationSpeedForMaxPower)];
                        Console.WriteLine("Максимальная мощность двигателя: " + power + "[Н/М]");
                        Console.WriteLine("Максимальная мощность будет при скорости коленчатого вала: " + rotationSpeedForMaxPower+"[Рад/С]");
                        break;
                    }
                case "1":
                    {
                        OverheatingTester overheatingTester = new(engine);
                        Console.WriteLine("Время за которое двигатель уйдет в перегрев: " + StartTest(overheatingTester, settings) + "[С.]");
                        break;
                    }
            }
        }

    }
}
