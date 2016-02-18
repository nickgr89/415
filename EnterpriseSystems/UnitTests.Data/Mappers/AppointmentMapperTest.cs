using EnterpriseSystems.Data.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Mappers
{
    public class AppointmentMapperTest
    {
        private AppointmentMapper Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new AppointmentMapper();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}
