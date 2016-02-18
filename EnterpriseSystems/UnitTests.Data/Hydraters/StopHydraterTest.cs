using EnterpriseSystems.Data.Hydraters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class StopHydraterTest
    {
        private StopHydrater Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new StopHydrater();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}
