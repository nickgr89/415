using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnterpriseSystems.Data.Mappers;
using EnterpriseSystems.Data.DAO;
using EnterpriseSystems.Data.Hydraters;
using EnterpriseSystems.Data.Model.Entities;
using Moq;

namespace UnitTests.Data.Mappers
{
    public class ReferenceNumberMapperTest
    {
        private ReferenceNumberMapper Target { get; set; }
        private Mock<IDatabase> MockDatabase { get; set; }
        private Mock<IQuery> MockQuery { get; set; }
        private Mock<IHydrater<ReferenceNumberVO>> MockReferenceNumberHydrater { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            MockDatabase = new Mock<IDatabase>();
            MockQuery = new Mock<IQuery>();
            MockReferenceNumberHydrater = new Mock<IHydrater<ReferenceNumberVO>>();

            Target = new ReferenceNumberMapper(MockDatabase.Object, MockReferenceNumberHydrater.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Target = null;
            MockDatabase = null;
            MockQuery = null;
            MockReferenceNumberHydrater = null;
        }

        [TestMethod]
        public void GetReferenceNumbersByCustomerRequest_SetsQueryParameter()
        {
            var actual = Target.GetReferenceNumbersByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }

        [TestMethod]
        public void GetReferenceNumbersByCustomerRequest_ReturnsHydratedEntity()
        {
            var actual = Target.GetReferenceNumbersByCustomerRequest(new CustomerRequestVO());

            Assert.Fail();
        }
    }
}