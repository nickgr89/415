using EnterpriseSystems.Data.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Mappers
{
    public class StopMapperTest
    {
        private StopMapper Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new StopMapper();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}