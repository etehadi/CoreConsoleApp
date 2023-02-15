using BoDi;
using ConsoleUI.Test.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Test.Hooks
{    
    [Binding]
    public class EarlyHooks
    {
        private readonly IObjectContainer _objectContainer;

        // Do not add other injection dependencies to this class.
        public EarlyHooks(IObjectContainer objectContainer) => _objectContainer = objectContainer;


        [BeforeScenario(Order = 0)]
        public void BeforeAnyScenario()
        {
            // Explicit constructor resolution.
            _objectContainer.RegisterFactoryAs<Random>(_ => new());

            // Umplicit constructor 
            var aspDriver = _objectContainer.Resolve<TestHostDriver>();
            aspDriver.BuildHost();
        }
    }
}
