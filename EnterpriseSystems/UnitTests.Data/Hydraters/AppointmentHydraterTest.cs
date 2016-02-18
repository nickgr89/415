using EnterpriseSystems.Data.Hydraters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Hydraters
{
    [TestClass]
    public class AppointmentHydraterTest
    {
        private AppointmentHydrater Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new AppointmentHydrater();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}
