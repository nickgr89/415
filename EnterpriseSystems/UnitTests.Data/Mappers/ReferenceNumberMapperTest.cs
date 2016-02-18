using EnterpriseSystems.Data.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data.Mappers
{
    public class ReferenceNumberMapperTest
    {
        private ReferenceNumberMapper Target { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Target = new ReferenceNumberMapper();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
        }
    }
}