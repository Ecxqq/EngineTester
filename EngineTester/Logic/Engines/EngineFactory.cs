using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester.Logic.Engines
{
    public abstract class EngineFactory
    {
        public abstract IEngine GetEngine();
    }
}
