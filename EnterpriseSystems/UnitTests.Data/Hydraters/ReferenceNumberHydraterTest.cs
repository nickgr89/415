using EnterpriseSystems.Data.Hydraters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class ReferenceNumberHydraterTest
    {
        private ReferenceNumberHydrater Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new ReferenceNumberHydrater();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}
