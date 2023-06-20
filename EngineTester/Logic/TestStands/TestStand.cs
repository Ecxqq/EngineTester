using EngineTester.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.TestStands
{
    public abstract class TestStand
    {
        public abstract double Test(Settings settings);
    }
}
